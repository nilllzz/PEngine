﻿using PEngine.Common;
using PEngine.Common.Data;
using System;
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

            var root = new ProjectTreeNode($"Project '{project.Name}'");

            var maps = new ProjectTreeNode("Maps");
            CreateMapsTree(maps);
            root.Nodes.Add(maps);

            var tilesets = new ProjectTreeNode("Tilesets");
            CreateTilesetsTree(tilesets);
            root.Nodes.Add(tilesets);

            var scripts = new ProjectTreeNode("Scripts");
            root.Nodes.Add(scripts);

            var content = new ProjectTreeNode("Content");
            var textures = new ProjectTreeNode("Textures");
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
            var tileTextureNode = new ProjectTreeNode("Tiles");
            var tileTextures = Project.ActiveProject.GetFiles(ProjectFileType.TextureTileset);
            foreach (var tileTextureFile in tileTextures)
            {
                tileTextureNode.Nodes.Add(new ProjectTreeNode(tileTextureFile));
            }
            parent.Nodes.Add(tileTextureNode);

            var characterTextureNode = new ProjectTreeNode("Characters");
            var characterTextures = Project.ActiveProject.GetFiles(ProjectFileType.TextureCharacter);
            foreach (var characterTextureFile in characterTextures)
            {
                characterTextureNode.Nodes.Add(new ProjectTreeNode(characterTextureFile));
            }
            parent.Nodes.Add(characterTextureNode);
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
                        FileData = projectNode.FileData,
                    });
                }
            }
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
    }
}
