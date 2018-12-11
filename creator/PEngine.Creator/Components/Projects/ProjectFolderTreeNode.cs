using PEngine.Common.Data;

namespace PEngine.Creator.Components.Projects
{
    internal class ProjectFolderTreeNode : ProjectTreeNode
    {
        public ProjectFolderData Folder { get; }
        public bool IsNewNode { get; set; } = false;

        public ProjectFolderTreeNode(ProjectFolderData folder)
            : base(folder.name)
        {
            Folder = folder;

            if (folder.id == null)
            {
                _collapsedIconIndex = ICON_PROJECT_CLOSED;
                _expandedIconIndex = ICON_PROJECT_OPEN;
            }
            else
            {
                _collapsedIconIndex = ICON_FOLDER_CLOSED;
                _expandedIconIndex = ICON_FOLDER_OPEN;
            }

            ImageIndex = _collapsedIconIndex;
            SelectedImageIndex = ImageIndex;
        }

        public void UpdateText()
        {
            Text = Folder.name;
        }
    }
}
