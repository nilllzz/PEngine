using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    public partial class SubtileComponent : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly TilesetData _parent;
        private readonly SubtileData _data;

        private bool _isSelected = false;

        public int SubtileId => _data.id;

        public SubtileComponent(ProjectEventBus eventBus, TilesetData parent, SubtileData data)
        {
            InitializeComponent();

            _parent = parent;
            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            LoadBehaviors();
            SetSubtile();
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
                SetSubtile();
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

        #endregion

        private void SetSubtile()
        {
            pic_texture.Image = ResourceManager.GetSubtileTexture(_parent, _data);
            var comboValue = DataHelper.ParseEnum<SubtileBehavior>(_data.behavior).ToString();
            if (combo_behavior.SelectedItem == null ||
                comboValue != combo_behavior.SelectedItem.ToString())
            {
                combo_behavior.SelectedItem = comboValue;
            }
        }

        private void LoadBehaviors()
        {
            var behaviors = Enum.GetNames(typeof(SubtileBehavior));
            combo_behavior.Items.AddRange(behaviors);
        }

        #region ui

        private void combo_behavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            var behavior = DataHelper.ParseEnum<SubtileBehavior>(combo_behavior.SelectedItem.ToString());
            _data.behavior = DataHelper.UnparseEnum(behavior);

            _eventBus.UpdatedSubtile(_parent, _data);
        }

        private void pic_texture_Click(object sender, EventArgs e)
        {
            _eventBus.SelectedSubtile(_parent, _data);
        }

        private void btn_remove_Click(object sender, EventArgs e)
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

        private void pic_pick_texture_Click(object sender, EventArgs e)
        {
            var texturePicker = new TexturePickerForm
            {
                TexturePath = ResourceManager.GetTilesetTexturePath(_parent),
                SelectedTextureRectangle = new Rectangle(_data.texture[0] * 16, _data.texture[1] * 16, 16, 16),
            };

            var result = texturePicker.ShowDialog(MainForm.Instance);
            if (result == DialogResult.OK)
            {
                var textureRect = texturePicker.SelectedTextureRectangle;
                _data.texture = new[] { textureRect.X / 16, textureRect.Y / 16 };
                _eventBus.UpdatedSubtile(_parent, _data);
            }
        }

        #endregion
    }
}
