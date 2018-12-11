namespace PEngine.Common.Data.Maps
{
    public class TilesetData : Resource<TilesetData>
    {
        public string texture;
        public SubtileData[] subtiles;
        public TileData[] tiles;

        protected override string GetDefaultFileName(string id) => $"content/{id}.json";
    }
}
