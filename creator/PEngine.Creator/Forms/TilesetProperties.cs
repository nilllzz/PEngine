using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    internal partial class TilesetProperties : Form
    {
        private readonly ProjectEventBus _eventBus;
        private readonly TilesetData _data;
        private readonly ProjectFileData _file;
        private ProjectFileData[] _textureFiles;

        internal string Id => _data.id;

        internal bool MadeFileChanges { get; private set; }
        internal bool MadeProjectChanges { get; private set; }

        internal TilesetProperties(ProjectEventBus eventBus, TilesetData data)
        {
            InitializeComponent();

            _data = data;
            _file = Project.ActiveProject.GetFile(_data.id, ProjectFileType.Tileset);
            _eventBus = eventBus;

            LoadTextures();
            txt_id.Text = _data.id;

            MadeFileChanges = false;
            MadeProjectChanges = false;
        }

        private void LoadTextures()
        {
            _textureFiles = Project.ActiveProject.GetFiles(ProjectFileType.TextureTileset);

            foreach (var file in _textureFiles)
            {
                combo_texture.Items.Add(file.id);
                if (_data.texture == file.id)
                {
                    combo_texture.SelectedItem = file.id;
                }
            }
        }

        private void btn_ok_Click(object sender, System.EventArgs e)
        {
            // texture
            if (_data.texture != combo_texture.SelectedItem.ToString())
            {
                _data.texture = combo_texture.SelectedItem.ToString();
                MadeFileChanges = true;
            }

            var newId = txt_id.Text;
            var oldId = _data.id;
            if (_data.id != newId)
            {
                // validate id
                if (!ValidateId(newId))
                {
                    return;
                }

                var existingFile = Project.ActiveProject.GetFile(newId, ProjectFileType.Tileset);
                if (existingFile != null)
                {
                    MessageBox.Show("A tileset with the given id already exists.",
                        "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _data.id = newId;

                MadeFileChanges = true;
                MadeProjectChanges = true;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateId(string newId)
        {
            if (newId.Length == 0)
            {
                MessageBox.Show("Id cannot be empty.",
                    "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (newId.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("The Id contains invalid characters.\nIt cannot contain any of the following characters:\n\n" +
                    string.Join(" ", Path.GetInvalidFileNameChars()), "Tileset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
