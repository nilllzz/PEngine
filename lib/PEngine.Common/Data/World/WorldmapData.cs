namespace PEngine.Common.Data.World
{
    public class WorldmapData : Resource<WorldmapData>
    {
        protected override string GetDefaultFileName(string id) => $"content/{id}.json";

        public WorldmapEntryData[] entries;
    }
}
