using PEngine.Common;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    public partial class MainProjectView : BaseView, IEventBusComponent
    {
        private ProjectEventBus _eventBus;

        public ProjectTabComponent ActiveComponent
        {
            get
            {
                if (tabs_main.TabPages.Count == 0)
                {
                    return null;
                }
                var selectedTab = tabs_main.SelectedTab;
                if (selectedTab.Controls.Count != 1)
                {
                    return null;
                }
                if (selectedTab.Controls[0] is ProjectTabComponent projComponent)
                {
                    return projComponent;
                }
                return null;
            }
        }

        public ProjectTabComponent[] Components
        {
            get
            {
                var components = new List<ProjectTabComponent>();
                foreach (var tab in tabs_main.TabPages)
                {
                    if (tab is TabPage tabPage &&
                        tabPage.Controls.Count == 1 &&
                        tabPage.Controls[0] is ProjectTabComponent projComponent)
                    {
                        components.Add(projComponent);
                    }
                }
                return components.ToArray();
            }
        }

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
            foreach (var tab in tabs_main.TabPages)
            {
                if (tab is TabPage tabPage &&
                    tabPage.Controls.Count == 1 &&
                    tabPage.Controls[0] is ProjectTabComponent projComp &&
                    projComp.Identifier == item.Identifier)
                {
                    // select an already existing tab instead of creating a new one
                    tabs_main.SelectTab(tabPage);
                    return;
                }
            }

            switch (item.ItemType)
            {
                case ProjectItemType.Map:
                    break;
                case ProjectItemType.Tileset:
                    var id = Path.GetFileNameWithoutExtension(item.FilePath);
                    var tileset = TilesetData.FetchOne(id);
                    var editor = new TilesetEditor(_eventBus, tileset, item);
                    OpenTab(editor);
                    break;
                case ProjectItemType.Texture:
                    var viewer = new TextureViewer(item);
                    OpenTab(viewer);
                    break;
            }
        }

        #endregion

        #region ui

        private void tool_project_start_Click(object sender, EventArgs e)
        {
            RunGame();
        }

        private void tabs_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabsChanged();
        }

        private void tool_save_Click(object sender, EventArgs e)
        {
            MainForm.Instance.SaveActiveFile();
        }

        private void tool_saveall_Click(object sender, EventArgs e)
        {
            MainForm.Instance.SaveAllFiles();
        }

        #endregion

        public void OpenTab(ProjectTabComponent component)
        {
            var tab = new TabPage
            {
                Text = component.Title,
                ImageIndex = component.IconIndex
            };

            component.Dock = DockStyle.Fill;
            component.TitleChanged += (string title) =>
            {
                tab.Text = title;
            };
            tab.Controls.Add(component);

            tabs_main.TabPages.Add(tab);
            tabs_main.SelectTab(tab);

            TabsChanged();
        }

        private void TabsChanged()
        {
            var comp = ActiveComponent;

            tool_save.Enabled = comp != null && comp.CanSave;
            tool_saveall.Enabled = comp != null;

            MainForm.Instance.UpdateMenus();
        }

        public void RunGame()
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
