using PEngine.Creator.Components.Game;
using PEngine.Creator.Helpers;
using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    internal partial class TexturePickerForm : Form
    {
        // input
        internal int TextureSize { get; set; } = 16;
        internal bool SkipEmpty { get; set; } = true;
        internal string TexturePath { get; set; }

        // output
        internal Rectangle SelectedTextureRectangle { get; set; }

        internal TexturePickerForm()
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
            var img = ResourceManager.BitmapFromFile(TexturePath);
            // generate textures and show them
            for (var y = 0; y < img.Height; y += TextureSize)
            {
                for (var x = 0; x < img.Width; x += TextureSize)
                {
                    var tex = img.Clone(new Rectangle(x, y, TextureSize, TextureSize), img.PixelFormat);
                    if (!IsFullyTransparent(tex))
                    {
                        var pic = new CrispPictureBox
                        {
                            Image = tex,
                            Size = new Size(32, 32),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = new[] { x, y },
                            Cursor = Cursors.Hand,
                            Padding = new Padding(3),
                        };
                        pic.Click += Pic_Click;
                        pic.DoubleClick += Pic_DoubleClick;
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
            var selectedPic = (PictureBox)sender;
            SelectTexture(selectedPic);
        }

        private void Pic_DoubleClick(object sender, EventArgs e)
        {
            var selectedPic = (PictureBox)sender;
            SelectTexture(selectedPic);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SelectTexture(PictureBox box)
        {
            foreach (var control in panel_textures.Controls)
            {
                if (control is PictureBox pic)
                {
                    pic.BackColor = Color.Transparent;
                }
            }
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
            ExplorerHelper.OpenWithFileSelected(TexturePath);
        }
    }
}
