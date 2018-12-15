using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Maps
{
    internal partial class MapEditor : ProjectTabComponent, IEventBusComponent
    {
        private readonly MapData _data;

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

        private MapEditorLayer _activeLayer = MapEditorLayer.Tiles;

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

        private void tool_map_layer_objects_Click(object sender, System.EventArgs e)
        {
            _activeLayer = MapEditorLayer.Objects;
            UpdateLayer();
        }

        private void tool_map_layer_tiles_Click(object sender, System.EventArgs e)
        {
            _activeLayer = MapEditorLayer.Tiles;
            UpdateLayer();
        }

        private void tool_map_layer_events_Click(object sender, System.EventArgs e)
        {
            _activeLayer = MapEditorLayer.Events;
            UpdateLayer();
        }

        #endregion

        private void InitData()
        {
            panel_map_container.Controls.Clear();
            split_main.Panel2.Controls.Clear();

            panel_map_container.Controls.Add(new MapPainter(_eventBus, _data));

            UpdateLayer();
        }

        private void UpdateLayer()
        {
            tool_map_layer_tiles.Checked = _activeLayer == MapEditorLayer.Tiles;
            tool_map_layer_objects.Checked = _activeLayer == MapEditorLayer.Objects;
            tool_map_layer_events.Checked = _activeLayer == MapEditorLayer.Events;

            split_main.Panel2.Controls.Clear();
            Painter.ActiveLayer = _activeLayer;
            switch (_activeLayer)
            {
                case MapEditorLayer.Tiles:
                    var tilesetFile = Project.ActiveProject.GetFile(_data.tileset);
                    var tilesetData = TilesetData.Load(tilesetFile);
                    var tiles = new MapEditorTiles(_eventBus, _data, tilesetData);
                    tiles.Dock = DockStyle.Fill;
                    split_main.Panel2.Controls.Add(tiles);
                    break;

                case MapEditorLayer.Objects:
                    break;

                case MapEditorLayer.Events:
                    var events = new MapEditorEvents(_eventBus, _data);
                    events.Dock = DockStyle.Fill;
                    split_main.Panel2.Controls.Add(events);
                    break;
            }
        }

        internal override void Save()
        {
            _data.Save();
            HasChanges = false;
        }

        private void tool_map_fill_tile_Click(object sender, System.EventArgs e)
        {
            var tilesetFile = Project.ActiveProject.GetFile(_data.tileset);
            var tileset = TilesetData.Load(tilesetFile);
            var picker = new TilePickerForm(tilesetFile.name, tileset);

            if (_data.fillTileId.HasValue)
            {
                picker.SelectedTile = tileset.tiles.FirstOrDefault(t => t.id == _data.fillTileId.Value);
            }

            var result = picker.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _data.fillTileId = picker.SelectedTile.id;
                HasChanges = true;
            }
        }
    }
}
