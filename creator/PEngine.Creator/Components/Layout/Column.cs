using System.ComponentModel;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Layout
{
    public partial class Column : FlowLayoutPanel
    {
        public Column()
        {
            InitializeComponent();
        }

        public Column(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
