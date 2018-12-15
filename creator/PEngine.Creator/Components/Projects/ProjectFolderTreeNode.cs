using PEngine.Common.Data;

namespace PEngine.Creator.Components.Projects
{
    internal class ProjectFolderTreeNode : ProjectTreeNode
    {
        public ProjectFolderData Folder { get; }
        public bool IsNewNode { get; set; } = false;

        public ProjectFolderTreeNode(ProjectFolderData folder)
        {
            Folder = folder;
            UpdateText();

            if (folder.id == null)
            {
                _collapsedIconKey = FileIconProvider.ICON_PROJECT_CLOSED;
                _expandedIconKey = FileIconProvider.ICON_PROJECT_OPEN;
            }
            else
            {
                _collapsedIconKey = FileIconProvider.ICON_FOLDER_CLOSED;
                _expandedIconKey = FileIconProvider.ICON_FOLDER_OPEN;
            }

            ImageKey = _collapsedIconKey;
            SelectedImageKey = ImageKey;
        }

        public void UpdateText()
        {
            Text = Folder.name;
        }
    }
}
