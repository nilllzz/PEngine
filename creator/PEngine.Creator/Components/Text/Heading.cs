using PEngine.Creator.Forms;
using System.ComponentModel;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Text
{
    public partial class Heading : Label
    {
        private int _level;

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                switch (_level)
                {
                    case 1:
                        Font = FormConsts.Font_H1;
                        break;
                    case 2:
                        Font = FormConsts.Font_H2;
                        break;
                    case 3:
                        Font = FormConsts.Font_H3;
                        break;
                    case 4:
                        Font = FormConsts.Font_H4;
                        break;
                    case 5:
                        Font = FormConsts.Font_H5;
                        break;
                    case 6:
                        Font = FormConsts.Font_H6;
                        break;
                }
            }
        }

        public Heading()
        {
            InitializeComponent();
            Initialize();
        }

        public Heading(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Level = 1;
        }
    }
}
