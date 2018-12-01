using System;
using System.Windows.Forms;

namespace PEngine.Creator.Views
{
    public partial class BaseView : UserControl
    {
        private string _status = "Ready";
        private string _title = null;

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                StatusChanged?.Invoke(_status);
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                TitleChanged?.Invoke(_title);
            }
        }

        public event Action<string> StatusChanged;
        public event Action<string> TitleChanged;

        public BaseView()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }
    }
}
