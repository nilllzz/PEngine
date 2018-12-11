using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Properties;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PEngine.Creator.Forms.New
{
    public partial class NewMapForm : Form
    {
        private ProjectFileData[] _mapFiles;
        private ProjectFileData[] _tilesetFiles;

        public MapData CreatedMapData { get; private set; }

        public NewMapForm()
        {
            InitializeComponent();

            _mapFiles = Project.ActiveProject.GetFiles(ProjectFileType.Map);
            LoadTilesets();

            txt_name.Text = "Default";
        }

        private void LoadTilesets()
        {
            _tilesetFiles = Project.ActiveProject.GetFiles(ProjectFileType.Tileset);
            foreach (var file in _tilesetFiles)
            {
                combo_tileset.Items.Add(file.id);
            }
            combo_tileset.SelectedIndex = 0;
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            if (txt_id.ReadOnly)
            {
                txt_id.Text = GenerateId();
            }
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            var isValid = IsValidId(txt_id.Text);
            if (isValid)
            {
                pic_id_status.Image = Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            }
            else
            {
                pic_id_status.Image = Resources.StatusAnnotations_Warning_16xLG_color;
            }
            btn_ok.Enabled = isValid;
        }

        private string GenerateId()
        {
            var id = txt_name.Text.ToLower().Replace(" ", "-");
            var n = 0;
            var suffix = "";

            while (_mapFiles.Any(m => m.id.ToLower() == id.ToLower() + suffix))
            {
                n++;
                suffix = "-" + n;
            }

            return id + suffix;
        }

        private bool IsValidId(string id)
        {
            if (id.Length == 0)
            {
                return false;
            }
            if (!Regex.IsMatch(id, "^[a-z0-9-_]+$"))
            {
                return false;
            }
            return !_mapFiles.Any(m => m.id.ToLower() == id.ToLower());
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            var tilesetFile = _tilesetFiles[combo_tileset.SelectedIndex];
            var tileset = TilesetData.Load(tilesetFile.path);
            var map = MapService.CreateNew(txt_id.Text, tileset, txt_name.Text);
            CreatedMapData = map;
        }
    }
}
