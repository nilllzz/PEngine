using PEngine.Creator.Components.Game;
using System.ComponentModel;

namespace PEngine.Creator.Components.Logo
{
    internal partial class Logo : CrispPictureBox
    {
        internal Logo()
        {
            InitializeComponent();
        }

        internal Logo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
