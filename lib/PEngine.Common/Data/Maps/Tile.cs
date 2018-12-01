namespace PEngine.Common.Data.Maps
{
    public class Tile : Resource<Tile>
    {
        protected override bool IsSingleFileSource => true;
        protected override string DataSource => "data/tiles";
        protected override string IdField { get => id; set => id = value; }

        public string id;
    }
}
