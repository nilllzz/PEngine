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

        internal static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (var fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
