using PEngine.Common;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Projects;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    public partial class MainProjectView : BaseView, IEventBusComponent
    {
        private ProjectEventBus _eventBus;

        public MainProjectView()
        {
            InitializeComponent();

            _eventBus = new ProjectEventBus();
            RegisterEvents();
            projectTree.SetEventBus(_eventBus);

            Title = Project.ActiveProject.Name;
        }

        #region events

        private void RegisterEvents()
        {
            _eventBus.ItemOpenRequested += _eventBus_ItemOpenRequested;
        }

        public void UnregisterEvents()
        {
            _eventBus.ItemOpenRequested -= _eventBus_ItemOpenRequested;
        }

        private void _eventBus_ItemOpenRequested(ProjectItem item)
        {
            switch (item.ItemType)
            {
                case ProjectItemType.Map:
                    break;
                case ProjectItemType.Tileset:
                    var id = Path.GetFileNameWithoutExtension(item.FilePath);
                    var tileset = TilesetData.FetchOne(id);
                    var editor = new TilesetEditor(_eventBus, tileset);
                    OpenTab(editor);
                    break;
            }
        }

        #endregion

        #region ui

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

        #endregion

        public void OpenTab(ProjectTabComponent component)
        {
            var tab = new TabPage();
            tab.Text = component.Title;
            component.Dock = DockStyle.Fill;
            tab.Controls.Add(component);
            component.TitleChanged += (string title) =>
            {
                tab.Text = title;
            };
            tabs_main.TabPages.Add(tab);
            tabs_main.SelectTab(tab);
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
