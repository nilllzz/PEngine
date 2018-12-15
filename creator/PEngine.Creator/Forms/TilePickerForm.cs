using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game.Tilesets;
using PEngine.Creator.Components.Projects;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class TilePickerForm : Form
    {
        private readonly TilesetData _tileset;
        private readonly ProjectEventBus _eventBus;
        private readonly string _name;

        public TileData SelectedTile { get; set; }

        public TilePickerForm(string name, TilesetData tileset)
        {
            InitializeComponent();

            _name = name;
            _tileset = tileset;

            _eventBus = new ProjectEventBus();
            RegisterEvents();

            InitData();
        }

        private void TilePickerForm_Shown(object sender, System.EventArgs e)
        {
            _eventBus.SelectedTile(_tileset, SelectedTile);
            lbl_tileset_name.Text = $"Tileset: {_name}";
        }

        private void RegisterEvents()
        {
            _eventBus.TileSelected += _eventBus_TileSelected;
        }

        private void _eventBus_TileSelected(TilesetData tileset, TileData tile)
        {
            SelectedTile = tile;
            btn_ok.Enabled = SelectedTile != null;
        }

        private void InitData()
        {
            foreach (var tile in _tileset.tiles)
            {
                var tileComp = new TileComponent(_eventBus, _tileset, tile);
                panel_tile_container.Controls.Add(tileComp);
            }
        }

        private void TilePickerForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
