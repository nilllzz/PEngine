using PEngine.Common;
using System;
using System.IO;

namespace PEngine.Game
{
    static class ProjectHelper
    {
        internal static void LoadTestProject()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var solutionDir = dir.Parent.Parent.Parent.Parent.FullName;
            var sourceDir = Path.Combine(solutionDir, @"creator\PEngine.Creator\bin\Debug\projects\test");

            var targetDir = Path.Combine(dir.FullName, "test");

            Copy(sourceDir, targetDir);
            var project = new Project(targetDir);
            project.Load();
        }

        private static void Copy(string sourceDirectory, string targetDirectory)
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
