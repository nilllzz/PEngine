using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class MapEditor : ProjectTabComponent, IEventBusComponent
    {
        private readonly MapData _data;

        internal override int IconIndex => ICON_MAP;

        private MapPainter Painter
        {
            get
            {
                if (panel_map_container.Controls.Count == 1 &&
                    panel_map_container.Controls[0] is MapPainter painter)
                {
                    return painter;
                }
                return null;
            }
        }

        internal MapEditor(ProjectEventBus eventBus, ProjectFileData file, MapData data)
            : base(eventBus, file)
        {
            InitializeComponent();

            _data = data;

            RegisterEvents();

            InitData();
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.MapUpdated += _eventBus_MapUpdated;
        }

        public void UnregisterEvents()
        {
            _eventBus.MapUpdated -= _eventBus_MapUpdated;
        }

        private void _eventBus_MapUpdated(MapData map)
        {
            if (map.id == _data.id)
            {
                HasChanges = true;
            }
        }

        #endregion

        #region ui

        private void tool_map_resize_Click(object sender, System.EventArgs e)
        {
            if (Painter != null)
            {
                var resizeForm = new ResizeMapForm();
                resizeForm.SelectedOrigin = Painter.MapOrigin;
                resizeForm.SelectedSize = Painter.MapSize;
                var result = resizeForm.ShowDialog(MainForm.Instance);
                if (result == DialogResult.OK)
                {
                    Painter.SetMapEditorData(resizeForm.SelectedOrigin, resizeForm.SelectedSize);
                }
            }
        }

        private void tool_map_tool_create_Click(object sender, System.EventArgs e)
        {
            Painter.Mode = MapPainterMode.Create;
            UpdateCheckedToolStates();
        }

        private void tool_map_tool_erase_Click(object sender, System.EventArgs e)
        {
            Painter.Mode = MapPainterMode.Erase;
            UpdateCheckedToolStates();
        }

        private void tool_map_tool_pick_Click(object sender, System.EventArgs e)
        {
            Painter.Mode = MapPainterMode.Pick;
            UpdateCheckedToolStates();
        }

        private void tool_map_tool_fill_Click(object sender, System.EventArgs e)
        {
            Painter.Mode = MapPainterMode.Fill;
            UpdateCheckedToolStates();
        }

        private void UpdateCheckedToolStates()
        {
            tool_map_tool_create.Checked = Painter.Mode == MapPainterMode.Create;
            tool_map_tool_erase.Checked = Painter.Mode == MapPainterMode.Erase;
            tool_map_tool_pick.Checked = Painter.Mode == MapPainterMode.Pick;
            tool_map_tool_fill.Checked = Painter.Mode == MapPainterMode.Fill;
        }

        private void tool_map_grid_Click(object sender, System.EventArgs e)
        {
            Painter.GridEnabled = !Painter.GridEnabled;
            tool_map_grid.Checked = Painter.GridEnabled;
        }

        #endregion

        private void InitData()
        {
            panel_map_container.Controls.Clear();
            split_main.Panel2.Controls.Clear();

            panel_map_container.Controls.Add(new MapPainter(_eventBus, _data));

            var tilesetFile = Project.ActiveProject.GetFile(_data.tileset);
            var tilesetData = TilesetData.Load(tilesetFile.path);
            var tiles = new MapEditorTiles(_eventBus, _data, tilesetData);
            tiles.Dock = DockStyle.Fill;
            split_main.Panel2.Controls.Add(tiles);
        }

        internal override void Save()
        {
            _data.Save();
            HasChanges = false;
        }
    }
}
