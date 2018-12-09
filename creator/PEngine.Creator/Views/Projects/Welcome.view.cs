using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using PEngine.Creator.Properties;
using System.Collections.Generic;
using System.IO;

namespace PEngine.Creator.Views.Projects
{
    internal partial class WelcomeView : BaseView
    {
        internal WelcomeView()
        {
            InitializeComponent();

            LoadRecentProjects();
        }

        private void btn_create_Click(object sender, System.EventArgs e)
        {
            var view = new NewProjectView();
            view.SetPreviousView(this);
            MainForm.Instance.SetView(view, false);
        }

        private void btn_load_Click(object sender, System.EventArgs e)
        {
            var project = ProjectService.SelectProject(MainForm.Instance);
            if (project != null)
            {
                ProjectService.LoadProject(project);
            }
        }

        private void btn_reload_recent_Click(object sender, System.EventArgs e)
        {
            LoadRecentProjects();
        }

        private void LoadRecentProjects()
        {
            panel_recent_container.Controls.Clear();

            var recentProjects = Settings.Default.RecentProjects;
            if (recentProjects != null)
            {
                var updatedRecentProjects = new List<string>();
                foreach (var projectFile in recentProjects)
                {
                    if (File.Exists(projectFile))
                    {
                        var btn = new ProjectLoadButton();
                        btn.SetProjectFilepath(projectFile);
                        panel_recent_container.Controls.Add(btn);

                        updatedRecentProjects.Add(projectFile);
                    }
                }
                if (updatedRecentProjects.Count != recentProjects.Count)
                {
                    Settings.Default.RecentProjects.Clear();
                    Settings.Default.RecentProjects.AddRange(updatedRecentProjects.ToArray());
                    Settings.Default.Save();
                }
            }
        }
    }
}
