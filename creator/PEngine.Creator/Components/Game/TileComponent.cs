using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class TileComponent : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly TileData _data;
        private readonly TilesetData _parent;

        private bool _isSelected = false;

        internal int TileId => _data.id;

        internal TileComponent(ProjectEventBus eventBus, TilesetData parent, TileData data)
        {
            InitializeComponent();

            _data = data;
            _parent = parent;

            _eventBus = eventBus;
            RegisterEvents();

            SetTile();
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.TileUpdated += _eventBus_TileUpdated;
            _eventBus.TileSelected += _eventBus_TileSelected;
            _eventBus.SubtileUpdated += _eventBus_SubtileUpdated;
        }

        public void UnregisterEvents()
        {
            _eventBus.TileUpdated -= _eventBus_TileUpdated;
            _eventBus.TileSelected -= _eventBus_TileSelected;
            _eventBus.SubtileUpdated -= _eventBus_SubtileUpdated;
        }

        private void _eventBus_SubtileUpdated(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _parent.id && _data.subtiles.Any(s => s == subtile.id))
            {
                SetTile();
            }
        }

        private void _eventBus_TileSelected(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _parent.id)
            {
                if (tile != null && tile.id == _data.id)
                {
                    if (!_isSelected)
                    {
                        BackColor = Settings.Default.Color_Highlight;
                    }
                    _isSelected = true;
                }
                else
                {
                    if (_isSelected)
                    {
                        BackColor = Settings.Default.Color_LightGray;
                    }
                    _isSelected = false;
                }
            }
        }

        private void _eventBus_TileUpdated(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _parent.id && tile.id == _data.id)
            {
                SetTile();
            }
        }

        #endregion

        #region ui

        private void context_tile_duplicate_Click(object sender, System.EventArgs e)
        {
            if (_parent.tiles.Length >= ProjectService.MAX_TILES_IN_SET)
            {
                MessageBox.Show($"One tileset can only contain up to {ProjectService.MAX_TILES_IN_SET} tiles.\n\nRemove an existing tile to add a new one.",
                    "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newTile = new TileData
            {
                id = DataHelper.GetFirstFreeInRange(_parent.tiles.Select(t => t.id)),
                subtiles = (int[])_data.subtiles.Clone(),
            };
            var tiles = _parent.tiles.ToList();
            tiles.Add(newTile);
            _parent.tiles = tiles.ToArray();

            _eventBus.AddedTile(_parent, newTile);
            _eventBus.SelectedTile(_parent, newTile);
        }

        private void context_tile_delete_Click(object sender, System.EventArgs e)
        {
            if (_parent.tiles.Length == 1)
            {
                MessageBox.Show("The last tile in a tileset cannot be removed.", "Tileset",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var result = MessageBox.Show("If this tile is used in any maps referencing this tileset, it gets replaced by either the first tile in this tileset or whichever tile takes its place once you add new ones.\n\nDo you want to proceed?",
                "Tileset", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                return;
            }

            var tiles = _parent.tiles.ToList();
            tiles.Remove(_data);
            _parent.tiles = tiles.ToArray();

            _eventBus.RemovedTile(_parent, _data);
            _eventBus.SelectedTile(_parent, null);
        }

        private void context_tile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _eventBus.SelectedTile(_parent, _data);
        }

        private void TileComponent_Click(object sender, System.EventArgs e)
        {
            _eventBus.SelectedTile(_parent, _data);
        }

        private void pic_texture_Click(object sender, System.EventArgs e)
        {
            _eventBus.SelectedTile(_parent, _data);
        }

        #endregion

        private void SetTile()
        {
            // get subtiles for this tile and render them
            var tileTexture = new Bitmap(32, 32);
            var g = Graphics.FromImage(tileTexture);
            for (var i = 0; i < _data.subtiles.Length; i++)
            {
                var subtileId = _data.subtiles[i];
                var subtileData = _parent.subtiles.First(s => s.id == subtileId);
                var subtileTexture = ResourceManager.GetSubtileTexture(_parent, subtileData);

                var destX = i % 2 * 16;
                var destY = (i < 2 ? 0 : 1) * 16;

                g.DrawImage(subtileTexture, new Rectangle(destX, destY, 16, 16));
            }
            pic_texture.Image = tileTexture;
        }
    }
}
