using PEngine.Creator.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class TexturePickerForm : Form
    {
        // input
        public int TextureSize { get; set; } = 16;
        public bool SkipEmpty { get; set; } = true;
        public string TexturePath { get; set; }

        // output
        public Rectangle SelectedTextureRectangle { get; set; }

        public TexturePickerForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (TexturePath == null)
            {
                throw new Exception("TexturePath has to be set");
            }
            if (TextureSize <= 0)
            {
                throw new Exception("TextureSize has to be positive");
            }

            // load texture
            var img = new Bitmap(TexturePath);
            // generate textures and show them
            for (var y = 0; y < img.Height; y += TextureSize)
            {
                for (var x = 0; x < img.Width; x += TextureSize)
                {
                    var tex = img.Clone(new Rectangle(x, y, TextureSize, TextureSize), img.PixelFormat);
                    if (!IsFullyTransparent(tex))
                    {
                        var pic = new PictureBox
                        {
                            Image = tex,
                            Size = new Size(32, 32),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = new[] { x, y },
                            Cursor = Cursors.Hand,
                            Padding = new Padding(3),
                        };
                        pic.Click += Pic_Click;
                        if (x == SelectedTextureRectangle.X && y == SelectedTextureRectangle.Y)
                        {
                            SelectTexture(pic);
                        }
                        panel_textures.Controls.Add(pic);
                    }
                }
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            foreach (var control in panel_textures.Controls)
            {
                if (control is PictureBox pic)
                {
                    pic.BackColor = Color.Transparent;
                }
            }

            var selectedPic = (PictureBox)sender;
            SelectTexture(selectedPic);
        }

        private void SelectTexture(PictureBox box)
        {
            box.BackColor = Settings.Default.Color_Highlight;

            var texturePos = (int[])box.Tag;
            SelectedTextureRectangle = new Rectangle(
                texturePos[0],
                texturePos[1],
                TextureSize,
                TextureSize);
        }

        private static bool IsFullyTransparent(Bitmap tex)
        {
            for (var x = 0; x < tex.Width; x++)
            {
                for (var y = 0; y < tex.Height; y++)
                {
                    if (tex.GetPixel(x, y).A > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        private void btn_reveal_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"/select, \"{TexturePath}\"");
        }
    }
}
