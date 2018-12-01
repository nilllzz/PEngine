using PEngine.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    static class ProjectService
    {
        public static string ProjectsDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");

        private static void CheckCreateProjectsDirectory()
        {
            if (!Directory.Exists(ProjectsDirectory))
            {
                Directory.CreateDirectory(ProjectsDirectory);
            }
        }

        // generates a path for a project name
        public static string GetNewProjectPath(string name)
        {
            var path = Path.Combine(ProjectsDirectory, name);
            while (Directory.Exists(path))
            {
                path += "_";
            }
            return path;
        }

        public static void OpenProject(Form caller)
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

            var project = new Project(Path.GetDirectoryName(dialog.FileName));
            project.Load();
        }
    }
}
