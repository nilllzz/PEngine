using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using PEngine.Creator.Views.Projects;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    public partial class TilesetEditor : ProjectTabComponent, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private TilesetData _data;

        private TileData _selectedTile;
        private SubtileData _selectedSubtile;

        public TilesetEditor(ProjectEventBus eventBus, TilesetData data)
        {
            InitializeComponent();

            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            SetTileset();
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
        }

        private void _eventBus_TileAdded(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id)
            {
                var tileComp = new TileComponent(_eventBus, _data, tile);
                panel_tiles_container.Controls.Add(tileComp);

                lbl_tiles.Text = $"Tiles ({_data.tiles.Length})";
            }
        }

        private void _eventBus_SubtileUpdated(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.id && _selectedSubtile != null && subtile.id == _selectedSubtile.id)
            {
                _selectedSubtile = subtile;
                UpdateSelectedSubtile();
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

                lbl_subtiles_title.Text = $"Subtiles ({_data.subtiles.Length})";

                if (_selectedSubtile.id == subtile.id)
                {
                    _eventBus.SelectedSubtile(_data, null);
                }
            }
        }

        private void _eventBus_SubtileAdded(TilesetData tileset, SubtileData subtile)
        {
            if (tileset.id == _data.id)
            {
                var subtileComp = new SubtileComponent(_eventBus, _data, subtile);
                panel_subtile_container.Controls.Add(subtileComp);

                lbl_subtiles_title.Text = $"Subtiles ({_data.subtiles.Length})";
            }
        }

        private void _eventBus_TileUpdated(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id && _selectedTile != null && tile.id == _selectedTile.id)
            {
                UpdateSelectedTile();
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

        private void _eventBus_TileSelected(TilesetData tileset, TileData tile)
        {
            if (tileset.id == _data.id)
            {
                _selectedTile = tile;
                UpdateSelectedTile();
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

                lbl_tiles.Text = $"Tiles ({_data.tiles.Length})";
            }
        }

        #endregion

        private void SetTileset()
        {
            Title = _data.id;

            foreach (var subtile in _data.subtiles)
            {
                var subtileComp = new SubtileComponent(_eventBus, _data, subtile);
                panel_subtile_container.Controls.Add(subtileComp);
            }

            foreach (var tile in _data.tiles)
            {
                var tileComp = new TileComponent(_eventBus, _data, tile);
                panel_tiles_container.Controls.Add(tileComp);
            }

            lbl_subtiles_title.Text = $"Subtiles ({_data.subtiles.Length})";
            lbl_tiles.Text = $"Tiles ({_data.tiles.Length})";
        }

        private void UpdateSelectedSubtile()
        {
            if (_selectedSubtile == null)
            {
                lbl_selected_subtile.Text = "No subtile selected";
                pic_selected_subtile.Image = Resources.document_16xLG;
                return;
            }

            var subtileTexture = ResourceManager.GetSubtileTexture(_data, _selectedSubtile);
            pic_selected_subtile.Image = subtileTexture;

            lbl_selected_subtile.Text = $"<{DataHelper.ParseEnum<SubtileBehavior>(_selectedSubtile.behavior).ToString()}>";
        }

        private void UpdateSelectedTile()
        {
            if (_selectedTile == null)
            {
                lbl_tile_title.Text = "(no tile selected)";
                pic_tile_1.Image = Resources.document_16xLG;
                pic_tile_2.Image = Resources.document_16xLG;
                pic_tile_3.Image = Resources.document_16xLG;
                pic_tile_4.Image = Resources.document_16xLG;
                btn_remove_tile.Enabled = false;
                return;
            }

            for (var i = 0; i < _selectedTile.subtiles.Length; i++)
            {
                lbl_tile_title.Text = "Edit selected tile";
                btn_remove_tile.Enabled = true;
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

        #region ui

        private void pic_tile_1_Click(object sender, System.EventArgs e)
        {
            PlaceSubtile(0);
        }

        private void pic_tile_2_Click(object sender, System.EventArgs e)
        {
            PlaceSubtile(1);
        }

        private void pic_tile_3_Click(object sender, System.EventArgs e)
        {
            PlaceSubtile(2);
        }

        private void pic_tile_4_Click(object sender, System.EventArgs e)
        {
            PlaceSubtile(3);
        }

        private void btn_add_subtile_Click(object sender, System.EventArgs e)
        {
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

        private void btn_add_tile_Click(object sender, System.EventArgs e)
        {
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

        #endregion
    }
}
