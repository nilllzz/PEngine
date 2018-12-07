using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectTabComponent : UserControl
    {
        protected const int ICON_DOCUMENT = 0;
        protected const int ICON_MAP = 1;
        protected const int ICON_IMAGE = 2;

        private bool _hasChanges;
        private string _title;

        public bool HasChanges
        {
            get => _hasChanges;
            set
            {
                _hasChanges = value;
                TitleChanged?.Invoke(Title);
            }
        }

        public string Title
        {
            get
            {
                var title = _title;
                if (_hasChanges)
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

        public virtual string FilePath => throw new NotImplementedException();
        public virtual int IconIndex => ICON_DOCUMENT;
        public virtual string Identifier => null;
        public virtual bool CanSave => true;
        public virtual bool CanSaveAs => true;

        public event Action<string> TitleChanged;

        public ProjectTabComponent()
        {
            InitializeComponent();
        }

        public virtual void Save()
        {
            // implement in overriding component
            throw new NotImplementedException();
        }
    }
}
