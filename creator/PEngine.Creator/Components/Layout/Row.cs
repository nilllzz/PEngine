using System.ComponentModel;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Layout
{
    internal partial class Row : FlowLayoutPanel
    {
        internal Row()
        {
            InitializeComponent();
        }

        internal Row(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
