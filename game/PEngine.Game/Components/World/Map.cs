using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Common.Interop;
using PEngine.Game.Components.World.Entities;
using PEngine.Game.Screens.World;
using System.Collections.Generic;
using System.Linq;
using static Core;

namespace PEngine.Game.Components.World
{
    internal class Map
    {
        internal const int TILE_SIZE = 16;

        private MapData _data;
        private Tileset _tileset;
        private Texture2D _texture;
        private Texture2D _fillTileTexture;

        internal Point WorldOffset { get; }
        internal World World { get; }
        internal List<Entity> Entities { get; } = new List<Entity>();
        internal string Id { get; }

        internal Map(World world, string id)
        {
            World = world;
            Id = id;

            WorldOffset = World.GetWorldmapOffset(Id);
        }

        internal void LoadContent()
        {
            var file = Project.ActiveProject.GetFile(Id);
            if (file == null)
            {
                GamePipeline.Log(LogType.Error, $"File requested for map with id {Id} does not exist.");
                throw new DataLoadException(Id, ProjectFileType.Map);
            }
            _data = MapData.Load(file);
            GamePipeline.Write(Pipeline.EVENT_LOAD_MAP, Id);

            _tileset = new Tileset(_data.tileset);
            _tileset.LoadContent();

            GenerateMapTexture();

            foreach (var entity in Entities)
            {
                entity.LoadContent();
            }
        }

        internal void UnloadContent()
        {
            _texture.Dispose();
            _data = null;
            _tileset = null;
            foreach (var ent in Entities)
            {
                if (!(ent is PlayerEntity))
                {
                    ent.UnloadContent();
                }
            }
            Entities.Clear();

            GamePipeline.Write(Pipeline.EVENT_UNLOAD_MAP, Id);
        }

        internal void Draw(SpriteBatch batch, Double2D offset)
        {
            batch.Draw(_texture, new Rectangle(
                (int)offset.X + WorldOffset.X * TILE_SIZE,
                (int)offset.Y + WorldOffset.Y * TILE_SIZE,
                _texture.Width, _texture.Height),
                null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, WorldScreen.SPRITE_LAYER_MAP);
            foreach (var entity in Entities)
            {
                entity.Draw(batch, offset);
            }
        }

        internal void DrawFill(SpriteBatch batch, PlayerEntity player)
        {
            if (_data.fillTileId.HasValue)
            {
                if (_fillTileTexture == null)
                {
                    var tileData = _tileset.GetTile(_data.fillTileId.Value);
                    _fillTileTexture = GenerateFillTileTexture(tileData);
                }

                var subtileOffsetX = -(int)(player.Position.X % 1 * 16);
                var subtileOffsetY = -(int)(player.Position.Y % 1 * 16);

                subtileOffsetX += (int)player.Position.X % 2 * 16;
                subtileOffsetY += (int)player.Position.Y % 2 * 16;

                var targetRect = new Rectangle(subtileOffsetX - 32, subtileOffsetY - 32, 320, 288);
                var sourceRect = new Rectangle(0, 0, 320, 288);
                batch.Draw(_fillTileTexture, targetRect, sourceRect, Color.White, 0f,
                    Vector2.Zero, SpriteEffects.None, WorldScreen.SPRITE_LAYER_MAP_FILL);
            }
        }

        internal void Update()
        {
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].CanBeRemoved)
                {
                    Entities.RemoveAt(i);
                    i--;
                }
                else
                {
                    Entities[i].Update();
                }
            }
        }

        internal MapEventData GetMapEvent(Double2D position)
        {
            return _data.events.FirstOrDefault(e =>
                e.pos[0] == (int)(position.X - WorldOffset.X) &&
                e.pos[1] == (int)(position.Y - WorldOffset.Y));
        }

        internal SubtileInfo? GetSubtileInfo(Double2D position)
        {
            var x = (int)(position.X - WorldOffset.X);
            var y = (int)(position.Y - WorldOffset.Y);
            foreach (var tile in _data.tiles)
            {
                var fromX = tile.pos[0] * 2;
                var fromY = tile.pos[1] * 2;
                var toX = fromX + tile.size[0] * 2 - 1;
                var toY = fromY + tile.size[1] * 2 - 1;

                if (fromX <= x && toX >= x &&
                    fromY <= y && toY >= y)
                {
                    var tileData = _tileset.GetTile(tile.tileId);
                    var normalX = (x - fromX) % 2;
                    var normalY = (y - fromY) % 2;
                    var subtileIndex = normalX + normalY * 2;
                    var subtileData = _tileset.GetSubtile(tileData.subtiles[subtileIndex]);

                    return new SubtileInfo
                    {
                        X = x,
                        Y = y,
                        Behavior = DataHelper.ParseEnum<SubtileBehavior>(subtileData.behavior),
                    };
                }
            }

            return null;
        }

        private Texture2D GenerateFillTileTexture(TileData tileData)
        {
            var tilesetTexture = _tileset.Texture;
            var target = new RenderTarget2D(Controller.GraphicsDevice, 32, 32,
                false, default(SurfaceFormat), DepthFormat.None, 0, RenderTargetUsage.PreserveContents);

            var prevTargets = Controller.GraphicsDevice.GetRenderTargets();

            Controller.GraphicsDevice.SetRenderTarget(target);
            Controller.GraphicsDevice.Clear(Color.Transparent);

            var batch = new SpriteBatch(Controller.GraphicsDevice);
            batch.Begin(samplerState: SamplerState.PointClamp);

            for (var i = 0; i < tileData.subtiles.Length; i++)
            {
                var subtile = _tileset.GetSubtile(tileData.subtiles[i]);
                var posX = 0;
                var posY = 0;
                switch (i)
                {
                    case 1:
                        posX += 16;
                        break;
                    case 2:
                        posY += 16;
                        break;
                    case 3:
                        posX += 16;
                        posY += 16;
                        break;
                }
                var texX = subtile.texture[0] * 16;
                var texY = subtile.texture[1] * 16;

                batch.Draw(tilesetTexture,
                    new Rectangle(posX, posY, 16, 16),
                    new Rectangle(texX, texY, 16, 16),
                    Color.White);
            }

            batch.End();

            Controller.GraphicsDevice.SetRenderTargets(prevTargets);

            return target;
        }

        private void GenerateMapTexture()
        {
            // load tileset texture
            var tilesetTexture = _tileset.Texture;

            // figure out size of map
            var minX = _data.tiles.Min(t => t.pos[0]);
            var minY = _data.tiles.Min(t => t.pos[1]);
            var maxX = _data.tiles.Max(t => t.pos[0] + t.size[0]);
            var maxY = _data.tiles.Max(t => t.pos[1] + t.size[1]);

            var target = new RenderTarget2D(Controller.GraphicsDevice, maxX * 32, maxY * 32,
                false, default(SurfaceFormat), DepthFormat.None, 0, RenderTargetUsage.PreserveContents);

            var prevTargets = Controller.GraphicsDevice.GetRenderTargets();

            Controller.GraphicsDevice.SetRenderTarget(target);
            Controller.GraphicsDevice.Clear(Color.Transparent);

            var batch = new SpriteBatch(Controller.GraphicsDevice);
            batch.Begin(samplerState: SamplerState.PointClamp);

            foreach (var tile in _data.tiles)
            {
                var startX = tile.pos[0] * 32;
                var startY = tile.pos[1] * 32;
                var tileData = _tileset.GetTile(tile.tileId);

                for (var x = 0; x < tile.size[0]; x++)
                {
                    for (var y = 0; y < tile.size[1]; y++)
                    {
                        for (var i = 0; i < tileData.subtiles.Length; i++)
                        {
                            var subtile = _tileset.GetSubtile(tileData.subtiles[i]);
                            var posX = startX + x * 32;
                            var posY = startY + y * 32;
                            switch (i)
                            {
                                case 1:
                                    posX += 16;
                                    break;
                                case 2:
                                    posY += 16;
                                    break;
                                case 3:
                                    posX += 16;
                                    posY += 16;
                                    break;
                            }
                            var texX = subtile.texture[0] * 16;
                            var texY = subtile.texture[1] * 16;

                            batch.Draw(tilesetTexture,
                                new Rectangle(posX, posY, 16, 16),
                                new Rectangle(texX, texY, 16, 16),
                                Color.White);
                        }
                    }
                }
            }

            batch.End();

            Controller.GraphicsDevice.SetRenderTargets(prevTargets);

            _texture = target;
        }
    }
}
