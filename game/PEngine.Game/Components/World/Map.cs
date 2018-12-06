using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Common.Data.Maps;
using PEngine.Game.Components.World.Entities;
using PEngine.Game.Screens.World;
using System.Collections.Generic;
using System.Linq;
using static Core;

namespace PEngine.Game.Components.World
{
    class Map
    {
        public const int TILE_SIZE = 16;

        private readonly string _id;
        private MapData _data;
        private Tileset _tileset;
        private Texture2D _texture;

        public readonly List<Entity> Entities = new List<Entity>();

        public Map(string id)
        {
            _id = id;
        }

        public void LoadContent()
        {
            _data = MapData.FetchOne(_id);

            _tileset = new Tileset(_data.tileset);
            _tileset.LoadContent();

            GenerateMapTexture();

            foreach (var entity in Entities)
            {
                entity.LoadContent();
            }
        }

        public void Draw(SpriteBatch batch, Double2D offset)
        {
            batch.Draw(_texture, new Rectangle((int)offset.X, (int)offset.Y, _texture.Width, _texture.Height),
                null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, WorldScreen.SPRITE_LAYER_MAP);
            foreach (var entity in Entities)
            {
                entity.Draw(batch, offset);
            }
        }

        public void Update()
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
