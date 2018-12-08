using PEngine.Common.Data;
using PEngine.Creator.Components.Game;

namespace PEngine.Creator.Components.Projects
{
    public struct ProjectItem
    {
        public ProjectFileData FileData;
        public ProjectItemType ItemType;

        public string FilePath => ResourceManager.GetFilePath(FileData);
        public string Identifier => FileData.type + "|" + FileData.path;
    }
}
