using PEngine.Common.Data.Maps;
using System.Collections.Generic;
using System.Linq;

namespace PEngine.Creator.Components.Projects
{
    internal static class Optimizer
    {
        // expands all size fields to just 1x1 tiles
        internal static void ExpandMap(MapData map)
        {
            if (map.tiles.All(t => t.size[0] == 1 && t.size[1] == 1))
            {
                // nothing to expand
                return;
            }

            var newTiles = new List<MapTileData>();
            foreach (var tile in map.tiles)
            {
                if (tile.size[0] > 1 || tile.size[1] > 1)
                {
                    for (var y = 0; y < tile.size[1]; y++)
                    {
                        for (var x = 0; x < tile.size[0]; x++)
                        {
                            if (x > 0 || y > 0)
                            {
                                var newTile = new MapTileData
                                {
                                    pos = new[] { tile.pos[0] + x, tile.pos[1] + y },
                                    size = new[] { 1, 1 },
                                    tileId = tile.tileId
                                };
                                newTiles.Add(newTile);
                            }
                        }
                    }
                    tile.size[0] = 1;
                    tile.size[1] = 1;
                }
            }
            map.tiles = map.tiles.Concat(newTiles).ToArray();
        }

        internal static void OptimizeMap(MapData map)
        {
            // break the map up first
            ExpandMap(map);

            // tries to group chunks of tiles together
            // sort by position x - to +, then y - to +
            var maxX = map.tiles.Max(t => t.pos[0]);
            var tiles = map.tiles.OrderBy(t => t.pos[0] + t.pos[1] * (maxX + 1)).ToList();
            var optimized = new List<MapTileData>();

            while (tiles.Count > 0)
            {
                var tile = tiles[0];
                // walk along x and find line of tiles
                var foundX = 0;
                {
                    var walker = tile.pos[0];
                    MapTileData foundTile = null;
                    do
                    {
                        walker++;
                        foundTile = TryFindTileAt(tiles, walker, tile.pos[1], tile.tileId);
                        if (foundTile != null)
                        {
                            foundX++;
                        }
                    } while (foundTile != null);
                }
                // walk along y and find line of tiles
                var foundY = 0;
                {
                    var walker = tile.pos[1];
                    MapTileData foundTile = null;
                    do
                    {
                        walker++;
                        foundTile = TryFindTileAt(tiles, tile.pos[0], walker, tile.tileId);
                        if (foundTile != null)
                        {
                            foundY++;
                        }
                    } while (foundTile != null);
                }

                // just a lonely, single tile?
                if (foundX == 0 && foundY == 0)
                {
                    optimized.Add(tile);
                    tiles.Remove(tile);
                    continue;
                }

                // depending on which direction has more tiles, 
                // try and find rows of those tiles in the opposite direction
                var rows = 0;
                var cols = 0;

                if (foundX >= foundY)
                {
                    rows = 1;
                    cols = foundX + 1;

                    var positions = Enumerable.Range(tile.pos[0], foundX + 1); // +1 for the starting tile
                    var walker = tile.pos[1] + 1;
                    while (positions.All(p => TryFindTileAt(tiles, p, walker, tile.tileId) != null))
                    {
                        walker++;
                        rows++;
                    }
                }
                else
                {
                    cols = 1;
                    rows = foundY + 1;
                    var positions = Enumerable.Range(tile.pos[1], foundY + 1); // +1 for the starting tile
                    var walker = tile.pos[0] + 1;
                    while (positions.All(p => TryFindTileAt(tiles, walker, p, tile.tileId) != null))
                    {
                        walker++;
                        cols++;
                    }
                }

                // walk along captured rows/cols remove them from the list
                // then add the grouped tile to the new list
                for (var x = 0; x < cols; x++)
                {
                    for (var y = 0; y < rows; y++)
                    {
                        var toBeRemovedTile = TryFindTileAt(tiles, x + tile.pos[0], y + tile.pos[1], tile.tileId);
                        if (toBeRemovedTile != null)
                        {
                            tiles.Remove(toBeRemovedTile);
                        }
                    }
                }
                tile.size = new[] { cols, rows };
                optimized.Add(tile);
            }

            map.tiles = optimized.ToArray();
        }

        private static MapTileData TryFindTileAt(IEnumerable<MapTileData> tiles, int x, int y, int tileId)
        {
            return tiles.FirstOrDefault(t => t.pos[0] == x && t.pos[1] == y && t.tileId == tileId);
        }
    }
}
