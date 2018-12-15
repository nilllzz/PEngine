using PEngine.Common.Data;

namespace PEngine.Creator.Components.Projects
{
    internal class ProjectFileTreeNode : ProjectTreeNode
    {
        public ProjectFileData File { get; }

        public ProjectFileTreeNode(ProjectFileData file)
        {
            File = file;
            UpdateText();

            _collapsedIconKey = FileIconProvider.GetIconKey(File.FileType);

            _expandedIconKey = _collapsedIconKey;
            ImageKey = _collapsedIconKey;
            SelectedImageKey = ImageKey;
        }

        public void UpdateText()
        {
            Text = File.name;
        }
    }
}
