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

            InitData();
        }

        private void InitData()
        {
            pic_texture.Image = ResourceManager.BitmapFromFile(File);
            pic_texture.SizeMode = PictureBoxSizeMode.Normal;

            var type = File.FileType.ToString();
            if (type.ToLower().StartsWith("texture"))
            {
                type = type.Remove(0, "texture".Length);
            }
            lbl_type.Text = "Type: " + type;
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
