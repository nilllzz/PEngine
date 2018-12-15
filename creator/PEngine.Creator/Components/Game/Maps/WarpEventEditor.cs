using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Maps
{
    public partial class WarpEventEditor : UserControl
    {
        private readonly MapEventData _eventData;
        private readonly MapData _parent;
        private readonly ProjectEventBus _eventBus;

        internal WarpEventEditor(ProjectEventBus eventBus, MapData parent, MapEventData eventData)
        {
            InitializeComponent();

            _eventData = eventData;
            _parent = parent;
            _eventBus = eventBus;

            InitData();
        }

        private void InitData()
        {
            combo_rot.Items.Add("<No change>");
            foreach (var rot in Enum.GetValues(typeof(ObjectRotation)))
            {
                combo_rot.Items.Add(rot.ToString());
            }

            if (_eventData.WarpPositionData.value == "")
            {
                _eventData.WarpPositionData.IntArr = new[] { 0, 0 };
            }
            if (_eventData.WarpRotationData.value == "")
            {
                combo_rot.SelectedIndex = 0;
            }
            else
            {
                var selectedRotation = DataHelper.ParseEnum<ObjectRotation>(_eventData.WarpRotationData.value);
                combo_rot.SelectedIndex = (int)selectedRotation + 1;
            }

            var pos = _eventData.WarpPositionData.IntArr;
            num_x.Value = pos[0];
            num_y.Value = pos[1];

            num_x.ValueChanged += num_x_ValueChanged;
            num_y.ValueChanged += num_y_ValueChanged;
            combo_rot.SelectedIndexChanged += combo_rot_SelectedIndexChanged;
        }

        private void num_x_ValueChanged(object sender, EventArgs e)
        {
            var pos = _eventData.WarpPositionData.IntArr;
            pos[0] = (int)num_x.Value;
            _eventData.WarpPositionData.IntArr = pos;

            _eventBus.UpdatedMap(_parent);
        }

        private void num_y_ValueChanged(object sender, EventArgs e)
        {
            var pos = _eventData.WarpPositionData.IntArr;
            pos[1] = (int)num_y.Value;
            _eventData.WarpPositionData.IntArr = pos;

            _eventBus.UpdatedMap(_parent);
        }

        private void combo_rot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_rot.SelectedIndex == 0)
            {
                _eventData.WarpRotationData.value = "";
            }
            else
            {
                var rotIndex = combo_rot.SelectedIndex - 1;
                var rotation = (ObjectRotation)rotIndex;
                _eventData.WarpRotationData.value = DataHelper.UnparseEnum(rotation);
            }

            _eventBus.UpdatedMap(_parent);
        }

        private void btn_pick_position_Click(object sender, EventArgs e)
        {
            var mapDataFile = Project.ActiveProject.GetFile(_eventData.target);
            var mapData = MapData.Load(mapDataFile);
            var picker = new PickMapPositionForm(mapData);
            var pos = _eventData.WarpPositionData.IntArr;
            picker.SelectedPosition = new Point(pos[0], pos[1]);
            var result = picker.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                num_x.Value = picker.SelectedPosition.X;
                num_y.Value = picker.SelectedPosition.Y;
            }
        }
    }
}
