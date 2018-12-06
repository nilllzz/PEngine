using PEngine.Common;
using PEngine.Common.Data.Maps;
using System;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectTree : UserControl
    {
        private const int ICON_FOLDER_CLOSED = 1;
        private const int ICON_FOLDER_OPEN = 2;

        private class ProjectTreeNode : TreeNode
        {
            private readonly int _collapsedIconIndex;
            private readonly int _expandedIconIndex;

            public ProjectTreeNode(string text, int collapsedIconIndex, int expandedIconIndex = -1)
                : base(text)
            {
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

        public ProjectTree()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Project.ActiveProject != null)
            {
                CreateInitialTree();
            }
        }

        private void CreateInitialTree()
        {
            tree_main.AfterExpand += Tree_main_AfterExpand;
            tree_main.AfterCollapse += Tree_main_AfterCollapse;

            var project = Project.ActiveProject;

            var root = new ProjectTreeNode($"Project '{project.Name}'", ICON_FOLDER_CLOSED, ICON_FOLDER_OPEN);

            var maps = new ProjectTreeNode("Maps", ICON_FOLDER_CLOSED, ICON_FOLDER_OPEN);
            CreateMapsTree(maps);
            root.Nodes.Add(maps);

            var tilesets = new ProjectTreeNode("Tilesets", ICON_FOLDER_CLOSED, ICON_FOLDER_OPEN);
            CreateTilesetsTree(tilesets);
            root.Nodes.Add(tilesets);

            var scripts = new ProjectTreeNode("Scripts", ICON_FOLDER_CLOSED, ICON_FOLDER_OPEN);
            root.Nodes.Add(scripts);

            tree_main.Nodes.Add(root);
            root.Expand();
        }

        private void CreateMapsTree(TreeNode parent)
        {
            var mapFiles = MapData.GetAllSourceFiles();
            foreach (var mapFile in mapFiles)
            {
                parent.Nodes.Add(new TreeNode
                {
                    Text = Path.GetFileName(mapFile),
                    ImageKey = "file_map",
                    SelectedImageKey = "file_map",
                });
            }
        }

        private void CreateTilesetsTree(TreeNode parent)
        {
            var tilesetFiles = TilesetData.GetAllSourceFiles();
            foreach (var tilesetFile in tilesetFiles)
            {
                parent.Nodes.Add(new TreeNode
                {
                    Text = Path.GetFileName(tilesetFile)
                });
            }
        }

        private void Tree_main_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ((ProjectTreeNode)e.Node).OnCollapsed();
        }

        private void Tree_main_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ((ProjectTreeNode)e.Node).OnExpanded();
        }
    }
}
