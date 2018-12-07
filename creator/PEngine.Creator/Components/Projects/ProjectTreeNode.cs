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

        private readonly int _collapsedIconIndex;
        private readonly int _expandedIconIndex;

        public ProjectItemType ItemType { get; }
        public string FilePath { get; }

        public ProjectTreeNode(string text, ProjectItemType itemType, string filePath)
            : base(text)
        {
            ItemType = itemType;
            FilePath = filePath;

            var collapsedIconIndex = ICON_DOCUMENT;
            var expandedIconIndex = -1;
            switch (ItemType)
            {
                case ProjectItemType.Folder:
                    collapsedIconIndex = ICON_FOLDER_CLOSED;
                    expandedIconIndex = ICON_FOLDER_OPEN;
                    break;
                case ProjectItemType.Map:
                    collapsedIconIndex = ICON_MAP;
                    break;
                case ProjectItemType.Tileset:
                    collapsedIconIndex = ICON_DOCUMENT;
                    break;
                case ProjectItemType.Texture:
                    collapsedIconIndex = ICON_IMAGE;
                    break;
            }

            _collapsedIconIndex = collapsedIconIndex;
            if (expandedIconIndex == -1)
            {
                _expandedIconIndex = collapsedIconIndex;
            }
            else
            {
                _expandedIconIndex = expandedIconIndex;
            }
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
