using PEngine.Common.Data;
using PEngine.Creator.Components.Game;

namespace PEngine.Creator.Components.Projects
{
    internal struct ProjectItem
    {
        internal ProjectFileData FileData;
        internal ProjectItemType ItemType;

        internal string FilePath => ResourceManager.GetFilePath(FileData);
        internal string Identifier => FileData.type + "|" + FileData.path;
    }
}
