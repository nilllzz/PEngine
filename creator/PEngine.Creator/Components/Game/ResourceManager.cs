﻿using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PEngine.Creator.Components.Game
{
    internal static class ResourceManager
    {
        private const int SUBTILE_TEXTURE_SIZE = 16;

        private static readonly Dictionary<string, Bitmap> _textureCache =
            new Dictionary<string, Bitmap>();

        internal static void Initialize(ProjectEventBus eventBus)
        {
            _textureCache.Clear();
        }

        internal static string GetTilesetTexturePath(TilesetData tileset)
        {
            var file = Project.ActiveProject.GetFile(tileset.texture, ProjectFileType.TextureTileset);
            return GetFilePath(file);
        }

        internal static Bitmap GetTilesetTexture(TilesetData tileset)
        {
            var path = GetTilesetTexturePath(tileset);
            var key = "TILESET|" + path.ToUpper();
            if (!_textureCache.TryGetValue(key, out var texture))
            {
                texture = new Bitmap(path);
                _textureCache.Add(key, texture);
            }
            return texture;
        }

        internal static Bitmap GetSubtileTexture(TilesetData tileset, SubtileData subtile)
        {
            var key = $"SUBTILE|{tileset.texture}|{subtile.texture[0]}|{subtile.texture[1]}";
            if (!_textureCache.TryGetValue(key, out var texture))
            {
                var tilesetTexture = GetTilesetTexture(tileset);
                texture = tilesetTexture.Clone(new Rectangle(
                    subtile.texture[0] * SUBTILE_TEXTURE_SIZE,
                    subtile.texture[1] * SUBTILE_TEXTURE_SIZE,
                    SUBTILE_TEXTURE_SIZE,
                    SUBTILE_TEXTURE_SIZE
                ), tilesetTexture.PixelFormat);
                _textureCache.Add(key, texture);
            }
            return texture;
        }

        internal static string GetFilePath(ProjectFileData fileData)
        {
            return Path.Combine(Project.ActiveProject.BaseDirectory, fileData.path);
        }
    }
}
