namespace PEngine.Creator.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_main = new System.Windows.Forms.Panel();
            this.status_main = new System.Windows.Forms.StatusStrip();
            this.status_label_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_new_project = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_new_map = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_new_tileset = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_openproject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_saveas = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_saveall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_close = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_closeall = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_closeproject = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_project = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_project_start = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_project_properties = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_main_edit_goto = new System.Windows.Forms.ToolStripMenuItem();
            this.status_main.SuspendLayout();
            this.menu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 24);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(968, 537);
            this.panel_main.TabIndex = 3;
            // 
            // status_main
            // 
            this.status_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_Highlight;
            this.status_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label_status});
            this.status_main.Location = new System.Drawing.Point(0, 561);
            this.status_main.Name = "status_main";
            this.status_main.Size = new System.Drawing.Size(968, 22);
            this.status_main.TabIndex = 1;
            this.status_main.Text = "statusStrip1";
            // 
            // status_label_status
            // 
            this.status_label_status.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.status_label_status.ForeColor = global::PEngine.Creator.Properties.Settings.Default.Color_HighlightText;
            this.status_label_status.Name = "status_label_status";
            this.status_label_status.Size = new System.Drawing.Size(54, 17);
            this.status_label_status.Text = "<status>";
            // 
            // menu_main
            // 
            this.menu_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file,
            this.menu_main_edit,
            this.menu_project});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(968, 24);
            this.menu_main.TabIndex = 2;
            this.menu_main.Text = "menuStrip1";
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file_new,
            this.menu_file_openproject,
            this.toolStripSeparator1,
            this.menu_file_save,
            this.menu_file_saveas,
            this.menu_file_saveall,
            this.toolStripSeparator4,
            this.menu_file_close,
            this.menu_file_closeall,
            this.menu_file_closeproject});
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(37, 20);
            this.menu_file.Text = "File";
            this.menu_file.DropDownOpening += new System.EventHandler(this.menu_file_DropDownOpening);
            // 
            // menu_file_new
            // 
            this.menu_file_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file_new_project,
            this.toolStripSeparator2,
            this.menu_file_new_map,
            this.menu_file_new_tileset});
            this.menu_file_new.Name = "menu_file_new";
            this.menu_file_new.Size = new System.Drawing.Size(187, 22);
            this.menu_file_new.Text = "New";
            // 
            // menu_file_new_project
            // 
            this.menu_file_new_project.Image = global::PEngine.Creator.Properties.Resources.NewSolutionFolder_6289;
            this.menu_file_new_project.Name = "menu_file_new_project";
            this.menu_file_new_project.Size = new System.Drawing.Size(120, 22);
            this.menu_file_new_project.Text = "Project...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(117, 6);
            // 
            // menu_file_new_map
            // 
            this.menu_file_new_map.Name = "menu_file_new_map";
            this.menu_file_new_map.Size = new System.Drawing.Size(120, 22);
            this.menu_file_new_map.Text = "Map";
            // 
            // menu_file_new_tileset
            // 
            this.menu_file_new_tileset.Name = "menu_file_new_tileset";
            this.menu_file_new_tileset.Size = new System.Drawing.Size(120, 22);
            this.menu_file_new_tileset.Text = "Tileset";
            // 
            // menu_file_openproject
            // 
            this.menu_file_openproject.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.menu_file_openproject.Name = "menu_file_openproject";
            this.menu_file_openproject.Size = new System.Drawing.Size(187, 22);
            this.menu_file_openproject.Text = "Open Project...";
            this.menu_file_openproject.Click += new System.EventHandler(this.menu_file_openproject_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // menu_file_save
            // 
            this.menu_file_save.Image = global::PEngine.Creator.Properties.Resources.save_16xLG;
            this.menu_file_save.Name = "menu_file_save";
            this.menu_file_save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menu_file_save.Size = new System.Drawing.Size(187, 22);
            this.menu_file_save.Text = "Save";
            this.menu_file_save.Click += new System.EventHandler(this.menu_file_save_Click);
            // 
            // menu_file_saveas
            // 
            this.menu_file_saveas.Name = "menu_file_saveas";
            this.menu_file_saveas.Size = new System.Drawing.Size(187, 22);
            this.menu_file_saveas.Text = "Save As...";
            // 
            // menu_file_saveall
            // 
            this.menu_file_saveall.Image = global::PEngine.Creator.Properties.Resources.Saveall_6518;
            this.menu_file_saveall.Name = "menu_file_saveall";
            this.menu_file_saveall.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.menu_file_saveall.Size = new System.Drawing.Size(187, 22);
            this.menu_file_saveall.Text = "Save All";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(184, 6);
            // 
            // menu_file_close
            // 
            this.menu_file_close.Name = "menu_file_close";
            this.menu_file_close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menu_file_close.Size = new System.Drawing.Size(187, 22);
            this.menu_file_close.Text = "Close";
            // 
            // menu_file_closeall
            // 
            this.menu_file_closeall.Name = "menu_file_closeall";
            this.menu_file_closeall.Size = new System.Drawing.Size(187, 22);
            this.menu_file_closeall.Text = "Close All";
            // 
            // menu_file_closeproject
            // 
            this.menu_file_closeproject.Name = "menu_file_closeproject";
            this.menu_file_closeproject.Size = new System.Drawing.Size(187, 22);
            this.menu_file_closeproject.Text = "Close Project";
            this.menu_file_closeproject.Click += new System.EventHandler(this.menu_file_closeproject_Click);
            // 
            // menu_project
            // 
            this.menu_project.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_project_start,
            this.toolStripSeparator3,
            this.menu_project_properties});
            this.menu_project.Name = "menu_project";
            this.menu_project.Size = new System.Drawing.Size(56, 20);
            this.menu_project.Text = "Project";
            this.menu_project.DropDownOpening += new System.EventHandler(this.menu_project_DropDownOpening);
            // 
            // menu_project_start
            // 
            this.menu_project_start.Image = global::PEngine.Creator.Properties.Resources.arrow_run_16xLG;
            this.menu_project_start.Name = "menu_project_start";
            this.menu_project_start.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menu_project_start.Size = new System.Drawing.Size(136, 22);
            this.menu_project_start.Text = "Start";
            this.menu_project_start.Click += new System.EventHandler(this.menu_project_start_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // menu_project_properties
            // 
            this.menu_project_properties.Image = global::PEngine.Creator.Properties.Resources.properties_16xLG;
            this.menu_project_properties.Name = "menu_project_properties";
            this.menu_project_properties.Size = new System.Drawing.Size(136, 22);
            this.menu_project_properties.Text = "Properties...";
            // 
            // menu_main_edit
            // 
            this.menu_main_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_main_edit_goto});
            this.menu_main_edit.Name = "menu_main_edit";
            this.menu_main_edit.Size = new System.Drawing.Size(39, 20);
            this.menu_main_edit.Text = "Edit";
            // 
            // menu_main_edit_goto
            // 
            this.menu_main_edit_goto.Name = "menu_main_edit_goto";
            this.menu_main_edit_goto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menu_main_edit_goto.Size = new System.Drawing.Size(180, 22);
            this.menu_main_edit_goto.Text = "Go To...";
            this.menu_main_edit_goto.Click += new System.EventHandler(this.menu_main_edit_goto_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(968, 583);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.status_main);
            this.Controls.Add(this.menu_main);
            this.MainMenuStrip = this.menu_main;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.status_main.ResumeLayout(false);
            this.status_main.PerformLayout();
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip status_main;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.ToolStripStatusLabel status_label_status;
        private System.Windows.Forms.ToolStripMenuItem menu_file;
        private System.Windows.Forms.ToolStripMenuItem menu_file_openproject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_file_save;
        private System.Windows.Forms.ToolStripMenuItem menu_file_saveall;
        private System.Windows.Forms.ToolStripMenuItem menu_file_saveas;
        private System.Windows.Forms.ToolStripMenuItem menu_file_new;
        private System.Windows.Forms.ToolStripMenuItem menu_file_new_project;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menu_file_new_map;
        private System.Windows.Forms.ToolStripMenuItem menu_file_new_tileset;
        private System.Windows.Forms.ToolStripMenuItem menu_project;
        private System.Windows.Forms.ToolStripMenuItem menu_project_start;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menu_project_properties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menu_file_close;
        private System.Windows.Forms.ToolStripMenuItem menu_file_closeall;
        private System.Windows.Forms.ToolStripMenuItem menu_file_closeproject;
        private System.Windows.Forms.ToolStripMenuItem menu_main_edit;
        private System.Windows.Forms.ToolStripMenuItem menu_main_edit_goto;
    }
}