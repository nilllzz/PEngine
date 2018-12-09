using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    internal partial class NewProjectView : BaseView
    {
        private BaseView _previousView;

        internal NewProjectView()
        {
            InitializeComponent();
            txt_name.Select();
        }

        internal void SetPreviousView(BaseView view)
        {
            _previousView = view;
        }

        private void btn_confirm_Click(object sender, System.EventArgs e)
        {
            var name = txt_name.Text;
            var author = txt_author.Text;

            if (name.Length == 0)
            {
                MessageBox.Show("You have to enter a project name.", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (author.Length == 0)
            {
                MessageBox.Show("You have to enter an author.", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var project = ProjectService.CreateNew(name, author);
            ProjectService.LoadProject(project);
        }

        private void btn_cancel_Click(object sender, System.EventArgs e)
        {
            MainForm.Instance.SetView(_previousView);
        }
    }
}
