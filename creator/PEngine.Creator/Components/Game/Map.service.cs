using PEngine.Common;
using PEngine.Common.Data.Maps;
using System;
using System.Drawing;
using System.Linq;

namespace PEngine.Creator.Components.Game
{
    internal static class MapService
    {
        internal static Rectangle GetMapBounds(MapData data)
        {
            var minX = Math.Min(0, data.tiles.Min(t => t.pos[0]));
            var minY = Math.Min(0, data.tiles.Min(t => t.pos[1]));
            var maxX = data.tiles.Max(t => t.pos[0] + t.size[0]);
            var maxY = data.tiles.Max(t => t.pos[1] + t.size[1]);
            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        internal static Bitmap GenerateTexture(MapData data)
        {
            // load resources
            var tilesetFile = Project.ActiveProject.GetFile(data.tileset);
            var tileset = TilesetData.Load(tilesetFile.path);
            var texture = ResourceManager.GetTilesetTexture(tileset).Texture;

            // generate map
            var bounds = GetMapBounds(data);
            var tileOffset = new Point(0, 0);
            if (bounds.X < 0)
            {
                tileOffset.X = -bounds.X * 32;
            }
            if (bounds.Y < 0)
            {
                tileOffset.Y = -bounds.Y * 32;
            }

            var map = new Bitmap(bounds.Width * 32, bounds.Height * 32);
            using (var g = Graphics.FromImage(map))
            {
                foreach (var tile in data.tiles)
                {
                    var tileData = tileset.tiles.First(t => t.id == tile.tileId);
                    for (var y = 0; y < tile.size[1]; y++)
                    {
                        for (var x = 0; x < tile.size[0]; x++)
                        {
                            var tilePosX = (tile.pos[0] + x) * 32;
                            var tilePosY = (tile.pos[1] + y) * 32;

                            for (var i = 0; i < tileData.subtiles.Length; i++)
                            {
                                var subtileId = tileData.subtiles[i];
                                var subtileData = tileset.subtiles.First(t => t.id == subtileId);

                                var subtileOffsetX = i % 2 * 16;
                                var subtileOffsetY = i > 1 ? 16 : 0;

                                g.DrawImage(texture, new Rectangle(
                                    tilePosX + subtileOffsetX + tileOffset.X,
                                    tilePosY + subtileOffsetY + tileOffset.Y,
                                    16, 16), new Rectangle(
                                    subtileData.texture[0] * 16,
                                    subtileData.texture[1] * 16,
                                    16, 16), GraphicsUnit.Pixel);
                            }
                        }
                    }
                }
            }

            return map;
        }

        internal static void PlaceTile(MapData map, MapTileData tile)
        {
            // Be sure to expand the map before using this function!
            var tiles = map.tiles.ToList();

            var existingTile = map.tiles.FirstOrDefault(t => t.pos[0] == tile.pos[0] && t.pos[1] == tile.pos[1]);
            if (existingTile != null)
            {
                tiles.Remove(existingTile);
            }

            tiles.Add(tile);
            map.tiles = tiles.ToArray();
        }

        internal static void ClearTile(MapData map, Point location)
        {
            // Be sure to expand the map before using this function!
            var tiles = map.tiles.ToList();

            var existingTile = map.tiles.FirstOrDefault(t => t.pos[0] == location.X && t.pos[1] == location.Y);
            if (existingTile != null)
            {
                tiles.Remove(existingTile);
            }
            map.tiles = tiles.ToArray();
        }

        internal static MapHealthStatus CheckHealth(MapData data)
        {
            // check if the tileset exists
            // check if all tiles exist in their tileset
            var tilesetFile = Project.ActiveProject.GetFile(data.tileset);
            if (tilesetFile == null)
            {
                return MapHealthStatus.MissingTileset;
            }

            var tileset = TilesetData.Load(tilesetFile.path);
            foreach (var tile in data.tiles)
            {
                if (!tileset.tiles.Any(t => t.id == tile.tileId))
                {
                    return MapHealthStatus.InvalidTileIdUsed;
                }
            }

            return MapHealthStatus.Healthy;
        }

        internal static MapData CreateNew(string id, TilesetData tileset, string name)
        {
            var map = MapData.Create(id);
            map.tileset = tileset.id;
            map.name = name;

            // generate a single starting tile
            if (tileset.tiles.Length > 0)
            {
                var tile = tileset.tiles[0];
                map.tiles = new[] {
                    new MapTileData
                    {
                        tileId = tile.id,
                        pos = new[] { 0, 0 },
                        size = new[] { 1, 1 },
                    }
                };
            }

            return map;
        }
    }
}
