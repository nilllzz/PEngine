namespace PEngine.Common.Data.Monsters
{
    public class DexEntryData
    {
        // reference to the monster
        public string monsterId;

        public int regionalNumber;
        public string species;
        public decimal height;
        public decimal weight;
        public string text;
        public string[] areas; // map ids
    }

    public class DexData : Resource<DexData>
    {
        public DexEntryData[] entries;

        protected override string GetDefaultFileName(string id) => $"content/{id}.json";
    }
}
