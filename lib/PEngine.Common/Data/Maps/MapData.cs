namespace PEngine.Common.Data.Maps
{
    public class MapData : Resource<MapData>
    {
        public string id;
        public string tileset;
        public MapTileData[] tiles;
    }
}
