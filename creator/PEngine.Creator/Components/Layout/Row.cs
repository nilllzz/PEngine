using System.ComponentModel;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Layout
{
    public partial class Row : FlowLayoutPanel
    {
        public Row()
        {
            InitializeComponent();
        }

        public Row(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
