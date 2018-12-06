using Newtonsoft.Json;
using PEngine.Common.Data;
using System;
using System.IO;

namespace PEngine.Common
{
    public sealed class Project
    {
        public static Project ActiveProject { get; private set; }

        private ProjectData _data;

        public string BaseDirectory { get; private set; }
        private string ProjectFile => Path.Combine(BaseDirectory, "project.json");

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
            };
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

        public void Save()
        {
            // create project dir
            if (!Directory.Exists(BaseDirectory))
            {
                Directory.CreateDirectory(BaseDirectory);
            }

            // create basic directories for the project
            foreach (var dir in new[] {
                "content",
                "content/textures",
                "data",
                "data/maps",
                "data/scripts" })
            {
                var dirPath = Path.Combine(BaseDirectory, dir);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }

            _data.changedOn = DateTime.UtcNow;
            var content = JsonConvert.SerializeObject(_data);
            File.WriteAllText(ProjectFile, content);
        }
    }
}
