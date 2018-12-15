using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Debug;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Game.Maps;
using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class PickMapPositionForm : Form
    {
        private readonly MapData _map;
        private readonly TransparentControl _selector;

        private bool _isMoving = true;
        private Rectangle _mapBounds;
        private Point _selectedPosition;
        public Point SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                MoveSelector();
            }
        }

        public PickMapPositionForm(MapData map)
        {
            InitializeComponent();

            _map = map;
            _mapBounds = MapService.GetMapBounds(_map);

            var texture = MapService.GenerateTexture(_map);
            var pic = new CrispPictureBox
            {
                Location = new Point(0, 0),
                Size = new Size(texture.Width, texture.Height),
                Image = texture
            };
            pic.MouseMove += Pic_MouseMove;
            pic.Click += _selector_Click;
            panel_map_container.Controls.Add(pic);

            _selector = new TransparentControl
            {
                Size = new Size(16, 16),
                Image = Resources.player,
                Location = new Point(0, 0)
            };
            _selector.Click += _selector_Click;
            panel_map_container.Controls.Add(_selector);
            _selector.BringToFront();

            lbl_selected_position.Text = $"Selected Position: {SelectedPosition.X}, {SelectedPosition.Y}";
        }

        private void _selector_Click(object sender, EventArgs e)
        {
            _isMoving = !_isMoving;
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoving)
            {
                var selectedX = (e.Location.X + _mapBounds.X) / 16;
                var selectedY = (e.Location.Y + _mapBounds.Y) / 16;
                SelectedPosition = new Point(selectedX, selectedY);
                lbl_selected_position.Text = $"Selected Position: {selectedX}, {selectedY}";
            }
        }

        private void MoveSelector()
        {
            _selector.Location = new Point(
                SelectedPosition.X * 16 + panel_map_container.AutoScrollPosition.X,
                SelectedPosition.Y * 16 + panel_map_container.AutoScrollPosition.Y);
        }

        private void PickMapPositionForm_Shown(object sender, EventArgs e)
        {
            _isMoving = SelectedPosition == Point.Empty;
        }
    }
}
