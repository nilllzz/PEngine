using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class ResizeMapForm : Form
    {
        public Size SelectedSize { get; set; }
        public Point SelectedOrigin { get; set; }

        public ResizeMapForm()
        {
            InitializeComponent();
        }

        private void ResizeMapForm_Load(object sender, EventArgs e)
        {
            num_left.Value = SelectedOrigin.X;
            num_up.Value = SelectedOrigin.Y;
            num_right.Value = SelectedSize.Width;
            num_down.Value = SelectedSize.Height;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            SelectedOrigin = new Point
            {
                X = (int)num_left.Value,
                Y = (int)num_up.Value,
            };
            SelectedSize = new Size
            {
                Width = (int)num_right.Value,
                Height = (int)num_down.Value,
            };
        }
    }
}
