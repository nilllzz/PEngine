using PEngine.Common;
using PEngine.Common.Interop;
using System.IO;
using static Core;

namespace PEngine.Game
{
    static class ProjectHelper
    {
        internal static string ProjectPath { get; set; }

        internal static bool LoadProject()
        {
            if (!Directory.Exists(ProjectPath))
            {
                GamePipeline.Log(LogType.Error, "Project directory does not exist");
                return false;
            }
            var project = new Project(ProjectPath);
            project.Load();
            return true;
        }
    }
}
