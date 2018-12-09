using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using PEngine.Creator.Properties;
using System.IO;

namespace PEngine.Creator.Views.Projects
{
    internal partial class WelcomeView : BaseView
    {
        internal WelcomeView()
        {
            InitializeComponent();

            var recentProjects = Settings.Default.RecentProjects;
            if (recentProjects != null)
            {
                foreach (var projectFile in recentProjects)
                {
                    if (File.Exists(projectFile))
                    {
                        var btn = new ProjectLoadButton();
                        btn.SetProjectFilepath(projectFile);
                        panel_recent_container.Controls.Add(btn);
                    }
                }
            }
        }

        private void btn_create_Click(object sender, System.EventArgs e)
        {
            var view = new NewProjectView();
            MainForm.Instance.SetView(view);
        }
    }
}
