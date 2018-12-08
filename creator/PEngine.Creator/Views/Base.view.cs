using PEngine.Creator.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Views
{
    internal partial class BaseView : UserControl
    {
        private string _status = "Ready";
        private string _title = null;
        private Color _statusColor = Settings.Default.Color_Highlight;

        internal string Status
        {
            get => _status;
            set
            {
                _status = value;
                StatusChanged?.Invoke(_status);
            }
        }
        internal string Title
        {
            get => _title;
            set
            {
                _title = value;
                TitleChanged?.Invoke(_title);
            }
        }
        internal Color StatusColor
        {
            get => _statusColor;
            set
            {
                _statusColor = value;
                StatusColorChanged?.Invoke(_statusColor);
            }
        }

        internal event Action<string> StatusChanged;
        internal event Action<string> TitleChanged;
        internal event Action<Color> StatusColorChanged;

        protected void Dispatch(Action action)
        {
            Invoke(action);
        }

        protected void SetDefaultStatusColor()
        {
            StatusColor = Settings.Default.Color_Highlight;
        }

        internal BaseView()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        internal virtual bool FormClosing()
        {
            return true;
        }
    }
}
