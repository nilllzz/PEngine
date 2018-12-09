using PEngine.Creator.Components.Game;
using System.ComponentModel;

namespace PEngine.Creator.Components.Logo
{
    public partial class Logo : CrispPictureBox
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
