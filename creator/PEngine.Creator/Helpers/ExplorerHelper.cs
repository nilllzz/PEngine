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
    }
}
