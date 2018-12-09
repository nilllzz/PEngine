using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Forms;
using PEngine.Creator.Helpers;
using PEngine.Creator.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal static class ProjectService
    {
        internal const int MAX_TILES_IN_SET = 64;
        internal const int MAX_SUBTILES_IN_SET = 64;

        internal static string ProjectsDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");

        private static void CheckCreateProjectsDirectory()
        {
            if (!Directory.Exists(ProjectsDirectory))
            {
                Directory.CreateDirectory(ProjectsDirectory);
            }
        }

        // generates a path for a project name
        internal static string GetNewProjectPath(string name)
        {
            var path = Path.Combine(ProjectsDirectory, name);
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
                Filter = "Project Files (*.json)|*.json",
                Multiselect = false
            };
            dialog.CustomPlaces.Add(ProjectsDirectory);
            dialog.ShowDialog(caller);

            if (dialog.FileName != null && dialog.FileName.Length > 0)
            {
                var project = new Project(Path.GetDirectoryName(dialog.FileName));
                return project;
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

        internal static void IncludeFile(Project project, string path, ProjectFileType fileType)
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
            project.IncludeFile(new ProjectFileData
            {
                id = id,
                path = path,
                type = DataHelper.UnparseEnum(fileType),
            });
        }

        internal static Project CreateNew(string name, string author)
        {
            var path = GetNewProjectPath(name);
            var project = new Project(path);
            project.Create(name, author);
            project.Save();
            project.Load();

            // copy default resources
            var defaultContent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/DefaultProject/Content");
            ExplorerHelper.Copy(defaultContent, Path.Combine(project.BaseDirectory, "content"));

            // add them to the project
            IncludeFile(project, "content/textures/tiles/routes.png", ProjectFileType.TextureTileset);
            IncludeFile(project, "content/textures/characters/player.png", ProjectFileType.TextureCharacter);

            // create default data files
            var defaultTileset = TilesetData.Create("data/tiles/routes.json");
            defaultTileset.id = "routes";
            defaultTileset.texture = "routes";
            defaultTileset.subtiles = new[]
            {
                new SubtileData
                {
                    id = 0,
                    behavior = DataHelper.UnparseEnum(SubtileBehavior.Floor),
                    texture = new[] { 0, 0 }
                }
            };
            defaultTileset.tiles = new[]
            {
                new TileData
                {
                    id = 0,
                    subtiles = new[] { 0, 0, 0, 0 }
                }
            };
            project.IncludeFile(new ProjectFileData
            {
                type = DataHelper.UnparseEnum(ProjectFileType.Tileset),
                id = defaultTileset.id,
                path = defaultTileset.FileName,
            });
            defaultTileset.Save();

            var defaultMap = MapData.Create("data/maps/default.json");
            defaultMap.id = "default";
            defaultMap.tileset = defaultTileset.id;
            defaultMap.tiles = new[]
            {
                new MapTileData
                {
                    tileId = 0,
                    pos = new[] { 0, 0 },
                    size = new[] { 1, 1 },
                }
            };
            project.IncludeFile(new ProjectFileData
            {
                type = DataHelper.UnparseEnum(ProjectFileType.Map),
                id = defaultMap.id,
                path = defaultMap.FileName,
            });
            defaultMap.Save();

            project.Save();

            return project;
        }
    }
}
