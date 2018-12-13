using PEngine.Common;
using PEngine.Common.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal partial class ProjectTreeView : TreeView
    {
        private string[] _expandedFolders = new string[0];

        public ProjectFileType[] FileTypeFilter { get; set; } = new ProjectFileType[0];

        // public to keep the designer happy
        public ProjectTreeView()
        {
            InitializeComponent();
            TreeViewNodeSorter = new ProjectTreeNodeComparer();
        }

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

        internal void CreateTree()
        {
            var previousExpandState = _expandedFolders;
            var previousSelectedNode = SelectedNode;

            AfterExpand -= Tree_main_AfterExpand;
            AfterCollapse -= Tree_main_AfterCollapse;
            Nodes.Clear();

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
            Nodes.Add(root);

            // create file nodes
            foreach (var file in project.Files)
            {
                if (FileTypeFilter.Length == 0 || FileTypeFilter.Contains(file.FileType))
                {
                    var folderNode = FindFolderNode(file.folderId);
                    if (folderNode != null)
                    {
                        var fileNode = new ProjectFileTreeNode(file);
                        folderNode.Nodes.Add(fileNode);
                    }
                }
            }

            AfterExpand += Tree_main_AfterExpand;
            AfterCollapse += Tree_main_AfterCollapse;

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
                    SelectedNode = FindFileNode(fileSelectedNode.File);
                }
                else if (previousSelectedNode is ProjectFolderTreeNode folderSelectedNode)
                {
                    SelectedNode = FindFolderNode(folderSelectedNode.Folder.id);
                }
            }

            // sort tree nodes
            Sort();
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
            walkNodes(Nodes[0]);
            _expandedFolders = expandedFolders.ToArray();
        }

        internal ProjectFolderTreeNode FindFolderNode(string id, TreeNode node = null)
        {
            if (node == null)
            {
                // start searching from root
                return FindFolderNode(id, Nodes[0]);
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

        internal ProjectFileTreeNode FindFileNode(ProjectFileData file, TreeNode node = null)
        {
            if (node == null)
            {
                // start searching from root
                return FindFileNode(file, Nodes[0]);
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
    }
}
