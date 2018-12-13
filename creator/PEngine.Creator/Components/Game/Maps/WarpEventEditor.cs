using PEngine.Common.Data.Maps;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Maps
{
    public partial class WarpEventEditor : UserControl
    {
        private readonly MapEventData _eventData;

        public WarpEventEditor(MapEventData eventData)
        {
            InitializeComponent();

            _eventData = eventData;
            InitData();
        }

        private void InitData()
        {
            if (_eventData.WarpPositionData.value == "")
            {
                _eventData.WarpPositionData.IntArr = new[] { 0, 0 };
            }
            if (_eventData.WarpWalkOutData.value == "")
            {
                _eventData.WarpWalkOutData.Bool = true;
            }

            var pos = _eventData.WarpPositionData.IntArr;
            num_x.Value = pos[0];
            num_y.Value = pos[1];
            chk_walkout.Checked = _eventData.WarpWalkOutData.Bool;
        }

        private void num_x_ValueChanged(object sender, System.EventArgs e)
        {
            var pos = _eventData.WarpPositionData.IntArr;
            pos[0] = (int)num_x.Value;
            _eventData.WarpPositionData.IntArr = pos;
        }

        private void num_y_ValueChanged(object sender, System.EventArgs e)
        {
            var pos = _eventData.WarpPositionData.IntArr;
            pos[1] = (int)num_y.Value;
            _eventData.WarpPositionData.IntArr = pos;
        }

        private void chk_walkout_CheckedChanged(object sender, System.EventArgs e)
        {
            _eventData.WarpWalkOutData.Bool = chk_walkout.Checked;
        }
    }
}
