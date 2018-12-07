namespace PEngine.Creator.Components.Projects
{
    public struct ProjectItem
    {
        public ProjectItemType ItemType;
        public string FilePath;

        public string Identifier => ItemType.ToString() + "|" + FilePath;
    }
}
