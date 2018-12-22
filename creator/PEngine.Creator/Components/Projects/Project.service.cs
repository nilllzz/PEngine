using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Game.Maps;
using PEngine.Creator.Components.Game.Tilesets;
using PEngine.Creator.Components.Game.World;
using PEngine.Creator.Forms;
using PEngine.Creator.Helpers;
using PEngine.Creator.Properties;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal static class ProjectService
    {
        internal static string ProjectsDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");

        internal static void CheckCreateProjectsDirectory()
        {
            if (!Directory.Exists(ProjectsDirectory))
            {
                Directory.CreateDirectory(ProjectsDirectory);
            }
        }

        // generates a path for a project name
        internal static string GetNewProjectPath(string targetDir, string name)
        {
            var path = Path.Combine(targetDir, name);
            while (Directory.Exists(path))
            {
                path += "_";
            }
            return path;
        }

        internal static void CloseProject()
        {
            Project.ActiveProject.Unload();
            ResourceManager.Unload();
        }

        internal static Project SelectProject(Form caller)
        {
            CheckCreateProjectsDirectory();

            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = ProjectsDirectory,
                FileName = "project",
                Filter = "Project Files (*.json)|*.json",
                Multiselect = false,
            };
            dialog.CustomPlaces.Add(ProjectsDirectory);
            var result = dialog.ShowDialog(caller);
            if (result == DialogResult.OK)
            {
                if (dialog.FileName != null && dialog.FileName.Length > 0)
                {
                    var project = new Project(Path.GetDirectoryName(dialog.FileName));
                    return project;
                }
            }

            return null;
        }

        internal static void LoadProject(Project project)
        {
            // store recently used projects
            var filename = project.ProjectFile.ToLower();
            if (Settings.Default.RecentProjects == null)
            {
                Settings.Default.RecentProjects = new System.Collections.Specialized.StringCollection();
            }
            // add new project to recent or move to front
            var recentProject = Settings.Default.RecentProjects;
            if (recentProject.Contains(filename))
            {
                recentProject.Remove(filename);
            }
            recentProject.Insert(0, filename);
            Settings.Default.Save();

            ResourceManager.Unload();

            project.Load();
            MainForm.Instance.LoadedProject();
        }

        // includes an existing file on disk to the project
        internal static ProjectFileData IncludeExternalFile(Project project, string path, ProjectFileType fileType, ProjectFolderData folder)
        {
            // try and copy the file into the project directory if it's an absolute path
            if (Path.IsPathRooted(path))
            {
                // check if the file is already in the project dir
                // in that case, just include it
                if (path.ToLower().StartsWith(project.BaseDirectory.ToLower()))
                {
                    path = path.Substring(project.BaseDirectory.Length);
                    while (path.StartsWith("/") || path.StartsWith("\\"))
                    {
                        path = path.Substring(1);
                    }
                    // check that this file is not already in the project
                    var existingFile = project.Files.FirstOrDefault(f => f.path.ToLower() == path.ToLower());
                    if (existingFile != null)
                    {
                        return existingFile;
                    }
                }
                else
                {
                    var targetFilePath = GenerateFileName(project, path);

                    // copy the file
                    File.Copy(path, targetFilePath);

                    path = targetFilePath.Substring(project.BaseDirectory.Length);
                    while (path.StartsWith("/") || path.StartsWith("\\"))
                    {
                        path = path.Substring(1);
                    }
                }
            }

            // the file's name is the last part of the path
            var name = Path.GetFileNameWithoutExtension(path);
            // generate id from that name
            var id = GenerateFileId(project, name);

            var newFile = new ProjectFileData
            {
                id = id,
                name = name,
                path = path,
                type = DataHelper.UnparseEnum(fileType),
                folderId = folder?.id,
            };

            project.IncludeFile(newFile);
            return newFile;
        }

        // includes a resource in memory to the project file
        internal static ProjectFileData IncludeResource<T>(Project project, T resource, string name, ProjectFileType type, ProjectFolderData folder) where T : Resource<T>
        {
            var file = new ProjectFileData
            {
                id = resource.id,
                name = name,
                path = resource.FileName,
                type = DataHelper.UnparseEnum(type),
                folderId = folder?.id,
            };
            project.IncludeFile(file);
            return file;
        }

        internal static string GenerateFileId(Project project, string suggestion)
        {
            var fileIdChars = suggestion.ToLower().ToCharArray();
            for (var i = 0; i < fileIdChars.Length; i++)
            {
                if (!Regex.IsMatch(fileIdChars[i].ToString(), "[a-z0-9_-]"))
                {
                    fileIdChars[i] = '_';
                }
            }
            var fileId = string.Join("", fileIdChars);
            var id = fileId;
            var n = 0;
            var file = project.GetFile(id);
            while (file != null)
            {
                n++;
                id = fileId + n.ToString();
                file = project.GetFile(id);
            }
            return id;
        }

        internal static string GenerateFileName(Project project, string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);

            // find a valid target file path
            var fileExists = false;
            var targetFilePath = "";
            var n = 0;

            do
            {
                var numeric = "";
                if (n > 0)
                {
                    numeric = n.ToString();
                }
                targetFilePath = Path.Combine(project.BaseDirectory, fileName) + numeric + extension;
                fileExists = File.Exists(targetFilePath);
                n++;
            } while (fileExists);

            return targetFilePath;
        }

        internal static string GenerateFolderId(Project project, string name)
        {
            var folderIdChars = name.ToLower().ToCharArray();
            for (var i = 0; i < folderIdChars.Length; i++)
            {
                if (!Regex.IsMatch(folderIdChars[i].ToString(), "[a-z0-9_-]"))
                {
                    folderIdChars[i] = '_';
                }
            }
            var folderId = string.Join("", folderIdChars);
            var id = folderId;
            var n = 0;
            var folder = project.GetFolder(id);
            while (folder != null)
            {
                n++;
                id = folderId + n.ToString();
                folder = project.GetFolder(id);
            }
            return id;
        }

        internal static ProjectFolderData CreateFolder(Project project, string name, ProjectFolderData parent)
        {
            var id = GenerateFolderId(project, name);
            var newFolder = new ProjectFolderData
            {
                id = id,
                name = name,
                parentId = parent?.id,
            };
            return newFolder;
        }

        internal static Project CreateNew(string targetDir, string name, string author)
        {
            var path = GetNewProjectPath(targetDir, name);
            var project = new Project(path);
            project.Create(name, author);

            // create some default folders
            var mapsFolder = CreateFolder(project, "Maps", null);
            var scriptsFolder = CreateFolder(project, "Scripts", null);
            var tilesetsFolder = CreateFolder(project, "Tilesets", null);
            var contentFolder = CreateFolder(project, "Content", null);
            var texturesFolder = CreateFolder(project, "Textures", contentFolder);
            var charactersFolder = CreateFolder(project, "Characters", texturesFolder);
            var tilesFolder = CreateFolder(project, "Tiles", texturesFolder);
            foreach (var folder in new[]
                { mapsFolder, scriptsFolder, tilesetsFolder, contentFolder,
                  texturesFolder, charactersFolder, tilesFolder })
            {
                project.IncludeFolder(folder);
            }
            project.Save();
            project.Load();

            // copy default resources
            var defaultContent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/DefaultProject");
            ExplorerHelper.Copy(defaultContent, Path.Combine(project.BaseDirectory, "content"));

            // add them to the project
            var routesFile = IncludeExternalFile(project, "content/routes.png", ProjectFileType.TextureTileset, tilesFolder);
            var playerFile = IncludeExternalFile(project, "content/player.png", ProjectFileType.TextureCharacter, charactersFolder);

            // create default data files
            var defaultTilesetId = GenerateFileId(project, "routes");
            var defaultTileset = TilesetService.CreateNew(defaultTilesetId, routesFile);
            IncludeResource(Project.ActiveProject, defaultTileset, "routes", ProjectFileType.Tileset, tilesetsFolder);
            defaultTileset.Save();

            var defaultMapId = GenerateFileId(project, "default");
            var defaultMap = MapService.CreateNew(defaultMapId, defaultTileset, "Default");
            IncludeResource(Project.ActiveProject, defaultMap, "default", ProjectFileType.Map, mapsFolder);
            defaultMap.Save();

            var defaultWorldId = GenerateFileId(project, "world");
            var defaultWorld = WorldmapService.CreateNew(defaultWorldId);
            IncludeResource(Project.ActiveProject, defaultWorld, "World Map", ProjectFileType.Worldmap, null);
            defaultWorld.Save();

            project.Save();

            return project;
        }

        internal static void ExcludeFile(ProjectFileData file)
        {
            Project.ActiveProject.ExcludeFile(file);
        }

        private static void DeleteObjects(ProjectFileData[] files, ProjectFolderData[] folders)
        {
            // files
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    ExcludeFile(file);
                    var path = Path.Combine(Project.ActiveProject.BaseDirectory, file.path);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            // folders
            if (folders != null && folders.Length > 0)
            {
                foreach (var folder in folders)
                {
                    Project.ActiveProject.ExcludeFolder(folder);
                }
            }

            if (folders != null && files != null)
            {
                Project.ActiveProject.Save();
            }
        }

        internal static void DeleteFile(ProjectFileData file)
        {
            DeleteObjects(new[] { file }, null);
        }

        // deletes the folder and all containing files and folders
        internal static void DeleteFolder(ProjectFolderData folder)
        {
            var files = Project.ActiveProject.GetFiles(folder, true);
            var folders = Project.ActiveProject.GetFolders(folder, true);
            // add the selected folder to the subfolders
            folders = folders.Concat(new[] { folder }).ToArray();
            DeleteObjects(files, folders);
        }
    }
}
