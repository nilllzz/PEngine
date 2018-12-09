using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    internal partial class NewProjectView : BaseView
    {
        private BaseView _previousView;

        internal NewProjectView()
        {
            InitializeComponent();
            txt_name.Select();

            ProjectService.CheckCreateProjectsDirectory();
            txt_dest_folder.Text = ProjectService.ProjectsDirectory;
        }

        internal void SetPreviousView(BaseView view)
        {
            _previousView = view;
        }

        private void btn_confirm_Click(object sender, System.EventArgs e)
        {
            var name = txt_name.Text;
            var author = txt_author.Text;
            var path = txt_dest_folder.Text;

            if (name.Length == 0)
            {
                MessageBox.Show("You have to enter a project name.", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (author.Length == 0)
            {
                MessageBox.Show("You have to enter an author.", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show("The target directory you entered does not exist.", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var project = ProjectService.CreateNew(path, name, author);
            ProjectService.LoadProject(project);
        }

        private void btn_cancel_Click(object sender, System.EventArgs e)
        {
            MainForm.Instance.SetView(_previousView);
        }

        private void btn_select_dest_folder_Click(object sender, System.EventArgs e)
        {
            var browser = new FolderBrowserDialog();
            browser.ShowNewFolderButton = true;
            browser.SelectedPath = txt_dest_folder.Text;
            browser.Description = "Select a project directory";
            var result = browser.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_dest_folder.Text = browser.SelectedPath;
            }
        }
    }
}
