using System.Diagnostics;
using System.IO;

namespace PEngine.Creator.Helpers
{
    static class ExplorerHelper
    {
        public static void OpenWithFileSelected(string filePath)
        {
            var path = Path.GetFullPath(filePath); // normalize path
            Process.Start("explorer.exe", $"/select, \"{path}\"");
        }

        public static void OpenInFolder(string folderPath)
        {
            var path = Path.GetFullPath(folderPath); // normalize path
            Process.Start("explorer.exe", $"\"{path}\"");
        }
    }
}
