using Newtonsoft.Json;
using PEngine.Common.Data;
using System;
using System.IO;

namespace PEngine.Common
{
    public sealed class Project
    {
        private ProjectData _data;

        public string SourceDirectory { get; private set; }
        private string ProjectFile => Path.Combine(SourceDirectory, "project.json");

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
            SourceDirectory = projectPath;
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
            }
            else
            {
                throw new Exception($"The project file does not exist. '{ProjectFile}'");
            }
        }

        public void Save()
        {
            // create project dir
            if (!Directory.Exists(SourceDirectory))
            {
                Directory.CreateDirectory(SourceDirectory);
            }

            // create basic directories for the project
            foreach (var dir in new[] { "content", "data" })
            {
                var dirPath = Path.Combine(SourceDirectory, dir);
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
