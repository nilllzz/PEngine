using PEngine.Creator.Forms;
using PEngine.Creator.Views.Projects;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    public partial class ProjectTabComponent : UserControl
    {
        protected const int ICON_DOCUMENT = 0;
        protected const int ICON_MAP = 1;
        protected const int ICON_IMAGE = 2;
        protected const int ICON_TILESET = 3;

        private bool _hasChanges;
        private string _title;

        // if this file gets saved, the project also has to be saved
        public bool HasProjectChanges { get; set; }

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

        public virtual string FilePath => null;
        public virtual int IconIndex => ICON_DOCUMENT;
        public virtual string Identifier => null;
        public virtual bool CanSave => true;
        public virtual bool CanSaveAs => true;
        public virtual ProjectItem ProjectItem => throw new NotImplementedException();

        public event Action<string> TitleChanged;

        public ProjectTabComponent()
        {
            InitializeComponent();
        }

        public virtual void Save()
        {
            if (HasProjectChanges)
            {
                if (MainForm.Instance.ActiveView is MainProjectView projView)
                {
                    projView.SaveProjectFiles();
                }
            }
        }

        public virtual void Discard() { }

        public virtual bool Close()
        {
            if (CanSave && HasChanges)
            {
                var result = MessageBox.Show($"There are unsaved changes for \n\n\"{FilePath}\"\n\nDo you want save the file before closing?",
                    "PEngine", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch (result)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        Save();
                        return true;
                    case DialogResult.No:
                        Discard();
                        return true;
                }
            }

            return true;
        }
    }
}
