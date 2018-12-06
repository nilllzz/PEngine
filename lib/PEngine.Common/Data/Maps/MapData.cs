namespace PEngine.Common.Data.Maps
{
    public class MapData : Resource<MapData>
    {
        protected override string DataSource => "data/maps";
        protected override string IdField { get => id; set => id = value; }

        public string id;
        public string tileset;
        public MapTileData[] tiles;
    }
}
