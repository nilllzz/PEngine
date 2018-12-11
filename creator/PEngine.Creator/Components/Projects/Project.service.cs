using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Forms;
using PEngine.Creator.Helpers;
using PEngine.Creator.Properties;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal static class ProjectService
    {
        internal const int MAX_TILES_IN_SET = 64;
        internal const int MAX_SUBTILES_IN_SET = 64;

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
                Multiselect = false
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
            // try and guess the id
            var fileId = Path.GetFileNameWithoutExtension(path);
            var id = fileId;
            var n = 0;
            var file = project.GetFile(id, fileType);
            while (file != null)
            {
                n++;
                id = fileId + n.ToString();
                file = project.GetFile(id, fileType);
            }
            var newFile = new ProjectFileData
            {
                id = id,
                path = path,
                type = DataHelper.UnparseEnum(fileType),
                folderId = folder?.id,
            };
            project.IncludeFile(newFile);
            return newFile;
        }

        // includes a resource in memory to the project file
        internal static ProjectFileData IncludeResource<T>(Project project, T resource, ProjectFileType type, ProjectFolderData folder) where T : Resource<T>
        {
            var file = new ProjectFileData
            {
                id = resource.id,
                path = resource.FileName,
                type = DataHelper.UnparseEnum(type),
                folderId = folder?.id,
            };
            project.IncludeFile(file);
            return file;
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
            var defaultTileset = TilesetService.CreateNew("routes", routesFile);
            IncludeResource(Project.ActiveProject, defaultTileset, ProjectFileType.Tileset, tilesetsFolder);
            defaultTileset.Save();

            var defaultMap = MapService.CreateNew("default", defaultTileset, "Default");
            IncludeResource(Project.ActiveProject, defaultMap, ProjectFileType.Map, mapsFolder);
            defaultMap.Save();

            project.Save();

            return project;
        }

        internal static void ExcludeFile(ProjectFileData file)
        {
            Project.ActiveProject.ExcludeFile(file);
        }

        internal static void DeleteFile(ProjectFileData file)
        {
            Project.ActiveProject.ExcludeFile(file);
            Project.ActiveProject.Save();
            var path = Path.Combine(Project.ActiveProject.BaseDirectory, file.path);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
