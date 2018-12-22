using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Maps
{
    internal partial class MapEditorEvents : UserControl, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly MapData _map;

        private MapEventData _selectedEvent;

        internal MapEditorEvents(ProjectEventBus eventBus, MapData map)
        {
            InitializeComponent();

            _map = map;

            _eventBus = eventBus;
            RegisterEvents();

            UpdateSelectedEvent();
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.EventSelected += _eventBus_EventSelected;
            _eventBus.EventRemoved += _eventBus_EventRemoved;
        }

        private void _eventBus_EventRemoved(MapData map, MapEventData mapEvent)
        {
            if (map.id == _map.id)
            {
                if (_selectedEvent != null && _selectedEvent.Equals(mapEvent))
                {
                    _selectedEvent = null;
                }
                UpdateSelectedEvent();
            }
        }

        public void UnregisterEvents()
        {
            _eventBus.EventSelected -= _eventBus_EventSelected;
        }

        private void _eventBus_EventSelected(MapData map, MapEventData mapEvent)
        {
            if (map.id == _map.id)
            {
                _selectedEvent = mapEvent;
                UpdateSelectedEvent();
            }
        }

        #endregion

        #region ui

        private void chk_warp_CheckedChanged(object sender, EventArgs e)
        {
            ChangedEventType();
        }

        private void chk_script_CheckedChanged(object sender, EventArgs e)
        {
            ChangedEventType();
        }

        private void combo_select_event_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEvent = _map.events[combo_select_event.SelectedIndex];
            _eventBus.SelectEvent(_map, selectedEvent);
        }

        private void btn_event_target_select_Click(object sender, EventArgs e)
        {
            var selectFileForm = new SelectFileForm();
            selectFileForm.FileTypeFilter =
                _selectedEvent.EventType == MapEventType.Warp ?
                new[] { ProjectFileType.Map } :
                new[] { ProjectFileType.Script };
            var result = selectFileForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var file = selectFileForm.SelectedFile;
                _selectedEvent.target = file.id;
                UpdateSelectedEvent();
            }
        }

        private void btn_event_target_open_Click(object sender, EventArgs e)
        {
            if (_selectedEvent.target != null)
            {
                var file = Project.ActiveProject.GetFile(_selectedEvent.target);
                _eventBus.RequestFileOpen(file);
            }
        }

        #endregion

        private void ChangedEventType()
        {
            if (chk_warp.Checked)
            {
                _eventBus.ChangedEventType(_map, MapEventType.Warp);
            }
            else if (chk_script.Checked)
            {
                _eventBus.ChangedEventType(_map, MapEventType.Script);
            }
        }

        private void UpdateEventList()
        {
            // stop event handling before this
            combo_select_event.SelectedIndexChanged -= combo_select_event_SelectedIndexChanged;

            combo_select_event.Items.Clear();
            for (var i = 0; i < _map.events.Length; i++)
            {
                var eventData = _map.events[i];
                combo_select_event.Items.Add(eventData.name);
                if (eventData.Equals(_selectedEvent))
                {
                    combo_select_event.SelectedIndex = i;
                }
            }

            combo_select_event.SelectedIndexChanged += combo_select_event_SelectedIndexChanged;
        }

        private void UpdateSelectedEvent()
        {
            UpdateEventList();
            group_event_props.Controls.Clear();
            if (_selectedEvent == null)
            {
                pic_event_type.Image = null;
                lbl_event_name.Text = "<No event selected>";
                txt_event_target.Text = "";
            }
            else
            {
                pic_event_type.Image = MapService.GetEventTexture(_selectedEvent.EventType);
                lbl_event_name.Text = _selectedEvent.name;

                Control eventProps = new Panel();
                if (_selectedEvent.EventType == MapEventType.Warp)
                {
                    eventProps = new WarpEventEditor(_eventBus, _map, _selectedEvent);
                }
                else if (_selectedEvent.EventType == MapEventType.Script)
                {
                    eventProps = new ScriptEventEditor();
                }

                if (_selectedEvent.target != null)
                {
                    var file = Project.ActiveProject.GetFile(_selectedEvent.target);
                    if (file != null)
                    {
                        txt_event_target.Text = file.name;
                    }
                    else
                    {
                        txt_event_target.Text = _selectedEvent.target;
                    }
                }
                else
                {
                    eventProps.Enabled = false;
                    txt_event_target.Text = "";
                }

                eventProps.Dock = DockStyle.Fill;
                group_event_props.Controls.Add(eventProps);
            }

            btn_event_target_open.Enabled = _selectedEvent != null;
            btn_event_target_select.Enabled = _selectedEvent != null;
        }
    }
}
