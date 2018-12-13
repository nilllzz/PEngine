using PEngine.Common;
using PEngine.Creator.Helpers;
using PEngine.Creator.Properties;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectLoadButton : UserControl
    {
        private string _filepath;

        public ProjectLoadButton()
        {
            InitializeComponent();
        }

        public void SetProjectFilepath(string path)
        {
            _filepath = path;

            var projectPath = Path.GetDirectoryName(_filepath);
            var projectFolder = Path.GetFileName(projectPath);

            lbl_title.Text = projectFolder;

            tooltip_main.SetToolTip(btn, _filepath);
        }

        #region ui

        private void btn_Click(object sender, System.EventArgs e)
        {
            OpenProject();
        }

        private void context_main_open_Click(object sender, System.EventArgs e)
        {
            OpenProject();
        }

        private void context_main_reveal_Click(object sender, System.EventArgs e)
        {
            ExplorerHelper.OpenInFolder(Path.GetDirectoryName(_filepath));
        }

        private void context_main_remove_Click(object sender, System.EventArgs e)
        {
            Settings.Default.RecentProjects.Remove(_filepath);
            Settings.Default.Save();

            btn.Enabled = false;
            lbl_title.Enabled = false;
        }

        #endregion

        private void OpenProject()
        {
            var project = new Project(Path.GetDirectoryName(_filepath));
            ProjectService.LoadProject(project);
        }
    }
}
