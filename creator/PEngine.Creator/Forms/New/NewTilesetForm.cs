using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game.Tilesets;
using PEngine.Creator.Components.Projects;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Forms.New
{
    public partial class NewTilesetForm : Form
    {
        private ProjectFileData[] _textureFiles;

        internal TilesetData CreatedTileset { get; private set; }
        internal string ChosenName { get; private set; }

        public NewTilesetForm()
        {
            InitializeComponent();

            LoadTextures();

            txt_name.Text = "Tileset";
        }

        private void LoadTextures()
        {
            _textureFiles = Project.ActiveProject.GetFiles(ProjectFileType.TextureTileset);
            foreach (var file in _textureFiles)
            {
                combo_texture.Items.Add(file.name);
            }
            combo_texture.SelectedIndex = 0;
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            btn_ok.Enabled = txt_name.Text.Length > 0;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            var textureFile = _textureFiles[combo_texture.SelectedIndex];
            var id = ProjectService.GenerateFileId(Project.ActiveProject, txt_name.Text);
            CreatedTileset = TilesetService.CreateNew(id, textureFile);
            ChosenName = txt_name.Text;
        }
    }
}
