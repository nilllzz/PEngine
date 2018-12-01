using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PEngine.Common.Data
{
    abstract public class Resource<T> where T : Resource<T>
    {
        private static readonly Dictionary<Type, Dictionary<string, T>> _cache =
            new Dictionary<Type, Dictionary<string, T>>();
        private static readonly Dictionary<Type, T> _instanceCache =
            new Dictionary<Type, T>();

        // stores which resource types have new resources for which no cache existed at time of creation
        private static readonly Dictionary<Type, List<T>> _createdResources =
            new Dictionary<Type, List<T>>();

        protected Resource() { }

        private bool _createdCheck = false; // check that this resource was created through the Create method (or loaded from fetch)

        // whether all instances of the resources are sourced from a single file
        protected virtual bool IsSingleFileSource => false;
        protected virtual bool IsGameModeResource => true;
        protected abstract string DataSource { get; }
        protected abstract string IdField { get; set; }

        private static string GetResourceRootDirectory(T resource)
        {
            string path;
            if (resource.IsGameModeResource)
            {
                path = "gamemodes/mymode";
            }
            else
            {
                path = "Content";
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path, resource.DataSource);
        }

        private static string GetSourceFilePath(T resource, string identifier)
        {
            if (resource.IsSingleFileSource)
            {
                return GetResourceRootDirectory(resource) + ".json";
            }
            else
            {
                return Path.Combine(GetResourceRootDirectory(resource), identifier) + ".json";
            }
        }

        private static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        private static void WriteFile(string filename, string data)
        {
            File.WriteAllText(filename, data);
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

        private static Dictionary<string, T> GetCache()
        {
            var t = typeof(T);
            if (!_cache.TryGetValue(t, out var cache))
            {
                cache = new Dictionary<string, T>();
                _cache.Add(t, cache);
            }
            return cache;
        }

        public static T FetchOne(string identifier)
        {
            var resource = GetResourceInstance();
            var type = typeof(T);

            if (resource.IsSingleFileSource)
            {
                // if not yet sourced, load all
                if (!_cache.TryGetValue(type, out _))
                {
                    var data = ReadFile(GetSourceFilePath(resource, identifier));
                    var sourcedResources = JsonConvert.DeserializeObject<T[]>(data);
                    foreach (var r in sourcedResources)
                    {
                        r._createdCheck = true;
                    }
                    _cache.Add(type, sourcedResources.ToDictionary(r => r.IdField, r => r));
                }
            }
            else
            {
                var cache = GetCache();
                if (!cache.TryGetValue(identifier, out _))
                {
                    var data = ReadFile(GetSourceFilePath(resource, identifier));
                    var sourcedResource = JsonConvert.DeserializeObject<T>(data);
                    sourcedResource._createdCheck = true;
                    cache.Add(sourcedResource.IdField, sourcedResource);
                }
            }

            return _cache[type][identifier];
        }

        public static T[] FetchMulti(params string[] identifiers)
        {
            return identifiers.Select(id => FetchOne(id)).ToArray();
        }

        public static T[] FetchAll()
        {
            var resource = GetResourceInstance();
            var type = typeof(T);

            if (resource.IsSingleFileSource)
            {
                // single file resources always have either none or all resources in cache
                if (!_cache.TryGetValue(type, out var cache))
                {
                    var data = ReadFile(GetSourceFilePath(resource, null));
                    var sourcedResources = JsonConvert.DeserializeObject<T[]>(data);
                    foreach (var r in sourcedResources)
                    {
                        r._createdCheck = true;
                    }
                    cache = sourcedResources.ToDictionary(r => r.IdField, r => r);
                    _cache.Add(type, cache);
                }
                return cache.Values.ToArray();
            }
            else
            {
                // enumrate all files in the folder
                var directory = GetResourceRootDirectory(resource);
                var files = Directory.GetFiles(directory, "*.json", SearchOption.TopDirectoryOnly);
                var cache = GetCache();
                foreach (var file in files)
                {
                    var data = ReadFile(file);
                    var sourcedResource = JsonConvert.DeserializeObject<T>(data);
                    if (!cache.ContainsKey(sourcedResource.IdField))
                    {
                        sourcedResource._createdCheck = true;
                        cache.Add(sourcedResource.IdField, sourcedResource);
                    }
                }
                return cache.Values.ToArray();
            }
        }

        public static T Create(string identifier)
        {
            // check for valid identifier
            if (!identifier.All(c => char.IsLetterOrDigit(c)))
            {
                throw new Exception($"Invalid identifier '{identifier}'.");
            }

            var r = Activator.CreateInstance<T>();
            var t = typeof(T);
            r.IdField = identifier;
            r._createdCheck = true;

            // if it's a single file resource we can't create a new cache
            if (r.IsSingleFileSource && !_cache.ContainsKey(t))
            {
                if (!_createdResources.TryGetValue(t, out var list))
                {
                    list = new List<T>();
                    _createdResources.Add(t, list);
                }
                list.Add(r);
            }
            else
            {
                var cache = GetCache();
                cache.Add(identifier, r);
            }

            return r;
        }

        public static T[] CreateMulti(params string[] identifiers)
        {
            return identifiers.Select(id => Create(id)).ToArray();
        }

        public static void SaveMulti(IEnumerable<T> resources)
        {
            if (resources.Count() == 0)
            {
                return;
            }

            var r = resources.ElementAt(0);
            if (r.IsSingleFileSource)
            {
                // for single file resources, we only need to save once
                // check that all resources were created correctly
                if (resources.Any(rr => !rr._createdCheck))
                {
                    throw new Exception("One of the passed in resources has not been created properly.");
                }
                r.Save();
            }
            else
            {
                foreach (var resource in resources)
                {
                    resource.Save();
                }
            }
        }

        public void Save()
        {
            if (!_createdCheck)
            {
                throw new Exception("This resource has not been created properly");
            }

            if (IsSingleFileSource)
            {
                // gather all resources and then save them including this one to the file
                var t = GetType();
                if (!_cache.ContainsKey(t))
                {
                    FetchAll();
                }
                var cache = GetCache();

                // add newly created resources to the cache and clear them
                if (_createdResources.TryGetValue(t, out var list))
                {
                    list.ForEach(r => cache.Add(r.IdField, r));
                    _createdResources.Remove(t);
                }

                var resources = cache.Values.OrderBy(r => r.IdField).ToArray();
                var data = JsonConvert.SerializeObject(resources);
                WriteFile(GetSourceFilePath((T)this, IdField), data);
            }
            else
            {
                var data = JsonConvert.SerializeObject(this);
                WriteFile(GetSourceFilePath((T)this, IdField), data);
            }
        }
    }
}
