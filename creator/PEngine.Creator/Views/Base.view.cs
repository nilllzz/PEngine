using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Views
{
    public partial class BaseView : UserControl
    {
        private string _status = "Ready";
        private string _title = null;
        private Color _statusColor = Settings.Default.Color_Highlight;

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
        public Color StatusColor
        {
            get => _statusColor;
            set
            {
                _statusColor = value;
                StatusColorChanged?.Invoke(_statusColor);
            }
        }

        public event Action<string> StatusChanged;
        public event Action<string> TitleChanged;
        public event Action<Color> StatusColorChanged;

        protected void Dispatch(Action action)
        {
            Invoke(action);
        }

        protected void SetDefaultStatusColor()
        {
            StatusColor = Settings.Default.Color_Highlight;
        }

        public BaseView()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        public virtual bool FormClosing()
        {
            return true;
        }
    }
}
