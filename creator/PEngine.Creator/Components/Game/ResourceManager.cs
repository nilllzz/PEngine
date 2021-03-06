﻿using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace PEngine.Creator.Components.Game
{
    internal class LoadedTexture
    {
        private readonly ProjectFileData _file;
        private readonly FileSystemWatcher _fileWatcher;

        private readonly Dictionary<string, Bitmap> _subTextures =
            new Dictionary<string, Bitmap>();

        internal Bitmap Texture { get; private set; }

        internal LoadedTexture(ProjectFileData file)
        {
            _file = file;
            LoadTexture();

            _fileWatcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(_file.FilePath),
                Filter = Path.GetFileName(_file.FilePath)
            };

            _fileWatcher.Changed += OnChanged;
        }

        private void LoadTexture()
        {
            Texture = ResourceManager.BitmapFromFile(_file);
            _subTextures.Clear();
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            LoadTexture();
        }

        internal void AddSubTexture(string key, Bitmap texture)
        {
            _subTextures.Add(key, texture);
        }

        internal bool TryGetSubTexture(string key, out Bitmap texture)
        {
            return _subTextures.TryGetValue(key, out texture);
        }
    }

    internal static class ResourceManager
    {
        private const int SUBTILE_TEXTURE_SIZE = 16;

        private static readonly Dictionary<string, LoadedTexture> _textureCache =
            new Dictionary<string, LoadedTexture>();

        internal static Bitmap BitmapFromFile(ProjectFileData file)
        {
            var bytes = File.ReadAllBytes(file.FilePath);
            using (var ms = new MemoryStream(bytes))
            {
                return new Bitmap(ms);
            }
        }

        internal static void Unload()
        {
            _textureCache.Clear();
        }

        internal static LoadedTexture GetTilesetTexture(TilesetData tileset)
        {
            var file = Project.ActiveProject.GetFile(tileset.texture);
            var path = file.FilePath;
            var key = "TILESET|" + path.ToUpper();
            if (!_textureCache.TryGetValue(key, out var loadedTextureFile))
            {
                loadedTextureFile = new LoadedTexture(file);
                _textureCache.Add(key, loadedTextureFile);
            }
            return loadedTextureFile;
        }

        internal static Bitmap GetSubtileTexture(TilesetData tileset, SubtileData subtile)
        {
            var key = $"SUBTILE|{tileset.texture}|{subtile.texture[0]}|{subtile.texture[1]}";
            var tilesetTexture = GetTilesetTexture(tileset);
            if (!tilesetTexture.TryGetSubTexture(key, out var texture))
            {
                texture = tilesetTexture.Texture.Clone(new Rectangle(
                    subtile.texture[0] * SUBTILE_TEXTURE_SIZE,
                    subtile.texture[1] * SUBTILE_TEXTURE_SIZE,
                    SUBTILE_TEXTURE_SIZE,
                    SUBTILE_TEXTURE_SIZE
                ), tilesetTexture.Texture.PixelFormat);
                tilesetTexture.AddSubTexture(key, texture);
            }
            return texture;
        }

        internal static Color[] GetPixels(Bitmap bmp, Rectangle? rect = null)
        {
            // use entire bmp as default
            if (!rect.HasValue)
            {
                rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            }

            // pin data and marshal into byte arr
            var data = bmp.LockBits(rect.Value, ImageLockMode.ReadOnly, bmp.PixelFormat);
            var length = data.Stride * data.Height;

            var bytes = new byte[length];

            Marshal.Copy(data.Scan0, bytes, 0, length);
            bmp.UnlockBits(data);

            // convert bytes to colors
            var colors = new Color[bytes.Length / 4];
            for (var i = 0; i < colors.Length; i++)
            {
                var idx = i * 4;
                var a = bytes[idx + 3];
                var r = bytes[idx + 2];
                var g = bytes[idx + 1];
                var b = bytes[idx];
                colors[i] = Color.FromArgb(a, r, g, b);
            }
            return colors;
        }
    }
}
