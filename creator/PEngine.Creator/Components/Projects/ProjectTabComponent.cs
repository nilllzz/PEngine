﻿using PEngine.Creator.Forms;
using PEngine.Creator.Views.Projects;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Projects
{
    internal partial class ProjectTabComponent : UserControl
    {
        protected const int ICON_DOCUMENT = 0;
        protected const int ICON_MAP = 1;
        protected const int ICON_IMAGE = 2;
        protected const int ICON_TILESET = 3;

        private bool _hasChanges;
        private string _title;

        // if this file gets saved, the project also has to be saved
        internal bool HasProjectChanges { get; set; }

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

        internal virtual string FilePath => null;
        internal virtual int IconIndex => ICON_DOCUMENT;
        internal virtual string Identifier => null;
        internal virtual bool CanSave => true;
        internal virtual bool CanSaveAs => true;
        internal virtual ProjectItem ProjectItem => throw new NotImplementedException();

        internal event Action<string> TitleChanged;

        internal ProjectTabComponent()
        {
            InitializeComponent();
        }

        internal virtual void Save()
        {
            if (HasProjectChanges)
            {
                if (MainForm.Instance.ActiveView is MainProjectView projView)
                {
                    projView.SaveProjectFiles();
                }
            }
        }

        internal virtual void Discard() { }

        internal virtual bool Close()
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
