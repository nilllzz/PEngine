﻿using PEngine.Common.Data;
using PEngine.Common.Data.Maps;

namespace PEngine.Creator.Components.Game
{
    internal static class TilesetService
    {
        internal static TilesetData CreateNew(string id, ProjectFileData textureFile)
        {
            var tileset = TilesetData.Create(id);
            tileset.texture = textureFile.id;
            tileset.subtiles = new[]
            {
                new SubtileData
                {
                    id = 0,
                    behavior = DataHelper.UnparseEnum(SubtileBehavior.Floor),
                    texture = new[] { 0, 0 }
                }
            };
            tileset.tiles = new[]
            {
                new TileData
                {
                    id = 0,
                    subtiles = new[] { 0, 0, 0, 0 }
                }
            };
            return tileset;
        }
    }
}
