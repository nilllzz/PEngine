using PEngine.Common;
using PEngine.Creator.Components.Projects;

namespace PEngine.Creator.Views.Projects
{
    public partial class NewProjectView : BaseView
    {
        public NewProjectView()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, System.EventArgs e)
        {
            var name = txt_name.Text;
            var author = txt_author.Text;

            var path = ProjectService.GetNewProjectPath(name);
            var project = new Project(path);
            project.Create(name, author);

            project.Save();
        }
    }
}
