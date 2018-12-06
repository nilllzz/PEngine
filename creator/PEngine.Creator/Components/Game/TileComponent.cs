using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Properties;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    public partial class TileComponent : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly TileData _data;
        private readonly TilesetData _parent;

        private bool _isSelected = false;

        public int TileId => _data.id;

        public TileComponent(ProjectEventBus eventBus, TilesetData parent, TileData data)
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

        private void SetTile()
        {
            // get subtiles for this tile and render them
            for (var i = 0; i < 4; i++)
            {
                var subtileIndex = _data.subtiles[i];
                var subtileData = _parent.subtiles.First(s => s.id == subtileIndex);
                var subtileTexture = ResourceManager.GetSubtileTexture(_parent, subtileData);
                switch (i)
                {
                    case 0:
                        pic_subtile1.Image = subtileTexture;
                        break;
                    case 1:
                        pic_subtile2.Image = subtileTexture;
                        break;
                    case 2:
                        pic_subtile3.Image = subtileTexture;
                        break;
                    case 3:
                        pic_subtile4.Image = subtileTexture;
                        break;
                }
            }
        }

        private void TileComponent_Click(object sender, System.EventArgs e)
        {
            _eventBus.SelectedTile(_parent, _data);
        }
    }
}
