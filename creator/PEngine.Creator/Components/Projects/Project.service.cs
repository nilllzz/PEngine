using PEngine.Common;
using PEngine.Creator.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal static class ProjectService
    {
        internal const int MAX_TILES_IN_SET = 64;
        internal const int MAX_SUBTILES_IN_SET = 64;

        internal static string ProjectsDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");

        private static void CheckCreateProjectsDirectory()
        {
            if (!Directory.Exists(ProjectsDirectory))
            {
                Directory.CreateDirectory(ProjectsDirectory);
            }
        }

        // generates a path for a project name
        internal static string GetNewProjectPath(string name)
        {
            var path = Path.Combine(ProjectsDirectory, name);
            while (Directory.Exists(path))
            {
                path += "_";
            }
            return path;
        }

        internal static bool OpenProject(Form caller)
        {
            CheckCreateProjectsDirectory();

            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = ProjectsDirectory,
                Filter = "Project Files (*.json)|*.json",
                Multiselect = false
            };
            dialog.CustomPlaces.Add(ProjectsDirectory);
            dialog.ShowDialog(caller);

            if (dialog.FileName != null && dialog.FileName.Length > 0)
            {
                var filename = dialog.FileName.ToLower();
                if (Settings.Default.RecentProjects == null)
                {
                    Settings.Default.RecentProjects = new System.Collections.Specialized.StringCollection();
                }
                var recentProject = Settings.Default.RecentProjects;
                if (!recentProject.Contains(filename))
                {
                    recentProject.Add(filename);
                }
                Settings.Default.Save();

                var project = new Project(Path.GetDirectoryName(dialog.FileName));
                project.Load();

                return true;
            }
            return false;
        }
    }
}
