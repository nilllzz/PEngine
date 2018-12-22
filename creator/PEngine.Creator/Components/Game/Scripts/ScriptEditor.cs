using PEngine.Common.Data;
using PEngine.Creator.Components.Projects;

namespace PEngine.Creator.Components.Game.Scripts
{
    internal partial class ScriptEditor : ProjectTabComponent, IEventBusComponent
    {
        private string _originalText;

        internal ScriptEditor(ProjectEventBus eventBus, ProjectFileData file)
            : base(eventBus, file)
        {
            InitializeComponent();

            RegisterEvents();

            _originalText = ScriptsService.ReadScript(file);
            txt_main.Text = _originalText;
        }

        #region events

        private void RegisterEvents()
        {

        }

        public void UnregisterEvents()
        {

        }

        #endregion

        #region ui

        private void txt_main_TextChanged(object sender, System.EventArgs e)
        {
            HasChanges = _originalText != txt_main.Text;
        }

        #endregion

        internal override void Save()
        {
            ScriptsService.SaveScript(File, txt_main.Text);
            _originalText = txt_main.Text;
            HasChanges = false;
        }
    }
}
