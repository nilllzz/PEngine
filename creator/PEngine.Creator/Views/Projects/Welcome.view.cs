using PEngine.Creator.Forms;

namespace PEngine.Creator.Views.Projects
{
    internal partial class WelcomeView : BaseView
    {
        internal WelcomeView()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, System.EventArgs e)
        {
            var view = new NewProjectView();
            MainForm.Instance.SetView(view);
        }
    }
}
