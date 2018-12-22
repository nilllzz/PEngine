using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Creator.Components.Projects;
using System.IO;

namespace PEngine.Creator.Components.Game.Scripts
{
    internal static class ScriptsService
    {
        internal static void CreateNew(string name, ProjectFolderData folder)
        {
            var fileId = ProjectService.GenerateFileId(Project.ActiveProject, name);
            var filePathSuggestion = Path.Combine(Project.ActiveProject.BaseDirectory, fileId) + ".js";

            var filePath = ProjectService.GenerateFileName(Project.ActiveProject, filePathSuggestion);
            File.WriteAllText(filePath, $"// Script {name}\n\n");

            ProjectService.IncludeExternalFile(Project.ActiveProject, filePath,
                ProjectFileType.Script, folder);
        }

        internal static string ReadScript(ProjectFileData file)
        {
            return File.ReadAllText(file.FilePath);
        }

        internal static void SaveScript(ProjectFileData file, string text)
        {
            File.WriteAllText(file.FilePath, text);
        }
    }
}
