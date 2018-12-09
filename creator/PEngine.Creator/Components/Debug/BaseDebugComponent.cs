using PEngine.Common.Interop;
using PEngine.Creator.Components.Game;
using System.Windows.Forms;

namespace PEngine.Creator.Components.Debug
{
    internal partial class BaseDebugComponent : UserControl
    {
        protected GameProcess _process;

        internal BaseDebugComponent()
        {
            InitializeComponent();
        }

        internal void SetGameProcess(GameProcess process)
        {
            _process = process;
        }

        internal virtual void HandlePipelineEvent(PipelineMessage message)
        {
            // handle it!
        }

        internal virtual void DebuggingStopped() { }
    }
}
