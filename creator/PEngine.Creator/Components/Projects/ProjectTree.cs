﻿using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Creator.Forms.New;
using PEngine.Creator.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectTree : UserControl, IEventBusComponent
    {
        private ProjectEventBus _eventBus;
        private string[] _expandedFolders = new string[0];

        public ProjectTree()
        {
            InitializeComponent();

            tree_main.TreeViewNodeSorter = new ProjectTreeNodeComparer();
        }

        #region events

        internal void SetEventBus(ProjectEventBus eventBus)
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
            var node = FindFileNode(file);
            if (node != null)
            {
                node.UpdateText();
            }
        }

        #endregion

        #region ui

        private void Tree_main_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            UpdateExpandState();
            ((ProjectTreeNode)e.Node).OnCollapsed();
        }

        private void Tree_main_AfterExpand(object sender, TreeViewEventArgs e)
        {
            UpdateExpandState();
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
                if (e.Node is ProjectFileTreeNode fileNode)
                {
                    context_files.Show(Cursor.Position);
                }
                else if (e.Node is ProjectFolderTreeNode folderNode)
                {
                    context_folders.Show(Cursor.Position);
                }
            }
        }

        private void context_files_open_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectTreeNode projectNode)
            {
                OpenFromNode(projectNode);
            }
        }

        private void context_files_reveal_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectFileTreeNode fileNode)
            {
                ExplorerHelper.OpenWithFileSelected(fileNode.File.FilePath);
            }
        }

        private void context_files_exclude_Click(object sender, EventArgs e)
        {

        }

        private void context_folders_reveal_Click(object sender, EventArgs e)
        {
            ExplorerHelper.OpenInFolder(Project.ActiveProject.BaseDirectory);
        }

        private void context_files_delete_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectFileTreeNode fileNode)
            {
                var file = fileNode.File;
                var result = MessageBox.Show($"'{file.path}' will be deleted permanently.",
                    "Delete File", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    ProjectService.DeleteFile(file);
                    _eventBus.DeletedFile(file);
                    CreateTree();
                }
            }
        }

        private void tool_collapse_Click(object sender, EventArgs e)
        {
            tree_main.CollapseAll();
        }

        private void tool_refresh_Click(object sender, EventArgs e)
        {
            CreateTree();
        }

        private void context_folders_add_folder_Click(object sender, EventArgs e)
        {
            var folderNode = GetSelectedFolderNode();

            var newFolder = ProjectService.CreateFolder(Project.ActiveProject,
                "New Folder", folderNode.Folder);
            var newFolderNode = new ProjectFolderTreeNode(newFolder);
            newFolderNode.IsNewNode = true;
            folderNode.Nodes.Add(newFolderNode);
            folderNode.Expand();

            tree_main.SelectedNode = newFolderNode;
            newFolderNode.BeginEdit();
        }

        private void context_folder_add_map_Click(object sender, EventArgs e)
        {
            var form = new NewMapForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var map = form.CreatedMapData;
                CreateResource(map, map.name, ProjectFileType.Map);
            }
        }

        private void context_folders_delete_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectFolderTreeNode folderNode)
            {
                var result = MessageBox.Show($"'{folderNode.Folder.name}' and all its content will be deleted permanently.",
                    "Delete Folder", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    ProjectService.DeleteFolder(folderNode.Folder);
                    CreateTree();
                }
            }
        }

        private void context_folders_rename_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectFolderTreeNode folderNode)
            {
                folderNode.BeginEdit();
            }
        }

        private void context_files_rename_Click(object sender, EventArgs e)
        {
            if (tree_main.SelectedNode is ProjectFileTreeNode fileNode)
            {
                fileNode.BeginEdit();
            }
        }

        private void context_folders_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // do not enable editing for the project folder node
            var enableEditing = tree_main.SelectedNode is ProjectFolderTreeNode folderNode && folderNode.Folder.id != null;
            context_folders_rename.Enabled = enableEditing;
            context_folders_delete.Enabled = enableEditing;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Project.ActiveProject != null)
            {
                CreateTree();
            }
        }

        private void CreateTree()
        {
            var previousExpandState = _expandedFolders;
            var previousSelectedNode = tree_main.SelectedNode;

            tree_main.AfterExpand -= Tree_main_AfterExpand;
            tree_main.AfterCollapse -= Tree_main_AfterCollapse;
            tree_main.Nodes.Clear();

            var project = Project.ActiveProject;

            // create folder nodes
            var root = new ProjectFolderTreeNode(new ProjectFolderData
            {
                id = null,
                name = $"Project '{project.Name}'",
                parentId = null,
            });

            void createChildFolders(ProjectFolderTreeNode node)
            {
                var folder = node.Folder;
                var childFolders = project.Folders.Where(f => f.parentId == folder.id);
                foreach (var childFolder in childFolders)
                {
                    var childNode = new ProjectFolderTreeNode(childFolder);
                    node.Nodes.Add(childNode);
                    createChildFolders(childNode);
                }
            }

            createChildFolders(root);
            tree_main.Nodes.Add(root);

            // create file nodes
            foreach (var file in project.Files)
            {
                var folderNode = FindFolderNode(file.folderId);
                if (folderNode != null)
                {
                    var fileNode = new ProjectFileTreeNode(file);
                    folderNode.Nodes.Add(fileNode);
                }
            }

            tree_main.AfterExpand += Tree_main_AfterExpand;
            tree_main.AfterCollapse += Tree_main_AfterCollapse;

            root.Expand();
            foreach (var expandedFolderId in previousExpandState)
            {
                var folderNode = FindFolderNode(expandedFolderId);
                if (folderNode != null)
                {
                    folderNode.Expand();
                }
            }
            UpdateExpandState();

            // select the node that was selected before creating the tree
            if (previousSelectedNode != null)
            {
                if (previousSelectedNode is ProjectFileTreeNode fileSelectedNode)
                {
                    tree_main.SelectedNode = FindFileNode(fileSelectedNode.File);
                }
                else if (previousSelectedNode is ProjectFolderTreeNode folderSelectedNode)
                {
                    tree_main.SelectedNode = FindFolderNode(folderSelectedNode.Folder.id);
                }
            }

            // sort tree nodes
            tree_main.Sort();
        }

        private void UpdateExpandState()
        {
            var expandedFolders = new List<string>();
            void walkNodes(TreeNode node)
            {
                if (node.IsExpanded && node is ProjectFolderTreeNode folderNode)
                {
                    expandedFolders.Add(folderNode.Folder.id);
                }
                foreach (var childNode in node.Nodes)
                {
                    if (childNode is ProjectFolderTreeNode childFolderNode)
                    {
                        walkNodes(childFolderNode);
                    }
                }
            }
            walkNodes(tree_main.Nodes[0]);
            _expandedFolders = expandedFolders.ToArray();
        }

        private ProjectFolderTreeNode FindFolderNode(string id, TreeNode node = null)
        {
            if (node == null)
            {
                // start searching from root
                return FindFolderNode(id, tree_main.Nodes[0]);
            }

            if (node is ProjectFolderTreeNode folderNode)
            {
                if (folderNode.Folder.id == id)
                {
                    return folderNode;
                }
                foreach (var child in folderNode.Nodes)
                {
                    if (child is ProjectFolderTreeNode childFolderNode)
                    {
                        var result = FindFolderNode(id, childFolderNode);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
            }

            return null;
        }

        private ProjectFileTreeNode FindFileNode(ProjectFileData file, TreeNode node = null)
        {
            if (node == null)
            {
                // start searching from root
                return FindFileNode(file, tree_main.Nodes[0]);
            }

            if (node is ProjectFolderTreeNode folderNode)
            {
                foreach (var child in folderNode.Nodes)
                {
                    switch (child)
                    {
                        case ProjectFileTreeNode fileNode:
                            if (fileNode.File.id == file.id && fileNode.File.FileType == file.FileType)
                            {
                                return fileNode;
                            }
                            break;
                        case ProjectFolderTreeNode childFolderNode:
                            var result = FindFileNode(file, childFolderNode);
                            if (result != null)
                            {
                                return result;
                            }
                            break;
                    }
                }
            }

            return null;
        }

        private void OpenFromNode(ProjectTreeNode node)
        {
            if (node is ProjectFileTreeNode fileNode)
            {
                _eventBus.RequestFileOpen(fileNode.File);
            }
        }

        private void tree_main_ItemDrag(object sender, ItemDragEventArgs e)
        {
            tree_main.SuspendLayout();
            DoDragDrop(e.Item, DragDropEffects.Move);
            tree_main.ResumeLayout();
        }

        private void tree_main_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tree_main_DragDrop(object sender, DragEventArgs e)
        {
            var targetPoint = tree_main.PointToClient(new Point(e.X, e.Y));
            var targetNode = tree_main.GetNodeAt(targetPoint);

            var draggedFolderNode = (ProjectFolderTreeNode)e.Data.GetData(typeof(ProjectFolderTreeNode));
            var draggedFileNode = (ProjectFileTreeNode)e.Data.GetData(typeof(ProjectFileTreeNode));

            // if the drop target is a file, use its parent folder instead
            // operation is "dropping next to the file"
            if (targetNode is ProjectFileTreeNode fileNode)
            {
                var folderNode = FindFolderNode(fileNode.File.folderId);
                targetNode = folderNode;
            }

            if (targetNode is ProjectFolderTreeNode targetFolderNode &&
                draggedFolderNode != null)
            {
                // folder to folder, change its parent
                if (draggedFolderNode.Folder.parentId != targetFolderNode.Folder.id &&
                    draggedFolderNode.Folder.id != targetFolderNode.Folder.id)
                {
                    draggedFolderNode.Folder.parentId = targetFolderNode.Folder.id;
                    Project.ActiveProject.Save();
                    CreateTree();
                    var newTargetFolderNode = FindFolderNode(targetFolderNode.Folder.id);
                    if (newTargetFolderNode != null)
                    {
                        newTargetFolderNode.Expand();
                    }
                }
            }
            else if (targetNode is ProjectFolderTreeNode targetFolderNode2 &&
                draggedFileNode != null)
            {
                // file to folder, change its folder assoc
                if (draggedFileNode.File.folderId != targetFolderNode2.Folder.id)
                {
                    draggedFileNode.File.folderId = targetFolderNode2.Folder.id;
                    Project.ActiveProject.Save();
                    CreateTree();
                    FindFolderNode(targetFolderNode2.Folder.id)?.Expand();
                }
            }
        }

        private void tree_main_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var node = e.Node;
            if (node is ProjectFolderTreeNode folderNode)
            {
                if (e.CancelEdit ||
                    (e.Label != null && e.Label.Length == 0) ||
                    e.Node == null ||
                    (e.Node != null && e.Node.Text == null) ||
                    (e.Node != null && e.Node.Text != null && e.Node.Text.Length == 0))
                {
                    if (folderNode.IsNewNode)
                    {
                        // if an invalid label was entered, delete a new node
                        folderNode.Remove();
                    }
                    else
                    {
                        // if it's not new, restore its original text
                        folderNode.UpdateText();
                    }
                    return;
                }

                var newName = e.Node.Text;
                if (e.Label != null && e.Label.Length > 0)
                {
                    newName = e.Label;
                }

                folderNode.Folder.name = newName;
                folderNode.UpdateText();

                if (folderNode.IsNewNode)
                {
                    var newId = ProjectService.GenerateFolderId(Project.ActiveProject, newName);
                    folderNode.Folder.id = newId;
                    folderNode.IsNewNode = false;
                    Project.ActiveProject.IncludeFolder(folderNode.Folder);
                }

                Project.ActiveProject.Save();

                tree_main.SelectedNode = folderNode;
            }
            else if (node is ProjectFileTreeNode fileNode)
            {
                if (e.CancelEdit ||
                    (e.Label != null && e.Label.Length == 0) ||
                    e.Node == null ||
                    (e.Node != null && e.Node.Text == null) ||
                    (e.Node != null && e.Node.Text != null && e.Node.Text.Length == 0))
                {
                    // restore its original text
                    fileNode.UpdateText();
                    return;
                }

                var newName = e.Node.Text;
                if (e.Label != null && e.Label.Length > 0)
                {
                    newName = e.Label;
                }

                fileNode.File.name = newName;
                fileNode.UpdateText();

                Project.ActiveProject.Save();

                _eventBus.UpdatedFile(fileNode.File);
                tree_main.SelectedNode = fileNode;
            }
        }

        private ProjectFolderTreeNode GetSelectedFolderNode()
        {
            var selectedNode = tree_main.SelectedNode;
            ProjectFolderTreeNode folderNode = null;
            if (selectedNode is ProjectFileTreeNode fileNode)
            {
                folderNode = FindFolderNode(fileNode.File.folderId);
            }
            else if (selectedNode is ProjectFolderTreeNode selectedFolderNode)
            {
                folderNode = selectedFolderNode;
            }
            else if (selectedNode == null)
            {
                folderNode = (ProjectFolderTreeNode)tree_main.Nodes[0];
            }
            return folderNode;
        }

        private void CreateResource<T>(T resource, string name, ProjectFileType fileType) where T : Resource<T>
        {
            var folderNode = GetSelectedFolderNode();
            var file = ProjectService.IncludeResource(Project.ActiveProject, resource, name, fileType, folderNode.Folder);
            resource.Save();
            Project.ActiveProject.Save();
            CreateTree();
            FindFolderNode(folderNode.Folder.id)?.Expand();
            var fileNode = FindFileNode(file);
            if (fileNode != null)
            {
                tree_main.SelectedNode = fileNode;
            }
            _eventBus.RequestFileOpen(file);
        }
    }
}
