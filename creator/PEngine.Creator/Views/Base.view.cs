using System.Windows.Forms;

namespace PEngine.Creator.Views
{
    public partial class BaseView : UserControl
    {
        public BaseView()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }
    }
}
