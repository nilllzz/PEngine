using PEngine.Common.Data;
using PEngine.Common.Data.Maps;

namespace PEngine.Creator.Components.Game.Tilesets
{
    internal static class TilesetService
    {
        internal const int MAX_TILES_IN_SET = 128;
        internal const int MAX_SUBTILES_IN_SET = 128;

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
