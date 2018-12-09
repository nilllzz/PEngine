using PEngine.Common;
using PEngine.Creator.Forms;
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

        private void btn_Click(object sender, System.EventArgs e)
        {
            var project = new Project(Path.GetDirectoryName(_filepath));
            project.Load();
            MainForm.Instance.LoadedProject();
        }
    }
}
