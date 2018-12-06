using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static Core;

namespace PEngine.Game.Content
{
    internal static class ContentLoader
    {
        private static Dictionary<string, object> _resourceBuffer = new Dictionary<string, object>();
        private static Dictionary<Type, Func<string, object>> _loaders;

        public static void Clear()
        {
            _resourceBuffer.Clear();
        }

        public static void ClearBuffer(string objKey = null)
        {
            if (objKey == null)
            {
                _resourceBuffer.Clear();
            }
            else
            {
                var key = objKey.ToLower();
                if (_resourceBuffer.ContainsKey(key))
                {
                    _resourceBuffer.Remove(key);
                }
            }
        }

        public static string GetPath(ContentManager content, string file)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, content.RootDirectory, file);

        private static void InitializeLoaders()
        {
            _loaders = new Dictionary<Type, Func<string, object>>()
            {
                { typeof(Texture2D), LoadImage },
                { typeof(string), LoadText }
            };
        }

        [DebuggerStepThrough]
        public static T LoadDirect<T>(this ContentManager content, string file)
        {
            if (_loaders == null)
            {
                InitializeLoaders();
            }

            var key = file.ToLower();
            if (!_resourceBuffer.TryGetValue(key, out var resource))
            {
                var path = GetPath(content, file);

                resource = _loaders[typeof(T)](path);
                _resourceBuffer.Add(key, resource);
            }

            return (T)resource;
        }

        [DebuggerStepThrough]
        private static object LoadImage(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return Texture2D.FromStream(Controller.GraphicsDevice, stream);
            }
        }

        [DebuggerStepThrough]
        private static object LoadText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
