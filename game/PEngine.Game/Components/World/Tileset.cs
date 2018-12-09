﻿using Microsoft.Xna.Framework.Graphics;
using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Common.Interop;
using PEngine.Game.Content;
using System.Collections.Generic;
using System.Linq;
using static Core;

namespace PEngine.Game.Components.World
{
    internal class Tileset
    {
        private readonly string _id;
        private TilesetData _data;
        private Dictionary<int, TileData> _tileIndex;
        private Dictionary<int, SubtileData> _subtileIndex;

        private Texture2D _texture;
        internal Texture2D Texture
        {
            get
            {
                if (_texture == null)
                {
                    _texture =
                        Controller.ProjectContent.LoadDirect<Texture2D>($"textures/tiles/{_data.texture}.png");
                }
                return _texture;
            }
        }

        internal Tileset(string id)
        {
            _id = id;
        }

        internal void LoadContent()
        {
            var file = Project.ActiveProject.GetFile(_id, ProjectFileType.Tileset);
            _data = TilesetData.Load(file.path);
            GamePipeline.Write(Pipeline.EVENT_LOAD_TILESET, _id);
            _tileIndex = _data.tiles.ToDictionary(t => t.id, t => t);
            _subtileIndex = _data.subtiles.ToDictionary(t => t.id, t => t);
        }

        internal TileData GetTile(int id)
        {
            return _tileIndex[id];
        }

        internal SubtileData GetSubtile(int id)
        {
            return _subtileIndex[id];
        }
    }
}
