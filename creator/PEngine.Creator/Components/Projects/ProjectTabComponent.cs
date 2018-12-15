using PEngine.Common.Data;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal partial class ProjectTabComponent : UserControl
    {
        protected readonly ProjectEventBus _eventBus;
        private bool _hasChanges;

        internal bool HasChanges
        {
            get => _hasChanges;
            set
            {
                _hasChanges = value;
                TitleChanged?.Invoke(Title);
            }
        }

        internal string Title
        {
            get
            {
                var title = File.name;
                if (_hasChanges)
                {
                    title += "*";
                }
                return title;
            }
        }

        internal ProjectFileData File { get; }
        internal string IconKey => FileIconProvider.GetIconKey(File.FileType);
        internal virtual bool CanSave => true;
        internal virtual bool CanSaveAs => true;

        internal event Action<string> TitleChanged;

        // ctor so the designer doesn't freak out
        public ProjectTabComponent() { }

        internal ProjectTabComponent(ProjectEventBus eventBus, ProjectFileData file)
        {
            InitializeComponent();

            _eventBus = eventBus;
            RegisterEvents();

            File = file;
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.FileUpdated += _eventBus_FileUpdated;
        }

        private void _eventBus_FileUpdated(ProjectFileData file)
        {
            if (file.id == File.id)
            {
                TitleChanged?.Invoke(Title);
            }
        }

        #endregion

        internal virtual void Save() { }

        internal virtual void Discard() { }

        internal virtual bool Close()
        {
            if (CanSave && HasChanges)
            {
                var result = MessageBox.Show($"There are unsaved changes for \n\n\"{File.name}\"\n\nDo you want save the file before closing?",
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
