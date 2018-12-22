using System.Windows.Forms;

namespace PEngine.Creator.Forms.New
{
    public partial class NewScriptForm : Form
    {
        internal string SelectedName { get; private set; }

        public NewScriptForm()
        {
            InitializeComponent();

            txt_name.Text = "New Script";
        }

        private void btn_ok_Click(object sender, System.EventArgs e)
        {
            SelectedName = txt_name.Text;
        }
    }
}
