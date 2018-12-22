using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Tilesets
{
    internal partial class SubtileComponent : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly TilesetData _parent;
        private readonly SubtileData _data;

        private bool _isSelected = false;

        internal int SubtileId => _data.id;

        internal SubtileComponent(ProjectEventBus eventBus, TilesetData parent, SubtileData data)
        {
            InitializeComponent();

            _data = data;
            _parent = parent;

            _eventBus = eventBus;
            RegisterEvents();

            InitData();
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.SubtileSelected += _eventBus_SubtileSelected;
            _eventBus.SubtileUpdated += _eventBus_SubtileUpdated;
        }

        public void UnregisterEvents()
        {
            _eventBus.SubtileSelected -= _eventBus_SubtileSelected;
            _eventBus.SubtileUpdated -= _eventBus_SubtileUpdated;
        }

        private void _eventBus_SubtileUpdated(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _parent.id)
            {
                InitData();
            }
        }

        private void _eventBus_SubtileSelected(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _parent.id)
            {
                if (subtile != null && _data.id == subtile.id)
                {
                    if (!_isSelected)
                    {
                        BackColor = Settings.Default.Color_Highlight;
                        lbl_behavior.ForeColor = Settings.Default.Color_HighlightText;
                    }
                    _isSelected = true;
                }
                else
                {
                    if (_isSelected)
                    {
                        BackColor = Settings.Default.Color_LightGray;
                        lbl_behavior.ForeColor = Settings.Default.Color_MainText;
                    }
                    _isSelected = false;
                }
            }
        }

        #endregion

        #region ui

        private void pic_texture_Click(object sender, System.EventArgs e)
        {
            _eventBus.SelectedSubtile(_parent, _data);
        }

        private void lbl_behavior_Click(object sender, System.EventArgs e)
        {
            _eventBus.SelectedSubtile(_parent, _data);
        }

        private void SubtileComponent_Click(object sender, System.EventArgs e)
        {
            _eventBus.SelectedSubtile(_parent, _data);
        }

        private void context_subtile_duplicate_Click(object sender, System.EventArgs e)
        {
            if (_parent.subtiles.Length >= TilesetService.MAX_SUBTILES_IN_SET)
            {
                MessageBox.Show($"One tileset can only contain up to {TilesetService.MAX_SUBTILES_IN_SET} subtiles.\n\nRemove an existing subtile to add a new one.",
                    "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newSubtile = new SubtileData
            {
                behavior = _data.behavior,
                id = DataHelper.GetFirstFreeInRange(_parent.subtiles.Select(t => t.id)),
                texture = (int[])_data.texture.Clone()
            };

            var subtiles = _parent.subtiles.ToList();
            subtiles.Add(newSubtile);
            _parent.subtiles = subtiles.ToArray();

            _eventBus.AddedSubtile(_parent, newSubtile);
            _eventBus.SelectedSubtile(_parent, newSubtile);
        }

        private void context_subtile_delete_Click(object sender, System.EventArgs e)
        {
            if (_parent.subtiles.Length == 1)
            {
                MessageBox.Show("You cannot remove the last subtile", "Tileset",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // check if the subtile is in use, if so, prompt user
            var isUsed = _parent.tiles.Any(t => t.subtiles.Contains(_data.id));
            if (isUsed)
            {
                var result = MessageBox.Show("This subtile is being used in tiles of this tileset. Removing it will set those subtiles to the first remaining subtile in the list.\n\nDo you want to proceed?",
                    "Tileset", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    return;
                }

                // replace with first subtile
                var firstSubtileIndex = 0;
                if (_parent.subtiles[0].id == _data.id)
                {
                    firstSubtileIndex = 1;
                }
                var firstSubtileId = _parent.subtiles[firstSubtileIndex].id;
                foreach (var tile in _parent.tiles)
                {
                    var changed = false;
                    for (var i = 0; i < tile.subtiles.Length; i++)
                    {
                        if (tile.subtiles[i] == _data.id)
                        {
                            tile.subtiles[i] = firstSubtileId;
                            changed = true;
                        }
                    }
                    if (changed)
                    {
                        _eventBus.UpdatedTile(_parent, tile);
                    }
                }
            }

            var subtiles = _parent.subtiles.ToList();
            subtiles.Remove(_data);
            _parent.subtiles = subtiles.ToArray();

            _eventBus.RemovedSubtile(_parent, _data);
        }

        private void context_subtile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _eventBus.SelectedSubtile(_parent, _data);
        }

        #endregion

        private void InitData()
        {
            pic_texture.Image = ResourceManager.GetSubtileTexture(_parent, _data);
            lbl_behavior.Text = _data.behavior;
        }
    }
}
