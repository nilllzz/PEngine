using PEngine.Common;
using PEngine.Common.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class GotoForm : Form
    {
        private ProjectFileData[] _results;

        public ProjectFileData SelectedFile { get; private set; }

        public GotoForm()
        {
            InitializeComponent();
        }

        private int GetImageIndexForFile(ProjectFileData file)
        {
            switch (file.GetFileType())
            {
                case ProjectFileType.Map:
                    return 3;
                case ProjectFileType.Tileset:
                    return 2;
                case ProjectFileType.TextureCharacter:
                case ProjectFileType.TextureTileset:
                    return 1;
            }
            return 0;
        }

        private void txt_input_TextChanged(object sender, EventArgs e)
        {
            if (Controls.Contains(lbl_results_title))
            {
                Controls.Remove(lbl_results_title);
            }
            list_results.Items.Clear();

            var term = txt_input.Text.ToLower();
            var files = Project.ActiveProject.GetFiles();
            _results = files.Where(f => f.id.ToLower().Contains(term)).ToArray();
            foreach (var result in _results)
            {
                var item = new ListViewItem()
                {
                    Text = result.id,
                    ImageIndex = GetImageIndexForFile(result),
                };
                item.SubItems.Add(new ListViewItem.ListViewSubItem
                {
                    Text = result.type,
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem
                {
                    Text = result.path,
                });
                list_results.Items.Add(item);
            }
            if (_results.Length > 0 && list_results.SelectedIndices.Count == 0)
            {
                list_results.SelectedIndices.Add(0);
            }
        }

        private void txt_input_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cancel();
                    break;
                case Keys.Down:
                    if (list_results.Items.Count > 0)
                    {
                        list_results.Focus();
                        list_results.SelectedIndices.Clear();
                        list_results.SelectedIndices.Add(0);
                    }
                    break;
                case Keys.Enter:
                    if (list_results.SelectedIndices.Count == 1)
                    {
                        SelectedFile = _results[list_results.SelectedIndices[0]];
                        Confirm();
                    }
                    break;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void list_results_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (list_results.Items.Count == 0 ||
                        (list_results.SelectedIndices.Count == 1 &&
                        list_results.SelectedIndices.Contains(0)))
                    {
                        txt_input.Focus();
                    }
                    break;
                case Keys.Enter:
                    if (list_results.SelectedIndices.Count == 1)
                    {
                        SelectedFile = _results[list_results.SelectedIndices[0]];
                        Confirm();
                    }
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
            }
        }

        private void Confirm()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
