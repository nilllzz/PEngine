namespace PEngine.Common.Data
{
    public sealed class ProjectFolderData
    {
        public string name; // display name
        public string id;
        public string parentId;

        public override string ToString()
        {
            // debug info
            return $"Folder {name} ({id})";
        }
    }
}
