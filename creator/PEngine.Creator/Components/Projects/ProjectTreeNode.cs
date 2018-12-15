using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal abstract class ProjectTreeNode : TreeNode
    {
        protected string _collapsedIconKey;
        protected string _expandedIconKey;

        protected ProjectTreeNode() { }

        internal void OnExpanded()
        {
            ImageKey = _expandedIconKey;
            SelectedImageKey = ImageKey;
        }

        internal void OnCollapsed()
        {
            ImageKey = _collapsedIconKey;
            SelectedImageKey = ImageKey;
        }
    }
}
