namespace PEngine.Common.Data.Maps
{
    public class MapData : Resource<MapData>
    {
        public string name;
        public string tileset;
        public MapTileData[] tiles;

        protected override string GetDefaultFileName(string id) => $"content/{id}.json";
    }
}
