using PEngine.Creator.Components.Projects;
using PEngine.Creator.Helpers;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class TextureViewer : ProjectTabComponent
    {
        private readonly ProjectItem _item;

        internal override bool CanSave => false;
        internal override string FilePath => _item.FilePath;
        internal override string Identifier => _item.Identifier;
        internal override int IconIndex => ICON_IMAGE;

        internal TextureViewer(ProjectItem item)
        {
            InitializeComponent();

            _item = item;
            LoadTexture();

            Title = _item.FileData.id;
        }

        private void LoadTexture()
        {
            pic_texture.Image = ResourceManager.BitmapFromFile(_item.FilePath);
            pic_texture.SizeMode = PictureBoxSizeMode.Normal;
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
