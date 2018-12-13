using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using PEngine.Creator.Helpers;
using PEngine.Creator.Views.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Projects
{
    internal partial class MainProjectView : BaseView, IEventBusComponent
    {
        private ProjectEventBus _eventBus;

        internal ProjectTabComponent ActiveComponent
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

        internal ProjectTabComponent[] Components
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

        internal MainProjectView()
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
            _eventBus.FileOpenRequested += _eventBus_FileOpenRequested;
            _eventBus.FileDeleted += _eventBus_FileDeleted;
        }

        public void UnregisterEvents()
        {
            _eventBus.FileOpenRequested -= _eventBus_FileOpenRequested;
            _eventBus.FileDeleted -= _eventBus_FileDeleted;
        }

        private void _eventBus_FileDeleted(ProjectFileData file)
        {
            CloseFile(file, true);
        }

        private void _eventBus_FileOpenRequested(ProjectFileData file)
        {
            foreach (var tab in tabs_main.TabPages)
            {
                if (tab is TabPage tabPage &&
                    tabPage.Controls.Count == 1 &&
                    tabPage.Controls[0] is ProjectTabComponent projComp &&
                    projComp.File.Identifier == file.Identifier)
                {
                    // select an already existing tab instead of creating a new one
                    tabs_main.SelectTab(tabPage);
                    return;
                }
            }

            switch (file.FileType)
            {
                case ProjectFileType.Map:
                    {
                        var map = MapData.Load(file.path);
                        var editor = new MapEditor(_eventBus, file, map);
                        OpenTab(editor);
                    }
                    break;
                case ProjectFileType.Tileset:
                    {
                        var tileset = TilesetData.Load(file.path);
                        var editor = new TilesetEditor(_eventBus, file, tileset);
                        OpenTab(editor);
                    }
                    break;
                case ProjectFileType.TextureCharacter:
                case ProjectFileType.TextureTileset:
                    {
                        var viewer = new TextureViewer(_eventBus, file);
                        OpenTab(viewer);
                    }
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
            SaveActiveFile();
        }

        private void tool_saveall_Click(object sender, EventArgs e)
        {
            SaveAllFiles();
        }

        private void tabs_main_MouseClick(object sender, MouseEventArgs e)
        {
            // select the tab that was clicked
            if (e.Button != MouseButtons.Left)
            {
                for (var i = 0; i < tabs_main.TabCount; i++)
                {
                    var r = tabs_main.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        tabs_main.SelectTab(i);
                        break;
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                context_tabs.Show(tabs_main, e.Location);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                CloseActiveFile();
            }
        }

        private void context_tabs_save_Click(object sender, EventArgs e)
        {
            SaveActiveFile();
        }

        private void context_tabs_close_Click(object sender, EventArgs e)
        {
            CloseActiveFile();
        }

        private void context_tabs_closeall_Click(object sender, EventArgs e)
        {
            CloseAllFiles();
        }

        private void context_tabs_closeallbutthis_Click(object sender, EventArgs e)
        {
            CloseAllFiles(ActiveComponent?.File.Identifier);
        }

        private void context_tabs_copypath_Click(object sender, EventArgs e)
        {
            if (ActiveComponent != null)
            {
                var path = ActiveComponent.File.FilePath;
                if (path != null && path.Length > 0)
                {
                    Clipboard.SetText(Path.GetFullPath(path));
                }
            }
        }

        private void context_tabs_reveal_Click(object sender, EventArgs e)
        {
            if (ActiveComponent != null && ActiveComponent.File.FilePath != null)
            {
                ExplorerHelper.OpenWithFileSelected(ActiveComponent.File.FilePath);
            }
        }

        private void context_tabs_Opening(object sender, CancelEventArgs e)
        {
            if (ActiveComponent != null)
            {
                if (ActiveComponent.CanSave)
                {
                    var filename = Path.GetFileName(ActiveComponent.File.FilePath);
                    context_tabs_save.Text = $"Save {filename}";
                    context_tabs_copypath.Enabled = true;
                    context_tabs_reveal.Enabled = true;
                }
                else
                {
                    context_tabs_save.Text = "Save";
                    context_tabs_copypath.Enabled = false;
                    context_tabs_reveal.Enabled = false;
                }
                context_tabs_save.Enabled = ActiveComponent.CanSave;
            }
            else
            {
                context_tabs_save.Text = "Save";
                context_tabs_save.Enabled = false;
                context_tabs_copypath.Enabled = false;
                context_tabs_reveal.Enabled = false;
            }
        }

        private void tool_project_list_DropDownOpening(object sender, EventArgs e)
        {
            tool_project_list.DropDownItems.Clear();
            foreach (var tab in tabs_main.TabPages)
            {
                if (tab is TabPage tabPage &&
                    tabPage.Controls.Count == 1 &&
                    tabPage.Controls[0] is ProjectTabComponent projComp)
                {
                    var image = imagelist_tabs.Images[projComp.IconIndex];
                    var text = tabPage.Text;

                    var listItem = new ToolStripMenuItem(text, image);
                    listItem.Click += (object lSender, EventArgs le) =>
                    {
                        OpenTab(projComp);
                    };
                    tool_project_list.DropDownItems.Add(listItem);
                }
            }
        }

        #endregion

        internal void OpenTab(ProjectTabComponent component)
        {
            // check if the component is already opened in a tab
            foreach (var tab in tabs_main.TabPages)
            {
                if (tab is TabPage tabPage &&
                    tabPage.Controls.Count == 1 &&
                    tabPage.Controls[0] is ProjectTabComponent projComp &&
                    projComp.File.Identifier == component.File.Identifier)
                {
                    tabs_main.SelectTab(tabPage);
                    return;
                }
            }

            var newTab = new TabPage
            {
                Text = component.Title,
                ImageIndex = component.IconIndex
            };

            component.Dock = DockStyle.Fill;
            component.TitleChanged += (string title) =>
            {
                newTab.Text = title;
            };
            newTab.Controls.Add(component);
            newTab.ToolTipText = Path.GetFullPath(component.File.FilePath);

            tabs_main.TabPages.Insert(0, newTab);
            tabs_main.SelectTab(newTab);

            TabsChanged();
        }

        private void TabsChanged()
        {
            var comp = ActiveComponent;

            tool_save.Enabled = comp != null && comp.CanSave;
            tool_saveall.Enabled = comp != null;

            tabs_main.ShowToolTips = true;

            MainForm.Instance.UpdateMenus();
        }

        internal void SaveActiveFile()
        {
            ActiveComponent?.Save();
        }

        internal void SaveAllFiles()
        {
            Project.ActiveProject.Save();
            foreach (var comp in Components)
            {
                comp.Save();
            }
        }

        internal void CloseActiveFile()
        {
            if (ActiveComponent != null)
            {
                CloseFile(ActiveComponent.File, false);
            }
        }

        internal void CloseFile(ProjectFileData file, bool force)
        {
            foreach (var tab in tabs_main.TabPages)
            {
                if (tab is TabPage tabPage &&
                    tabPage.Controls.Count == 1 &&
                    tabPage.Controls[0] is ProjectTabComponent comp &&
                    comp.File.id == file.id &&
                    comp.File.FileType == file.FileType)
                {
                    var result = true;
                    if (!force)
                    {
                        result = comp.Close();
                    }
                    if (result)
                    {
                        if (comp is IEventBusComponent eventBusComp)
                        {
                            eventBusComp.UnregisterEvents();
                        }
                        tabs_main.TabPages.Remove(tabs_main.SelectedTab);
                    }
                }
            }
        }

        internal void CloseAllFiles(string except = null)
        {
            foreach (var tab in tabs_main.TabPages)
            {
                if (tab is TabPage tabPage &&
                    tabPage.Controls.Count == 1 &&
                    tabPage.Controls[0] is ProjectTabComponent projComp)
                {
                    if (except == null || except != projComp.File.Identifier)
                    {
                        var result = projComp.Close();
                        if (result)
                        {
                            if (projComp is IEventBusComponent eventBusComp)
                            {
                                eventBusComp.UnregisterEvents();
                            }
                            tabs_main.TabPages.Remove(tabPage);
                        }
                    }
                }
            }
        }

        internal void RunGame()
        {
            SaveAllFiles();

            var view = new DebugView();
            view.SetPreviousView(this);

            MainForm.Instance.SetView(view, false);
            view.StartDebug();
        }

        internal void GotoFile()
        {
            var form = new GotoForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _eventBus.RequestFileOpen(form.SelectedFile);
            }
        }
    }
}
