using System;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    public partial class ProjectTabComponent : UserControl
    {
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

        public string Identifier { get; protected set; }

        public event Action<string> TitleChanged;

        public ProjectTabComponent()
        {
            InitializeComponent();
        }
    }
}
