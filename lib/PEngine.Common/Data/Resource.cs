﻿using Newtonsoft.Json;
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

        public static T Load(string filename)
        {
            var resource = GetResourceInstance();
            var dir = GetResourceRootDirectory(resource);
            var filePath = Path.Combine(dir, filename);
            var content = File.ReadAllText(filePath);
            var loadedResource = JsonConvert.DeserializeObject<T>(content);
            loadedResource.FileName = filename;
            return loadedResource;
        }

        public static T Create(string filename)
        {
            var resource = Activator.CreateInstance<T>();
            resource.FileName = filename;
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

            var content = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, content);
        }
    }
}
