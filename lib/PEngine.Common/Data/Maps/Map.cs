namespace PEngine.Common.Data.Maps
{
    public class Map : Resource<Map>
    {
        protected override string DataSource => "data/maps";
        protected override string IdField { get => id; set => id = value; }

        public string id;
        public string someValue;
    }
}
