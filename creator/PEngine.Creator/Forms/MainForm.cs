﻿using PEngine.Common;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Views;
using PEngine.Creator.Views.Projects;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    internal partial class MainForm : Form
    {
        internal static MainForm Instance { get; private set; }

        internal BaseView ActiveView
        {
            get
            {
                if (panel_main.Controls.Count == 1 && panel_main.Controls[0] is BaseView)
                {
                    return (BaseView)panel_main.Controls[0];
                }
                return null;
            }
        }

        internal ProjectTabComponent ActiveComponent
        {
            get
            {
                if (ActiveView is MainProjectView projView)
                {
                    return projView.ActiveComponent;
                }
                return null;
            }
        }

        internal ProjectTabComponent[] Components
        {
            get
            {
                if (ActiveView is MainProjectView projView)
                {
                    return projView.Components;
                }
                return new ProjectTabComponent[0];
            }
        }

        internal MainForm()
        {
            InitializeComponent();

            Instance = this;

            // load main view
            var view = new WelcomeView();
            SetView(view);
        }

        #region events

        private void OnStatusChanged(string status)
        {
            status_label_status.Text = status;
        }

        private void OnTitleChanged(string title)
        {
            var newTitle = "PEngine Creator";
            if (title != null && title.Length > 0 && title.Trim().Length > 0)
            {
                newTitle = title.Trim() + " - " + newTitle;
            }
            Text = newTitle;
        }

        private void OnStatusColorChanged(Color color)
        {
            status_main.BackColor = color;
        }

        #endregion

        #region ui

        private void menu_file_openproject_Click(object sender, EventArgs e)
        {
            var project = ProjectService.SelectProject(this);
            if (project != null)
            {
                ProjectService.LoadProject(project);
            }
        }

        private void menu_project_DropDownOpening(object sender, EventArgs e)
        {
            UpdateProjectMenu();
        }

        private void menu_file_DropDownOpening(object sender, EventArgs e)
        {
            UpdateFileMenu();
        }

        private void menu_project_start_Click(object sender, EventArgs e)
        {
            if (ActiveView is MainProjectView projView)
            {
                projView.RunGame();
            }
        }

        private void menu_file_save_Click(object sender, EventArgs e)
        {
            if (ActiveView is MainProjectView projView)
            {
                projView.SaveActiveFile();
            }
        }

        private void menu_main_edit_goto_Click(object sender, EventArgs e)
        {
            if (ActiveView is MainProjectView projView)
            {
                projView.GotoFile();
            }
        }

        internal void UpdateMenus()
        {
            UpdateFileMenu();
            UpdateProjectMenu();
        }

        private void UpdateFileMenu()
        {
            if (ActiveView is MainProjectView projView)
            {
                menu_file_saveall.Enabled = true;
                menu_file_new_map.Enabled = true;
                menu_file_new_tileset.Enabled = true;
                menu_file_closeproject.Enabled = true;

                var comp = projView.ActiveComponent;
                if (comp != null)
                {
                    menu_file_save.Enabled = comp.CanSave;
                    menu_file_saveas.Enabled = comp.CanSaveAs;
                    menu_file_close.Enabled = true;
                    menu_file_closeall.Enabled = true;

                    menu_file_save.Text = $"Save {Path.GetFileName(comp.File.FilePath)}";
                    menu_file_saveas.Text = $"Save {Path.GetFileName(comp.File.FilePath)} As...";
                }
            }
            else
            {
                menu_file_save.Enabled = false;
                menu_file_saveas.Enabled = false;
                menu_file_saveall.Enabled = false;
                menu_file_new_map.Enabled = false;
                menu_file_new_tileset.Enabled = false;
                menu_file_close.Enabled = false;
                menu_file_closeall.Enabled = false;
                menu_file_closeproject.Enabled = false;

                menu_file_save.Text = "Save";
                menu_file_saveas.Text = "Save As...";
            }
        }

        private void UpdateEditMenu()
        {
            if (ActiveView is MainProjectView projView)
            {
                menu_main_edit_goto.Enabled = true;
            }
            else
            {
                menu_main_edit_goto.Enabled = false;
            }
        }

        private void UpdateProjectMenu()
        {
            if (ActiveView is MainProjectView projView)
            {
                menu_project_start.Enabled = true;
                menu_project_properties.Enabled = true;

                menu_project_properties.Text = $"{Project.ActiveProject.Name} Properties...";
            }
            else
            {
                menu_project_start.Enabled = false;
                menu_project_properties.Enabled = false;

                menu_project_properties.Text = "Properties...";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = ActiveView?.FormClosing();
            if (result.HasValue && !result.Value)
            {
                e.Cancel = true;
            }
        }

        private void menu_file_closeproject_Click(object sender, EventArgs e)
        {
            ProjectService.CloseProject();
            var view = new WelcomeView();
            SetView(view);
        }

        #endregion

        internal void LoadedProject()
        {
            var view = new MainProjectView();
            SetView(view);
        }

        internal void SetView(BaseView view, bool destroyCurrent = true)
        {
            if (ActiveView != null && destroyCurrent)
            {
                ActiveView.StatusChanged -= OnStatusChanged;
                ActiveView.TitleChanged -= OnTitleChanged;
                view.StatusColorChanged -= OnStatusColorChanged;
                ActiveView.Dispose();
            }
            panel_main.Controls.Clear();
            panel_main.Controls.Add(view);
            view.StatusChanged += OnStatusChanged;
            view.TitleChanged += OnTitleChanged;
            view.StatusColorChanged += OnStatusColorChanged;
            OnStatusChanged(view.Status);
            OnTitleChanged(view.Title);
            OnStatusColorChanged(view.StatusColor);
            UpdateMenus();
        }
    }
}
