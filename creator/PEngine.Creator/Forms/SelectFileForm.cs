using PEngine.Common.Data;
using PEngine.Creator.Components.Projects;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class SelectFileForm : Form
    {
        public ProjectFileType[] FileTypeFilter { get; set; } = new ProjectFileType[0];
        public ProjectFileData SelectedFile { get; private set; }

        public SelectFileForm()
        {
            InitializeComponent();
        }

        private void SelectFileForm_Shown(object sender, System.EventArgs e)
        {
            tree_main.FileTypeFilter = FileTypeFilter;
            tree_main.CreateTree();
        }

        private void tree_main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is ProjectFileTreeNode fileNode)
            {
                SelectedFile = fileNode.File;
                lbl_selected.Text = SelectedFile.name;
                btn_ok.Enabled = true;
            }
            else
            {
                SelectedFile = null;
                lbl_selected.Text = "";
                btn_ok.Enabled = false;
            }
        }

        private void tree_main_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is ProjectFileTreeNode fileNode)
            {
                SelectedFile = fileNode.File;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
