using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Common.Data.World;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.World
{
    internal partial class WorldmapEditor : ProjectTabComponent, IEventBusComponent
    {
        private const double MIN_ZOOM = 0.1;
        private const double MAX_ZOOM = 2;

        private readonly WorldmapData _data;

        private double _zoom = 0.5;

        private WorldmapEntry[] Entries
        {
            get
            {
                var entries = new List<WorldmapEntry>();
                foreach (var control in panel_world_container.Controls)
                {
                    if (control is WorldmapEntry entry)
                    {
                        entries.Add(entry);
                    }
                }
                return entries.ToArray();
            }
        }

        internal WorldmapEditor(ProjectEventBus eventBus, ProjectFileData file, WorldmapData data)
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
            _eventBus.MapMoved += _eventBus_MapMoved;
            _eventBus.WorldmapEntryRemoved += _eventBus_WorldmapEntryRemoved;
        }

        public void UnregisterEvents()
        {

        }

        private void _eventBus_MapMoved(WorldmapData worldmap, MapData map)
        {
            if (worldmap.id == _data.id)
            {
                EqualizeNegativePositions();
                HasChanges = true;
            }
        }

        private void _eventBus_WorldmapEntryRemoved(WorldmapData worldmap, WorldmapEntryData entry)
        {
            if (worldmap.id == _data.id)
            {
                var entryToBeRemoved = Entries.First(e => e.Entry.mapId == entry.mapId);
                panel_world_container.Controls.Remove(entryToBeRemoved);
                HasChanges = true;
            }
        }

        #endregion

        #region ui

        private void tool_main_add_map_Click(object sender, System.EventArgs e)
        {
            var selectFileForm = new SelectFileForm();
            selectFileForm.FileTypeFilter = new[] { ProjectFileType.Map };
            var result = selectFileForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var selectedFile = selectFileForm.SelectedFile;
                var mapData = MapData.Load(selectedFile);
                // check that the map is not already on the world map
                if (Entries.All(en => en.Entry.mapId != mapData.id))
                {
                    var mapEntryData = new WorldmapEntryData
                    {
                        mapId = mapData.id,
                        bounds = new[] { 0, 0, 0, 0 }
                    };

                    WorldmapService.AddEntry(_data, mapEntryData);
                    var mapEntry = new WorldmapEntry(_eventBus, _data, mapEntryData, _zoom);
                    panel_world_container.Controls.Add(mapEntry);

                    while (!WorldmapService.IsValidPosition(_data, mapEntryData))
                    {
                        mapEntryData.bounds[0]++;
                    }
                    mapEntry.ResetPositioning();
                    mapEntry.UpdateEntryBounds();
                }
            }
        }

        private void tool_main_zoom_in_Click(object sender, System.EventArgs e)
        {
            UpdateZoom(_zoom + 0.1);
        }

        private void tool_main_zoom_out_Click(object sender, System.EventArgs e)
        {
            UpdateZoom(_zoom - 0.1);
        }

        private void tool_main_zoom_0_Click(object sender, System.EventArgs e)
        {
            UpdateZoom(0.5);
        }

        private void UpdateZoom(double zoom)
        {
            _zoom = zoom;
            if (_zoom < MIN_ZOOM)
            {
                _zoom = MIN_ZOOM;
            }
            else if (_zoom > MAX_ZOOM)
            {
                _zoom = MAX_ZOOM;
            }

            tool_main_zoom_0.Text = (_zoom * 100).ToString() + "%";

            foreach (var entry in Entries)
            {
                entry.Zoom = _zoom;
            }
        }

        #endregion

        private void InitData()
        {
            UpdateZoom(0.5);
            panel_world_container.Controls.Clear();
            foreach (var mapEntryData in _data.entries)
            {
                var mapEntry = new WorldmapEntry(_eventBus, _data, mapEntryData, _zoom);
                panel_world_container.Controls.Add(mapEntry);
            }
        }

        private void EqualizeNegativePositions()
        {
            // due to autoscroll limitations, worldpositions have to always be >= 0.
            // if there are negative positions, everything gets moved into positive again

            var minX = Entries.Min(e => e.Entry.bounds[0]);
            var minY = Entries.Min(e => e.Entry.bounds[1]);

            if (minX < 0)
            {
                var diffX = minX * -1;
                foreach (var entry in Entries)
                {
                    entry.Entry.bounds[0] += diffX;
                }
            }
            if (minY < 0)
            {
                var diffY = minY * -1;
                foreach (var entry in Entries)
                {
                    entry.Entry.bounds[1] += diffY;
                }
            }

            if (minX < 0 || minY < 0)
            {
                foreach (var entry in Entries)
                {
                    entry.ResetPositioning();
                }
            }
        }

        internal override void Save()
        {
            _data.Save();
            HasChanges = false;
        }
    }
}
