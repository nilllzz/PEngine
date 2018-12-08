using System.ComponentModel;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Layout
{
    internal partial class Column : FlowLayoutPanel
    {
        internal Column()
        {
            InitializeComponent();
        }

        internal Column(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
