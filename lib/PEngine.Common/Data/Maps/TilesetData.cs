namespace PEngine.Common.Data.Maps
{
    public class TilesetData : Resource<TilesetData>
    {
        public string id;
        public string texture;
        public SubtileData[] subtiles;
        public TileData[] tiles;
    }
}
