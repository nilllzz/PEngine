using PEngine.Creator.Components.Projects;
using PEngine.Creator.Helpers;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    public partial class TextureViewer : ProjectTabComponent
    {
        private readonly ProjectItem _item;

        public override bool CanSave => false;
        public override string FilePath => _item.FilePath;
        public override string Identifier => _item.Identifier;
        public override int IconIndex => ICON_IMAGE;

        public TextureViewer(ProjectItem item)
        {
            InitializeComponent();

            _item = item;
            LoadTexture();

            Title = Path.GetFileName(_item.FilePath);
        }

        private void LoadTexture()
        {
            pic_texture.Image = new Bitmap(_item.FilePath);
        }

        #region ui

        private void btn_reveal_Click(object sender, System.EventArgs e)
        {
            ExplorerHelper.OpenWithFileSelected(_item.FilePath);
        }

        private void chk_stretch_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chk_stretch.Checked)
            {
                pic_texture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pic_texture.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        #endregion
    }
}
