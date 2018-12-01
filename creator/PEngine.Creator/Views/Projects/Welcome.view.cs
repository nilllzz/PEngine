using PEngine.Creator.Forms;

namespace PEngine.Creator.Views.Projects
{
    public partial class WelcomeView : BaseView
    {
        public WelcomeView()
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
