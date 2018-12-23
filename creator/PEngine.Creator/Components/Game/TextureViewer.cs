using PEngine.Common.Data;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Helpers;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Game
{
    internal partial class TextureViewer : ProjectTabComponent
    {
        internal override bool CanSave => false;

        internal TextureViewer(ProjectEventBus eventBus, ProjectFileData file)
            : base(eventBus, file)
        {
            InitializeComponent();

            LoadTexture();
        }

        private void LoadTexture()
        {
            pic_texture.Image = ResourceManager.BitmapFromFile(File);
            pic_texture.SizeMode = PictureBoxSizeMode.Normal;
        }

        #region ui

        private void btn_reveal_Click(object sender, System.EventArgs e)
        {
            ExplorerHelper.OpenWithFileSelected(File.FilePath);
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
