using PEngine.Common;
using PEngine.Common.Data;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Forms.New
{
    public partial class ImportExistingForm : Form
    {
        public ProjectFileType? SelectedFileType
        {
            get
            {
                if (radio_texture_tileset.Checked)
                {
                    return ProjectFileType.TextureTileset;
                }
                else if (radio_texture_character.Checked)
                {
                    return ProjectFileType.TextureCharacter;
                }
                else if (radio_texture_monster.Checked)
                {
                    return ProjectFileType.TextureMonster;
                }
                return null;
            }
        }

        internal string SelectedFilePath { get; private set; } = null;

        public ImportExistingForm()
        {
            InitializeComponent();
        }

        private void ImportExistingForm_Shown(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void SelectFile()
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Select a file to import...",
                Multiselect = false,
                InitialDirectory = Project.ActiveProject.BaseDirectory,
                Filter = "Content Files (*.png)|*.png",
            };
            dialog.CustomPlaces.Add(Project.ActiveProject.BaseDirectory);
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (dialog.FileName != null && dialog.FileName.Length > 0)
                {
                    SelectedFilePath = dialog.FileName;
                }
            }

            if (SelectedFilePath != null)
            {
                lbl_file.Text = SelectedFilePath;
            }
            else
            {
                lbl_file.Text = "<No File Selected>";
            }
            group_type.Enabled = SelectedFilePath != null;

            btn_ok.Enabled = SelectedFileType.HasValue;
        }

        private void radio_texture_tileset_CheckedChanged(object sender, EventArgs e)
        {
            btn_ok.Enabled = SelectedFileType.HasValue;
        }

        private void radio_texture_character_CheckedChanged(object sender, EventArgs e)
        {
            btn_ok.Enabled = SelectedFileType.HasValue;
        }

        private void radio_texture_monster_CheckedChanged(object sender, EventArgs e)
        {
            btn_ok.Enabled = SelectedFileType.HasValue;
        }

        private void btn_select_file_Click(object sender, EventArgs e)
        {
            SelectFile();
        }
    }
}
