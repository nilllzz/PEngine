using Newtonsoft.Json;
using PEngine.Common.Data;
using System;
using System.IO;
using System.Linq;

namespace PEngine.Common
{
    public sealed class Project
    {
        public static Project ActiveProject { get; private set; }

        private ProjectData _data;

        public string BaseDirectory { get; private set; }
        public string ProjectFile => Path.Combine(BaseDirectory, "project.json");

        public string Name
        {
            get => _data.name;
            set => _data.name = value;
        }

        public string Author
        {
            get => _data.author;
            set => _data.author = value;
        }

        public ProjectFolderData[] Folders => _data.folders;
        public ProjectFileData[] Files => _data.files;

        public Project(string projectPath)
        {
            BaseDirectory = projectPath;
        }

        public void Create(string name, string author)
        {
            _data = new ProjectData
            {
                name = name,
                author = author,
                createdOn = DateTime.UtcNow,
                changedOn = DateTime.UtcNow,
                files = new ProjectFileData[0],
                folders = new ProjectFolderData[0],
            };
        }

        public ProjectFileData[] GetFiles(ProjectFileType type)
        {
            return _data.files.Where(f => f.FileType == type).ToArray();
        }

        public ProjectFileData GetFile(string id)
        {
            return _data.files.FirstOrDefault(f => f.id == id);
        }

        public ProjectFolderData GetFolder(string id)
        {
            return _data.folders.FirstOrDefault(f => f.id == id);
        }

        public ProjectFileData[] GetFiles(ProjectFolderData parent, bool recursive = true)
        {
            var files = _data.files.Where(f => f.folderId == parent.id).ToList();

            if (recursive)
            {
                var subFolders = _data.folders.Where(f => f.parentId == parent.id);
                foreach (var subFolder in subFolders)
                {
                    var subfolderFiles = GetFiles(subFolder, true);
                    files.AddRange(subfolderFiles);
                }
            }

            return files.ToArray();
        }

        public ProjectFolderData[] GetFolders(ProjectFolderData parent, bool recursive = true)
        {
            var folders = _data.folders.Where(f => f.parentId == parent.id).ToList();

            if (recursive)
            {
                foreach (var folder in _data.folders.Where(f => f.parentId == parent.id))
                {
                    var subfolders = GetFolders(folder, true);
                    folders.AddRange(subfolders);
                }
            }

            return folders.ToArray();
        }

        public void IncludeFile(ProjectFileData file)
        {
            if (_data.files.Any(f => f.id == file.id && f.type == file.type))
            {
                throw new Exception($"A file with the id \"{file.id}\" and type {file.type} is already in the project.");
            }
            var files = _data.files.ToList();
            files.Add(file);
            _data.files = files.ToArray();
        }

        public void IncludeFolder(ProjectFolderData folder)
        {
            if (_data.folders.Any(f => f.id == folder.id))
            {
                throw new Exception($"A folder with the id \"{folder.id}\" is already in the project.");
            }
            var folders = _data.folders.ToList();
            folders.Add(folder);
            _data.folders = folders.ToArray();
        }

        public void ExcludeFile(ProjectFileData file)
        {
            var files = _data.files.Where(f => f.id != file.id || f.type != file.type);
            _data.files = files.ToArray();
        }

        public void ExcludeFolder(ProjectFolderData folder)
        {
            var folders = _data.folders.Where(f => f.id != folder.id);
            _data.folders = folders.ToArray();
        }

        public void Load()
        {
            if (File.Exists(ProjectFile))
            {
                var content = File.ReadAllText(ProjectFile);
                _data = JsonConvert.DeserializeObject<ProjectData>(content);
                // set active project to loaded project
                ActiveProject = this;
            }
            else
            {
                throw new Exception($"The project file does not exist. '{ProjectFile}'");
            }
        }

        public void Unload()
        {
            ActiveProject = null;
        }

        public void Save()
        {
            // create project dir
            if (!Directory.Exists(BaseDirectory))
            {
                Directory.CreateDirectory(BaseDirectory);
            }

            _data.changedOn = DateTime.UtcNow;
            var content = JsonConvert.SerializeObject(_data);
            File.WriteAllText(ProjectFile, content);
        }
    }
}
