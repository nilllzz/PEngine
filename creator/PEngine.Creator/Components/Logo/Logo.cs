using System.ComponentModel;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Logo
{
    public partial class Logo : PictureBox
    {
        public Logo()
        {
            InitializeComponent();
        }

        public Logo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
