using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game.Tilesets;
using PEngine.Creator.Components.Projects;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Maps
{
    internal partial class MapEditorTiles : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly MapData _parent;
        private readonly TilesetData _data;

        internal MapEditorTiles(ProjectEventBus eventBus, MapData parent, TilesetData data)
        {
            InitializeComponent();

            _parent = parent;
            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            InitData();
        }

        #region events

        private void RegisterEvents()
        {

        }

        public void UnregisterEvents()
        {

        }

        #endregion

        #region ui

        private void tool_tiles_view_Click(object sender, EventArgs e)
        {
            var file = Project.ActiveProject.GetFile(_data.id);
            if (file != null)
            {
                _eventBus.RequestFileOpen(file);
            }
        }

        #endregion

        private void InitData()
        {
            panel_tiles_container.Controls.Clear();

            foreach (var tileData in _data.tiles)
            {
                var tileComp = new TileComponent(_eventBus, _data, tileData);
                panel_tiles_container.Controls.Add(tileComp);
            }
        }
    }
}
