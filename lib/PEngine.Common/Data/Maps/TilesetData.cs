namespace PEngine.Common.Data.Maps
{
    public class TilesetData : Resource<TilesetData>
    {
        protected override string DataSource => "data/tiles";
        protected override string IdField { get => id; set => id = value; }

        public string id;
        public string texture;
        public SubtileData[] subtiles;
        public TileData[] tiles;
    }
}
