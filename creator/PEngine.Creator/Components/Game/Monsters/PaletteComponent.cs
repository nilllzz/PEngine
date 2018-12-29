using PEngine.Common.Data.Monsters;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game.Monsters
{
    public partial class PaletteComponent : UserControl
    {
        private MonsterSpritePalette _palette;
        private bool _isShiny = false;

        public event Action PaletteChanged;

        public PaletteComponent()
        {
            InitializeComponent();
        }

        #region ui

        private void pic_color1_Click(object sender, System.EventArgs e)
        {
            ChooseColor(0);
        }

        private void pic_color2_Click(object sender, System.EventArgs e)
        {
            ChooseColor(1);
        }

        private void pic_color3_Click(object sender, System.EventArgs e)
        {
            ChooseColor(2);
        }

        private void pic_color4_Click(object sender, System.EventArgs e)
        {
            ChooseColor(3);
        }

        #endregion

        internal void SetData(MonsterSpritePalette palette, bool isShiny)
        {
            _palette = palette;
            _isShiny = isShiny;

            InitData();
        }

        private Color[] GetColors()
        {
            return (_isShiny ? _palette.shiny : _palette.normal)
                .Select(c => Color.FromArgb(c[0], c[1], c[2]))
                .ToArray();
        }

        private void InitData()
        {
            if (_isShiny)
            {
                group_main.Text = "Shiny Palette";
                if (_palette.shiny == null)
                {
                    _palette.shiny = new[] { new[] { 0, 0, 0 }, new[] { 85, 85, 85 }, new[] { 170, 170, 170 }, new[] { 255, 255, 255 } };
                }
            }
            else
            {
                group_main.Text = "Default Palette";
                if (_palette.normal == null)
                {
                    _palette.normal = new[] { new[] { 0, 0, 0 }, new[] { 85, 85, 85 }, new[] { 170, 170, 170 }, new[] { 255, 255, 255 } };
                }
            }

            var pics = new[] { pic_color1, pic_color2, pic_color3, pic_color4 };
            var lbls = new[] { lbl_color1, lbl_color2, lbl_color3, lbl_color4 };
            var colors = GetColors();

            for (var i = 0; i < pics.Length; i++)
            {
                pics[i].Image?.Dispose();
                var bmp = new Bitmap(16, 16);
                var color = colors[i];
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(color);
                }
                pics[i].Image = bmp;
                lbls[i].Text = $"Color {i + 1} ({color.R}, {color.G}, {color.B})";
            }
        }

        private void ChooseColor(int colorIndex)
        {
            var colors = GetColors();
            var color = colors[colorIndex];
            var dialog = new ColorDialog
            {
                Color = color,
                FullOpen = true,
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var paletteColor = new[] { dialog.Color.R, dialog.Color.G, dialog.Color.B }
                    .Select(b => (int)b).ToArray();
                if (_isShiny)
                {
                    _palette.shiny[colorIndex] = paletteColor;
                }
                else
                {
                    _palette.normal[colorIndex] = paletteColor;
                }

                InitData();
                PaletteChanged?.Invoke();
            }
        }
    }
}
