using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PEngine.Common.Data
{
    abstract public class Resource<T> where T : Resource<T>
    {
        private static readonly Dictionary<Type, T> _instanceCache =
            new Dictionary<Type, T>();

        [JsonIgnore]
        protected virtual bool IsProjectResource => true;
        [JsonIgnore]
        public string FileName { get; private set; }

        public string id;

        protected abstract string GetDefaultFileName(string id);

        private static string GetValidFilePath(T resource, string id)
        {
            var rootDir = GetResourceRootDirectory(resource);

            var n = 0;
            while (true)
            {
                var pathId = id;
                if (n > 0)
                {
                    pathId += n;
                }
                var path = resource.GetDefaultFileName(pathId);
                var fullPath = Path.GetFullPath(Path.Combine(rootDir, path));
                if (!File.Exists(fullPath))
                {
                    return path;
                }
                n++;
            }
        }

        private static T GetResourceInstance()
        {
            var type = typeof(T);
            if (!_instanceCache.TryGetValue(type, out var instance))
            {
                instance = Activator.CreateInstance<T>();
                _instanceCache.Add(type, instance);
            }
            return instance;
        }

        private static string GetResourceRootDirectory(T resource)
        {
            if (resource.IsProjectResource)
            {
                if (Project.ActiveProject == null)
                {
                    throw new Exception("No active project configured");
                }
                return Project.ActiveProject.BaseDirectory;
            }
            else
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
            }
        }

        public static T Load(ProjectFileData file)
        {
            var resource = GetResourceInstance();
            var dir = GetResourceRootDirectory(resource);
            var filePath = Path.Combine(dir, file.path);
            var content = File.ReadAllText(filePath);
            var loadedResource = JsonConvert.DeserializeObject<T>(content);
            loadedResource.FileName = file.path;
            return loadedResource;
        }

        public static T Create(string id)
        {
            var resource = Activator.CreateInstance<T>();
            resource.FileName = GetValidFilePath(resource, id);
            resource.id = id;
            return resource;
        }

        public void Save()
        {
            var dir = GetResourceRootDirectory((T)this);
            var filePath = Path.Combine(dir, FileName);

            var folder = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.WriteAllText(filePath, ToString());
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
