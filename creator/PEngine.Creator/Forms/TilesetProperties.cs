using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    internal partial class TilesetProperties : Form
    {
        private readonly TilesetData _data;
        private ProjectFileData[] _textureFiles;

        public ProjectFileData SelectedTextureFile { get; private set; }

        internal TilesetProperties(TilesetData data)
        {
            InitializeComponent();

            _data = data;

            LoadTextures();
        }

        private void LoadTextures()
        {
            _textureFiles = Project.ActiveProject.GetFiles(ProjectFileType.TextureTileset);

            for (var i = 0; i < _textureFiles.Length; i++)
            {
                var file = _textureFiles[i];
                combo_texture.Items.Add(file.name);
                if (_data.texture == file.id)
                {
                    combo_texture.SelectedIndex = i;
                }
            }
        }

        private void combo_texture_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SelectedTextureFile = _textureFiles[combo_texture.SelectedIndex];
            var texture = ResourceManager.BitmapFromFile(SelectedTextureFile.FilePath);
            pic_texture_preview.Image = texture;
        }
    }
}
