using PEngine.Common;
using PEngine.Common.Data;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    class ProjectTreeNode : TreeNode
    {
        private const int ICON_DOCUMENT = 0;
        private const int ICON_FOLDER_CLOSED = 1;
        private const int ICON_FOLDER_OPEN = 2;
        private const int ICON_MAP = 3;
        private const int ICON_IMAGE = 4;
        private const int ICON_TILESET = 5;

        private readonly string _folderPath = null;
        private readonly int _collapsedIconIndex;
        private readonly int _expandedIconIndex;

        public ProjectItemType ItemType { get; }
        public ProjectFileData FileData { get; }
        public string FilePath
        {
            get
            {
                if (ItemType == ProjectItemType.Folder)
                {
                    return _folderPath;
                }
                else
                {
                    return Path.Combine(Project.ActiveProject.BaseDirectory, FileData.path);
                }
            }
        }

        public ProjectTreeNode(string folderText, string path)
            : base(folderText)
        {
            ItemType = ProjectItemType.Folder;
            FileData = null;

            _folderPath = path;
            _collapsedIconIndex = ICON_FOLDER_CLOSED;
            _expandedIconIndex = ICON_FOLDER_OPEN;

            ImageIndex = _collapsedIconIndex;
            SelectedImageIndex = ImageIndex;
        }

        public ProjectTreeNode(ProjectFileData fileData)
            : base(fileData.id)
        {
            FileData = fileData;

            switch (fileData.GetFileType())
            {
                case ProjectFileType.Map:
                    _collapsedIconIndex = ICON_MAP;
                    ItemType = ProjectItemType.Map;
                    break;
                case ProjectFileType.Tileset:
                    _collapsedIconIndex = ICON_TILESET;
                    ItemType = ProjectItemType.Tileset;
                    break;
                case ProjectFileType.TextureTileset:
                case ProjectFileType.TextureCharacter:
                    _collapsedIconIndex = ICON_IMAGE;
                    ItemType = ProjectItemType.Texture;
                    break;
            }

            _expandedIconIndex = _collapsedIconIndex;
            ImageIndex = _collapsedIconIndex;
            SelectedImageIndex = ImageIndex;
        }

        public void OnExpanded()
        {
            ImageIndex = _expandedIconIndex;
            SelectedImageIndex = ImageIndex;
        }

        public void OnCollapsed()
        {
            ImageIndex = _collapsedIconIndex;
            SelectedImageIndex = ImageIndex;
        }
    }
}
