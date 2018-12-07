using System;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    public partial class ProjectTabComponent : UserControl
    {
        protected const int ICON_DOCUMENT = 0;
        protected const int ICON_MAP = 1;

        private bool _isUnsaved;
        private string _title;

        public bool IsUnsaved
        {
            get => _isUnsaved;
            set
            {
                _isUnsaved = value;
                TitleChanged?.Invoke(Title);
            }
        }

        public string Title
        {
            get
            {
                var title = _title;
                if (_isUnsaved)
                {
                    title += "*";
                }
                return title;
            }
            set
            {
                _title = value;
                TitleChanged?.Invoke(Title);
            }
        }

        public int IconIndex { get; protected set; } = ICON_DOCUMENT;

        public string Identifier { get; protected set; }

        public event Action<string> TitleChanged;

        public ProjectTabComponent()
        {
            InitializeComponent();
        }
    }
}
