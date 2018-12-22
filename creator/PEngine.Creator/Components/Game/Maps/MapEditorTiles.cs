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
        private readonly MapPainter _painter;

        internal MapEditorTiles(ProjectEventBus eventBus, MapData parent, TilesetData data, MapPainter painter)
        {
            InitializeComponent();

            _parent = parent;
            _data = data;
            _painter = painter;

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

            UpdateCheckedToolStates();
        }

        private void tool_map_tool_create_Click(object sender, EventArgs e)
        {
            _painter.Mode = MapPainterMode.Create;
            UpdateCheckedToolStates();
        }

        private void tool_map_tool_erase_Click(object sender, EventArgs e)
        {
            _painter.Mode = MapPainterMode.Erase;
            UpdateCheckedToolStates();
        }

        private void tool_map_tool_pick_Click(object sender, EventArgs e)
        {
            _painter.Mode = MapPainterMode.Pick;
            UpdateCheckedToolStates();
        }

        private void tool_map_tool_fill_Click(object sender, EventArgs e)
        {
            _painter.Mode = MapPainterMode.Fill;
            UpdateCheckedToolStates();
        }

        private void UpdateCheckedToolStates()
        {
            tool_map_tool_create.Checked = _painter.Mode == MapPainterMode.Create;
            tool_map_tool_erase.Checked = _painter.Mode == MapPainterMode.Erase;
            tool_map_tool_pick.Checked = _painter.Mode == MapPainterMode.Pick;
            tool_map_tool_fill.Checked = _painter.Mode == MapPainterMode.Fill;
        }
    }
}
