using System.Collections.Generic;

namespace PEngine.Creator.Components.Projects
{
    class ProjectTreeNodeComparer : Comparer<ProjectTreeNode>
    {
        public override int Compare(ProjectTreeNode x, ProjectTreeNode y)
        {
            // sort folders first and by alpha, then files by alpha

            var xIsFile = x is ProjectFileTreeNode;
            var yIsFile = y is ProjectFileTreeNode;

            if (xIsFile && yIsFile)
            {
                var xFile = x as ProjectFileTreeNode;
                var yFile = y as ProjectFileTreeNode;
                return xFile.File.name.CompareTo(yFile.File.name);
            }
            else if (!xIsFile && yIsFile)
            {
                return -1;
            }
            else if (xIsFile && !yIsFile)
            {
                return 1;
            }
            else if (!xIsFile && !yIsFile)
            {
                var xFolder = x as ProjectFolderTreeNode;
                var yFolder = y as ProjectFolderTreeNode;
                return xFolder.Folder.name.CompareTo(yFolder.Folder.name);
            }
            // fallback
            return 0;
        }
    }
}
