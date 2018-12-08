using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Creator.Helpers;
using System;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectTree : UserControl, IEventBusComponent
    {
        private ProjectEventBus _eventBus;

        public ProjectTree()
        {
            InitializeComponent();
        }

        #region events

        public void SetEventBus(ProjectEventBus eventBus)
        {
            _eventBus = eventBus;
            UnregisterEvents();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _eventBus.FileUpdated += _eventBus_FileUpdated;
        }

        public void UnregisterEvents()
        {
            _eventBus.FileUpdated -= _eventBus_FileUpdated;
        }

        private void _eventBus_FileUpdated(ProjectFileData file)
        {
            // update text
            var node = FindTreeNode(file.id, file.GetFileType(), tree_main.Nodes[0] as ProjectTreeNode);
            node.Text = file.id;
        }

        #endregion

        #region ui

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
                OpenFromNode(projectNode);
            }
        }

        private void tree_main_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree_main.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node is ProjectTreeNode projectNode)
                {
                    if (projectNode.ItemType == ProjectItemType.Folder)
                    {
                        context_containers.Show(Cursor.Position);
                    }
                    else
                    {
                        context_items.Show(Cursor.Position);
                    }
                }
            }
        }

        private void context_items_open_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectTreeNode projectNode)
            {
                OpenFromNode(projectNode);
            }
        }

        private void context_items_reveal_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectTreeNode projectNode &&
                projectNode.ItemType != ProjectItemType.Folder)
            {
                ExplorerHelper.OpenWithFileSelected(projectNode.FilePath);
            }
        }

        private void context_items_exclude_Click(object sender, EventArgs e)
        {

        }

        private void context_containers_reveal_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectTreeNode projectNode &&
                projectNode.ItemType == ProjectItemType.Folder)
            {
                ExplorerHelper.OpenInFolder(projectNode.FilePath);
            }
        }

        #endregion

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

            var root = new ProjectTreeNode($"Project '{project.Name}'",
                Project.ActiveProject.BaseDirectory, true);

            var maps = new ProjectTreeNode("Maps",
                Path.Combine(Project.ActiveProject.BaseDirectory, "data/maps"));
            CreateMapsTree(maps);
            root.Nodes.Add(maps);

            var tilesets = new ProjectTreeNode("Tilesets",
                Path.Combine(Project.ActiveProject.BaseDirectory, "data/tiles"));
            CreateTilesetsTree(tilesets);
            root.Nodes.Add(tilesets);

            var scripts = new ProjectTreeNode("Scripts",
                Path.Combine(Project.ActiveProject.BaseDirectory, "data/scripts"));
            root.Nodes.Add(scripts);

            var content = new ProjectTreeNode("Content",
                Path.Combine(Project.ActiveProject.BaseDirectory, "content"));
            var textures = new ProjectTreeNode("Textures",
                Path.Combine(Project.ActiveProject.BaseDirectory, "content/textures"));
            CreateTexturesTree(textures);
            content.Nodes.Add(textures);
            root.Nodes.Add(content);

            tree_main.Nodes.Add(root);
            root.Expand();
        }

        private void CreateMapsTree(TreeNode parent)
        {
            var mapFiles = Project.ActiveProject.GetFiles(ProjectFileType.Map);
            foreach (var mapFile in mapFiles)
            {
                parent.Nodes.Add(new ProjectTreeNode(mapFile));
            }
        }

        private void CreateTilesetsTree(TreeNode parent)
        {
            var tilesetFiles = Project.ActiveProject.GetFiles(ProjectFileType.Tileset);
            foreach (var tilesetFile in tilesetFiles)
            {
                parent.Nodes.Add(new ProjectTreeNode(tilesetFile));
            }
        }

        private void CreateTexturesTree(TreeNode parent)
        {
            var tileTextureNode = new ProjectTreeNode("Tiles",
                Path.Combine(Project.ActiveProject.BaseDirectory, "content/textures/tiles"));
            var tileTextures = Project.ActiveProject.GetFiles(ProjectFileType.TextureTileset);
            foreach (var tileTextureFile in tileTextures)
            {
                tileTextureNode.Nodes.Add(new ProjectTreeNode(tileTextureFile));
            }
            parent.Nodes.Add(tileTextureNode);

            var characterTextureNode = new ProjectTreeNode("Characters",
                Path.Combine(Project.ActiveProject.BaseDirectory, "content/textures/characters"));
            var characterTextures = Project.ActiveProject.GetFiles(ProjectFileType.TextureCharacter);
            foreach (var characterTextureFile in characterTextures)
            {
                characterTextureNode.Nodes.Add(new ProjectTreeNode(characterTextureFile));
            }
            parent.Nodes.Add(characterTextureNode);
        }

        private ProjectTreeNode FindTreeNode(string id, ProjectFileType filetype, ProjectTreeNode node)
        {
            if (node.FileData != null && node.FileData.id == id && node.FileData.GetFileType() == filetype)
            {
                return node;
            }
            foreach (var subnode in node.Nodes)
            {
                if (subnode is ProjectTreeNode projNode)
                {
                    var result = FindTreeNode(id, filetype, projNode);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        private void OpenFromNode(ProjectTreeNode projectNode)
        {
            if (projectNode.ItemType != ProjectItemType.Folder)
            {
                _eventBus.RequestItemOpen(new ProjectItem
                {
                    ItemType = projectNode.ItemType,
                    FileData = projectNode.FileData,
                });
            }
        }
    }
}
