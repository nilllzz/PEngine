using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using PEngine.Creator.Properties;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    public partial class TilesetEditor : ProjectTabComponent, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly ProjectItem _item;
        private readonly TilesetData _data;

        private TileData _selectedTile;
        private SubtileData _selectedSubtile;
        private bool _tileAddMode = true;

        public override string FilePath => _item.FilePath;
        public override string Identifier => _item.Identifier;
        public override int IconIndex => ICON_TILESET;
        public override ProjectItem ProjectItem => _item;

        public TilesetEditor(ProjectEventBus eventBus, TilesetData data, ProjectItem item)
        {
            InitializeComponent();

            _item = item;
            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            InitData();
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.TileSelected += _eventBus_TileSelected;
            _eventBus.SubtileSelected += _eventBus_SubtileSelected;
            _eventBus.TileUpdated += _eventBus_TileUpdated;
            _eventBus.SubtileAdded += _eventBus_SubtileAdded;
            _eventBus.SubtileRemoved += _eventBus_SubtileRemoved;
            _eventBus.SubtileUpdated += _eventBus_SubtileUpdated;
            _eventBus.TileAdded += _eventBus_TileAdded;
            _eventBus.TileRemoved += _eventBus_TileRemoved;
        }

        public void UnregisterEvents()
        {
            _eventBus.TileSelected -= _eventBus_TileSelected;
            _eventBus.SubtileSelected -= _eventBus_SubtileSelected;
            _eventBus.TileUpdated -= _eventBus_TileUpdated;
            _eventBus.SubtileAdded -= _eventBus_SubtileAdded;
            _eventBus.SubtileRemoved -= _eventBus_SubtileRemoved;
            _eventBus.SubtileUpdated -= _eventBus_SubtileUpdated;
            _eventBus.TileAdded -= _eventBus_TileAdded;
            _eventBus.TileRemoved -= _eventBus_TileRemoved;

            // unregister children
            foreach (var control in panel_tiles_container.Controls)
            {
                if (control is TileComponent tileComp)
                {
                    tileComp.UnregisterEvents();
                }
            }
            foreach (var control in panel_subtile_container.Controls)
            {
                if (control is SubtileComponent subtileComp)
                {
                    subtileComp.UnregisterEvents();
                }
            }
        }

        private void _eventBus_TileAdded(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id)
            {
                var tileComp = new TileComponent(_eventBus, _data, tile);
                panel_tiles_container.Controls.Add(tileComp);

                tool_editor_lbl_tiles.Text = $"Tiles ({_data.tiles.Length})";
                HasChanges = true;
            }
        }

        private void _eventBus_TileRemoved(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id)
            {
                foreach (var control in panel_tiles_container.Controls)
                {
                    if (control is TileComponent comp && comp.TileId == tile.id)
                    {
                        comp.UnregisterEvents();
                        panel_tiles_container.Controls.Remove(comp);
                    }
                }

                tool_editor_lbl_tiles.Text = $"Tiles ({_data.tiles.Length})";
                HasChanges = true;
            }
        }

        private void _eventBus_TileUpdated(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id && _selectedTile != null && tile.id == _selectedTile.id)
            {
                UpdateSelectedTile();
                HasChanges = true;
            }
        }

        private void _eventBus_TileSelected(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id)
            {
                _selectedTile = tile;
                UpdateSelectedTile();
            }
        }

        private void _eventBus_SubtileAdded(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.id)
            {
                var subtileComp = new SubtileComponent(_eventBus, _data, subtile);
                panel_subtile_container.Controls.Add(subtileComp);

                tool_subtiles_lbl_title.Text = $"Subtiles ({_data.subtiles.Length})";
                HasChanges = true;
            }
        }

        private void _eventBus_SubtileRemoved(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.id)
            {
                foreach (var control in panel_subtile_container.Controls)
                {
                    if (control is SubtileComponent comp && comp.SubtileId == subtile.id)
                    {
                        comp.UnregisterEvents();
                        panel_subtile_container.Controls.Remove(comp);
                    }
                }

                if (_selectedSubtile.id == subtile.id)
                {
                    _eventBus.SelectedSubtile(_data, null);
                }

                tool_subtiles_lbl_title.Text = $"Subtiles ({_data.subtiles.Length})";
                HasChanges = true;
            }
        }

        private void _eventBus_SubtileSelected(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.id)
            {
                _selectedSubtile = subtile;
                UpdateSelectedSubtile();
            }
        }

        private void _eventBus_SubtileUpdated(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.id)
            {
                if (_selectedSubtile != null && subtile.id == _selectedSubtile.id)
                {
                    _selectedSubtile = subtile;
                    UpdateSelectedSubtile();

                    HasChanges = true;
                }

                if (_selectedTile != null && _selectedTile.subtiles.Any(s => s == subtile.id))
                {
                    UpdateSelectedTile();
                }
            }
        }

        #endregion

        #region ui

        private void pic_tile_1_Click(object sender, System.EventArgs e)
        {
            if (_tileAddMode)
            {
                PlaceSubtile(0);
            }
            else
            {
                PickSubtile(0);
            }
        }

        private void pic_tile_2_Click(object sender, System.EventArgs e)
        {
            if (_tileAddMode)
            {
                PlaceSubtile(1);
            }
            else
            {
                PickSubtile(1);
            }
        }

        private void pic_tile_3_Click(object sender, System.EventArgs e)
        {
            if (_tileAddMode)
            {
                PlaceSubtile(2);
            }
            else
            {
                PickSubtile(2);
            }
        }

        private void pic_tile_4_Click(object sender, System.EventArgs e)
        {
            if (_tileAddMode)
            {
                PlaceSubtile(3);
            }
            else
            {
                PickSubtile(3);
            }
        }

        private void tool_subtiles_add_Click(object sender, System.EventArgs e)
        {
            if (_data.subtiles.Length >= ProjectService.MAX_SUBTILES_IN_SET)
            {
                MessageBox.Show($"One tileset can only contain up to {ProjectService.MAX_SUBTILES_IN_SET} subtiles.\n\nRemove an existing subtile to add a new one.",
                    "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var subtile = new SubtileData
            {
                behavior = DataHelper.UnparseEnum(SubtileBehavior.Wall),
                id = DataHelper.GetFirstFreeInRange(_data.subtiles.Select(t => t.id)),
                texture = new[] { 0, 0 },
            };

            var subtiles = _data.subtiles.ToList();
            subtiles.Add(subtile);
            _data.subtiles = subtiles.ToArray();

            _eventBus.AddedSubtile(_data, subtile);
        }

        private void tool_editor_add_tile_Click(object sender, System.EventArgs e)
        {
            if (_data.tiles.Length >= ProjectService.MAX_TILES_IN_SET)
            {
                MessageBox.Show($"One tileset can only contain up to {ProjectService.MAX_TILES_IN_SET} tiles.\n\nRemove an existing tile to add a new one.",
                    "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var firstSubtileId = _data.subtiles[0].id;
            var tile = new TileData
            {
                id = DataHelper.GetFirstFreeInRange(_data.tiles.Select(t => t.id)),
                subtiles = new[] { firstSubtileId, firstSubtileId, firstSubtileId, firstSubtileId },
            };

            var tiles = _data.tiles.ToList();
            tiles.Add(tile);
            _data.tiles = tiles.ToArray();

            _eventBus.AddedTile(_data, tile);
        }

        private void btn_remove_tile_Click(object sender, System.EventArgs e)
        {
            if (_data.tiles.Length == 1)
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

            var tiles = _data.tiles.ToList();
            tiles.Remove(_selectedTile);
            _data.tiles = tiles.ToArray();

            _eventBus.RemovedTile(_data, _selectedTile);
            _eventBus.SelectedTile(_data, null);
        }

        private void pic_edit_mode_Click(object sender, System.EventArgs e)
        {
            _tileAddMode = !_tileAddMode;
            if (_tileAddMode)
            {
                pic_edit_mode.Image = Resources.arrow_previous_16xLG;
            }
            else
            {
                pic_edit_mode.Image = Resources.arrow_Next_16xLG;
            }
        }

        private void tool_editor_properties_Click(object sender, System.EventArgs e)
        {
            var tilesetProperties = new TilesetProperties(_eventBus, _data);
            var result = tilesetProperties.ShowDialog(MainForm.Instance);
            if (result == DialogResult.OK)
            {
                if (tilesetProperties.MadeFileChanges)
                {
                    HasChanges = true;
                    InitData();
                }
                if (tilesetProperties.MadeProjectChanges)
                {
                    HasProjectChanges = true;
                }
            }
        }

        private void tool_editor_texture_Click(object sender, System.EventArgs e)
        {
            var textureFile = Project.ActiveProject.GetFile(_data.texture, ProjectFileType.TextureTileset);

            _eventBus.RequestItemOpen(new ProjectItem
            {
                FileData = textureFile,
                ItemType = ProjectItemType.Texture,
            });
        }

        #endregion

        private void InitData()
        {
            Title = _data.id;

            panel_subtile_container.Controls.Clear();
            foreach (var subtile in _data.subtiles)
            {
                var subtileComp = new SubtileComponent(_eventBus, _data, subtile);
                panel_subtile_container.Controls.Add(subtileComp);
            }

            panel_tiles_container.Controls.Clear();
            foreach (var tile in _data.tiles)
            {
                var tileComp = new TileComponent(_eventBus, _data, tile);
                panel_tiles_container.Controls.Add(tileComp);
            }

            tool_subtiles_lbl_title.Text = $"Subtiles ({_data.subtiles.Length})";
            tool_editor_lbl_tiles.Text = $"Tiles ({_data.tiles.Length})";

            _selectedSubtile = null;
            _selectedTile = null;
            UpdateSelectedSubtile();
            UpdateSelectedTile();
        }

        private void UpdateSelectedSubtile()
        {
            group_selected_subtile.Controls.Clear();
            if (_selectedSubtile == null)
            {
                var lbl_no_selection = new Label()
                {
                    Text = "<No Subtile selected>",
                    Location = new Point(16, 32),
                };
                group_selected_subtile.Controls.Add(lbl_no_selection);
            }
            else
            {
                var subtileEditor = new SubtileEditComponent(_eventBus, _data, _selectedSubtile)
                {
                    Location = new Point(12, 20),
                };
                group_selected_subtile.Controls.Add(subtileEditor);
            }
        }

        private void UpdateSelectedTile()
        {
            if (_selectedTile == null)
            {
                pic_tile_1.Image = Resources.subtile;
                pic_tile_2.Image = Resources.subtile;
                pic_tile_3.Image = Resources.subtile;
                pic_tile_4.Image = Resources.subtile;
                return;
            }

            for (var i = 0; i < _selectedTile.subtiles.Length; i++)
            {
                var subtileId = _selectedTile.subtiles[i];
                var subtileData = _data.subtiles.First(s => s.id == subtileId);
                var subtileTexture = ResourceManager.GetSubtileTexture(_data, subtileData);
                switch (i)
                {
                    case 0:
                        pic_tile_1.Image = subtileTexture;
                        break;
                    case 1:
                        pic_tile_2.Image = subtileTexture;
                        break;
                    case 2:
                        pic_tile_3.Image = subtileTexture;
                        break;
                    case 3:
                        pic_tile_4.Image = subtileTexture;
                        break;
                }
            }
        }

        private void PlaceSubtile(int position)
        {
            if (_selectedTile != null && _selectedSubtile != null &&
                _selectedTile.subtiles[position] != _selectedSubtile.id)
            {
                _selectedTile.subtiles[position] = _selectedSubtile.id;
                _eventBus.UpdatedTile(_data, _selectedTile);
            }
        }

        private void PickSubtile(int position)
        {
            if (_selectedTile != null)
            {
                var subtileId = _selectedTile.subtiles[position];
                var subtileData = _data.subtiles.FirstOrDefault(s => s.id == subtileId);
                if (subtileData != null)
                {
                    _eventBus.SelectedSubtile(_data, subtileData);
                }
            }
        }

        public override void Save()
        {
            base.Save();

            _data.Save();

            // update id if it changed
            _item.FileData.id = _data.id;

            HasChanges = false;
        }
    }
}
