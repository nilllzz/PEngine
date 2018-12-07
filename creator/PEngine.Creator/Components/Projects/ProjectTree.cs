using PEngine.Common;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using System;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectTree : UserControl
    {
        private ProjectEventBus _eventBus;

        public ProjectTree()
        {
            InitializeComponent();
        }

        public void SetEventBus(ProjectEventBus eventBus)
        {
            _eventBus = eventBus;
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

            var root = new ProjectTreeNode($"Project '{project.Name}'", ProjectItemType.Folder, null);

            var maps = new ProjectTreeNode("Maps", ProjectItemType.Folder, null);
            CreateMapsTree(maps);
            root.Nodes.Add(maps);

            var tilesets = new ProjectTreeNode("Tilesets", ProjectItemType.Folder, null);
            CreateTilesetsTree(tilesets);
            root.Nodes.Add(tilesets);

            var scripts = new ProjectTreeNode("Scripts", ProjectItemType.Folder, null);
            root.Nodes.Add(scripts);

            var content = new ProjectTreeNode("Content", ProjectItemType.Folder, null);
            var textures = new ProjectTreeNode("Textures", ProjectItemType.Folder, null);
            CreateTexturesTree(textures);
            content.Nodes.Add(textures);
            root.Nodes.Add(content);

            tree_main.Nodes.Add(root);
            root.Expand();
        }

        private void CreateMapsTree(TreeNode parent)
        {
            var mapFiles = MapData.GetAllSourceFiles();
            foreach (var mapFile in mapFiles)
            {
                parent.Nodes.Add(new ProjectTreeNode(
                    Path.GetFileName(mapFile),
                    ProjectItemType.Map,
                    mapFile));
            }
        }

        private void CreateTilesetsTree(TreeNode parent)
        {
            var tilesetFiles = TilesetData.GetAllSourceFiles();
            foreach (var tilesetFile in tilesetFiles)
            {
                parent.Nodes.Add(new ProjectTreeNode(
                    Path.GetFileName(tilesetFile),
                    ProjectItemType.Tileset,
                    tilesetFile));
            }
        }

        private void CreateTexturesTree(TreeNode parent)
        {
            foreach (var subfolder in new[] { "Characters", "Tiles" })
            {
                var subNode = new ProjectTreeNode(subfolder, ProjectItemType.Folder, null);
                var subfolderPath = subfolder.ToLower();
                var files = ResourceManager.GetTextureFiles(subfolderPath);
                foreach (var file in files)
                {
                    subNode.Nodes.Add(new ProjectTreeNode(
                        Path.GetFileName(file),
                        ProjectItemType.Texture,
                        file));
                }
                parent.Nodes.Add(subNode);
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

        private void tree_main_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is ProjectTreeNode projectNode)
            {
                if (projectNode.ItemType != ProjectItemType.Folder)
                {
                    _eventBus.RequestItemOpen(new ProjectItem
                    {
                        ItemType = projectNode.ItemType,
                        FilePath = projectNode.FilePath,
                    });
                }
            }
        }
    }
}
