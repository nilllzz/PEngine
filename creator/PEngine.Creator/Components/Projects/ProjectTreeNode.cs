using PEngine.Common.Data;
using PEngine.Creator.Components.Game;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal abstract class ProjectTreeNode : TreeNode
    {
        protected const int ICON_DOCUMENT = 0;
        protected const int ICON_FOLDER_CLOSED = 1;
        protected const int ICON_FOLDER_OPEN = 2;
        protected const int ICON_MAP = 3;
        protected const int ICON_IMAGE = 4;
        protected const int ICON_TILESET = 5;
        protected const int ICON_PROJECT_CLOSED = 6;
        protected const int ICON_PROJECT_OPEN = 7;

        protected int _collapsedIconIndex;
        protected int _expandedIconIndex;

        protected ProjectTreeNode() { }

        //private readonly string _folderPath = null;

        //internal ProjectItemType ItemType { get; }
        //internal ProjectFileData FileData { get; }
        //internal string FilePath
        //{
        //    get
        //    {
        //        if (ItemType == ProjectItemType.Folder)
        //        {
        //            return _folderPath;
        //        }
        //        else
        //        {
        //            return ResourceManager.GetFilePath(FileData);
        //        }
        //    }
        //}

        //internal ProjectTreeNode(string folderText, string path, bool isProject = false)
        //    : base(folderText)
        //{
        //    ItemType = ProjectItemType.Folder;
        //    FileData = null;

        //    _folderPath = path;
        //    if (isProject)
        //    {
        //        _collapsedIconIndex = ICON_PROJECT_CLOSED;
        //        _expandedIconIndex = ICON_PROJECT_OPEN;
        //    }
        //    else
        //    {
        //        _collapsedIconIndex = ICON_FOLDER_CLOSED;
        //        _expandedIconIndex = ICON_FOLDER_OPEN;
        //    }

        //    ImageIndex = _collapsedIconIndex;
        //    SelectedImageIndex = ImageIndex;
        //}

        //internal ProjectTreeNode(ProjectFileData fileData)
        //    : base(fileData.id)
        //{
        //    FileData = fileData;

        //    switch (fileData.GetFileType())
        //    {
        //        case ProjectFileType.Map:
        //            _collapsedIconIndex = ICON_MAP;
        //            ItemType = ProjectItemType.Map;
        //            break;
        //        case ProjectFileType.Tileset:
        //            _collapsedIconIndex = ICON_TILESET;
        //            ItemType = ProjectItemType.Tileset;
        //            break;
        //        case ProjectFileType.TextureTileset:
        //        case ProjectFileType.TextureCharacter:
        //            _collapsedIconIndex = ICON_IMAGE;
        //            ItemType = ProjectItemType.Texture;
        //            break;
        //    }

        //    _expandedIconIndex = _collapsedIconIndex;
        //    ImageIndex = _collapsedIconIndex;
        //    SelectedImageIndex = ImageIndex;
        //}

        internal void OnExpanded()
        {
            ImageIndex = _expandedIconIndex;
            SelectedImageIndex = ImageIndex;
        }

        internal void OnCollapsed()
        {
            ImageIndex = _collapsedIconIndex;
            SelectedImageIndex = ImageIndex;
        }
    }
}
