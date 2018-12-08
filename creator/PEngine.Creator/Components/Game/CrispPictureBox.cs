using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class CrispPictureBox : PictureBox
    {
        internal CrispPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            base.OnPaint(pe);
        }
    }
}
