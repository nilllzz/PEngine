using System.Diagnostics;
using System.IO;

namespace PEngine.Creator.Helpers
{
    internal static class ExplorerHelper
    {
        internal static void OpenWithFileSelected(string filePath)
        {
            var path = Path.GetFullPath(filePath); // normalize path
            Process.Start("explorer.exe", $"/select, \"{path}\"");
        }

        internal static void OpenInFolder(string folderPath)
        {
            var path = Path.GetFullPath(folderPath); // normalize path
            Process.Start("explorer.exe", $"\"{path}\"");
        }
    }
}
