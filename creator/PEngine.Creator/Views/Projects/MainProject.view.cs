using PEngine.Common;
using PEngine.Creator.Components.Game;
using System;
using System.Drawing;

namespace PEngine.Creator.Views.Projects
{
    public partial class MainProjectView : BaseView
    {
        public MainProjectView()
        {
            InitializeComponent();

            Title = Project.ActiveProject.Name;
        }

        private void tool_project_start_Click(object sender, EventArgs e)
        {
            var process = new GameProcess();
            process.ProcessStopped += Process_ProcessStopped;
            process.OutputReceived += Process_Output;

            process.Start();

            Title = Project.ActiveProject.Name + " (Running)";
            Status = "Running";
            StatusColor = Color.FromArgb(202, 81, 0);
        }

        private void Process_Output(string log)
        {
            Console.WriteLine(log);
        }

        private void Process_ProcessStopped()
        {
            Dispatch(() =>
            {
                Title = Project.ActiveProject.Name;
                Status = "Ready";
                SetDefaultStatusColor();
            });
        }
    }
}
