using Microsoft.Xna.Framework.Graphics;
using PEngine.Common.Data.Maps;
using PEngine.Game.Content;
using System.Collections.Generic;
using System.Linq;
using static Core;

namespace PEngine.Game.Components.World
{
    class Tileset
    {
        private readonly string _id;
        private TilesetData _data;
        private Dictionary<int, TileData> _tileIndex;
        private Dictionary<int, SubtileData> _subtileIndex;

        private Texture2D _texture;
        public Texture2D Texture
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

        public Tileset(string id)
        {
            _id = id;
        }

        public void LoadContent()
        {
            _data = TilesetData.FetchOne(_id);
            _tileIndex = _data.tiles.ToDictionary(t => t.id, t => t);
            _subtileIndex = _data.subtiles.ToDictionary(t => t.id, t => t);
        }

        public TileData GetTile(int id)
        {
            return _tileIndex[id];
        }

        public SubtileData GetSubtile(int id)
        {
            return _subtileIndex[id];
        }
    }
}
