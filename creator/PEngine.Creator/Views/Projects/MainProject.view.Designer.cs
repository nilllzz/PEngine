namespace PEngine.Creator.Views.Projects
{
    partial class MainProjectView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProjectView));
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.projectTree = new PEngine.Creator.Components.Projects.ProjectTree();
            this.tabs_main = new System.Windows.Forms.TabControl();
            this.imagelist_tabs = new System.Windows.Forms.ImageList(this.components);
            this.tool_project = new System.Windows.Forms.ToolStrip();
            this.tool_project_new = new System.Windows.Forms.ToolStripDropDownButton();
            this.tool_project_new_map = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_project_new_tileset = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_save = new System.Windows.Forms.ToolStripButton();
            this.tool_saveall = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_project_start = new System.Windows.Forms.ToolStripButton();
            this.tool_project_list = new System.Windows.Forms.ToolStripDropDownButton();
            this.context_tabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_tabs_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.context_tabs_close = new System.Windows.Forms.ToolStripMenuItem();
            this.context_tabs_closeall = new System.Windows.Forms.ToolStripMenuItem();
            this.context_tabs_closeallbutthis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.context_tabs_copypath = new System.Windows.Forms.ToolStripMenuItem();
            this.context_tabs_reveal = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).BeginInit();
            this.split_main.Panel1.SuspendLayout();
            this.split_main.Panel2.SuspendLayout();
            this.split_main.SuspendLayout();
            this.tool_project.SuspendLayout();
            this.context_tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_main
            // 
            this.split_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split_main.Location = new System.Drawing.Point(0, 0);
            this.split_main.Name = "split_main";
            // 
            // split_main.Panel1
            // 
            this.split_main.Panel1.Controls.Add(this.projectTree);
            this.split_main.Panel1MinSize = 100;
            // 
            // split_main.Panel2
            // 
            this.split_main.Panel2.Controls.Add(this.tabs_main);
            this.split_main.Panel2.Controls.Add(this.tool_project);
            this.split_main.Panel2MinSize = 100;
            this.split_main.Size = new System.Drawing.Size(1158, 796);
            this.split_main.SplitterDistance = 240;
            this.split_main.TabIndex = 0;
            // 
            // projectTree
            // 
            this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTree.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.projectTree.Location = new System.Drawing.Point(0, 0);
            this.projectTree.Name = "projectTree";
            this.projectTree.Size = new System.Drawing.Size(240, 796);
            this.projectTree.TabIndex = 0;
            // 
            // tabs_main
            // 
            this.tabs_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_main.ImageList = this.imagelist_tabs;
            this.tabs_main.Location = new System.Drawing.Point(0, 25);
            this.tabs_main.Name = "tabs_main";
            this.tabs_main.SelectedIndex = 0;
            this.tabs_main.Size = new System.Drawing.Size(914, 771);
            this.tabs_main.TabIndex = 1;
            this.tabs_main.SelectedIndexChanged += new System.EventHandler(this.tabs_main_SelectedIndexChanged);
            this.tabs_main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabs_main_MouseClick);
            // 
            // imagelist_tabs
            // 
            this.imagelist_tabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist_tabs.ImageStream")));
            this.imagelist_tabs.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist_tabs.Images.SetKeyName(0, "icon_document");
            this.imagelist_tabs.Images.SetKeyName(1, "icon_map");
            this.imagelist_tabs.Images.SetKeyName(2, "icon_image");
            this.imagelist_tabs.Images.SetKeyName(3, "tileset.png");
            // 
            // tool_project
            // 
            this.tool_project.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_project.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_project.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_project_new,
            this.tool_save,
            this.tool_saveall,
            this.toolStripSeparator1,
            this.tool_project_start,
            this.tool_project_list});
            this.tool_project.Location = new System.Drawing.Point(0, 0);
            this.tool_project.Name = "tool_project";
            this.tool_project.Size = new System.Drawing.Size(914, 25);
            this.tool_project.TabIndex = 0;
            this.tool_project.Text = "toolStrip1";
            // 
            // tool_project_new
            // 
            this.tool_project_new.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_project_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_project_new_map,
            this.tool_project_new_tileset});
            this.tool_project_new.Image = global::PEngine.Creator.Properties.Resources.NewRequest_8796;
            this.tool_project_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_project_new.Name = "tool_project_new";
            this.tool_project_new.Size = new System.Drawing.Size(29, 22);
            this.tool_project_new.Text = "New files";
            // 
            // tool_project_new_map
            // 
            this.tool_project_new_map.Name = "tool_project_new_map";
            this.tool_project_new_map.Size = new System.Drawing.Size(108, 22);
            this.tool_project_new_map.Text = "Map";
            // 
            // tool_project_new_tileset
            // 
            this.tool_project_new_tileset.Name = "tool_project_new_tileset";
            this.tool_project_new_tileset.Size = new System.Drawing.Size(108, 22);
            this.tool_project_new_tileset.Text = "Tileset";
            // 
            // tool_save
            // 
            this.tool_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_save.Enabled = false;
            this.tool_save.Image = global::PEngine.Creator.Properties.Resources.save_16xLG;
            this.tool_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_save.Name = "tool_save";
            this.tool_save.Size = new System.Drawing.Size(23, 22);
            this.tool_save.Text = "Save";
            this.tool_save.ToolTipText = "Save (Ctrl + S)";
            this.tool_save.Click += new System.EventHandler(this.tool_save_Click);
            // 
            // tool_saveall
            // 
            this.tool_saveall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_saveall.Enabled = false;
            this.tool_saveall.Image = global::PEngine.Creator.Properties.Resources.Saveall_6518;
            this.tool_saveall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_saveall.Name = "tool_saveall";
            this.tool_saveall.Size = new System.Drawing.Size(23, 22);
            this.tool_saveall.Text = "Save All";
            this.tool_saveall.ToolTipText = "Save All (Ctrl + Shift + S)";
            this.tool_saveall.Click += new System.EventHandler(this.tool_saveall_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_project_start
            // 
            this.tool_project_start.Image = global::PEngine.Creator.Properties.Resources.arrow_run_16xLG;
            this.tool_project_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_project_start.Name = "tool_project_start";
            this.tool_project_start.Size = new System.Drawing.Size(51, 22);
            this.tool_project_start.Text = "Start";
            this.tool_project_start.ToolTipText = "Play current project (F5)";
            this.tool_project_start.Click += new System.EventHandler(this.tool_project_start_Click);
            // 
            // tool_project_list
            // 
            this.tool_project_list.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tool_project_list.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_project_list.Image = global::PEngine.Creator.Properties.Resources.list_16xLG;
            this.tool_project_list.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_project_list.Name = "tool_project_list";
            this.tool_project_list.Size = new System.Drawing.Size(29, 22);
            this.tool_project_list.Text = "List open files";
            this.tool_project_list.DropDownOpening += new System.EventHandler(this.tool_project_list_DropDownOpening);
            // 
            // context_tabs
            // 
            this.context_tabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_tabs_save,
            this.toolStripSeparator2,
            this.context_tabs_close,
            this.context_tabs_closeall,
            this.context_tabs_closeallbutthis,
            this.toolStripSeparator3,
            this.context_tabs_copypath,
            this.context_tabs_reveal});
            this.context_tabs.Name = "context_tabs";
            this.context_tabs.Size = new System.Drawing.Size(185, 148);
            this.context_tabs.Opening += new System.ComponentModel.CancelEventHandler(this.context_tabs_Opening);
            // 
            // context_tabs_save
            // 
            this.context_tabs_save.Image = global::PEngine.Creator.Properties.Resources.save_16xLG;
            this.context_tabs_save.Name = "context_tabs_save";
            this.context_tabs_save.Size = new System.Drawing.Size(184, 22);
            this.context_tabs_save.Text = "Save";
            this.context_tabs_save.Click += new System.EventHandler(this.context_tabs_save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // context_tabs_close
            // 
            this.context_tabs_close.Name = "context_tabs_close";
            this.context_tabs_close.Size = new System.Drawing.Size(184, 22);
            this.context_tabs_close.Text = "Close";
            this.context_tabs_close.Click += new System.EventHandler(this.context_tabs_close_Click);
            // 
            // context_tabs_closeall
            // 
            this.context_tabs_closeall.Image = global::PEngine.Creator.Properties.Resources.Close_6519;
            this.context_tabs_closeall.Name = "context_tabs_closeall";
            this.context_tabs_closeall.Size = new System.Drawing.Size(184, 22);
            this.context_tabs_closeall.Text = "Close All Documents";
            this.context_tabs_closeall.Click += new System.EventHandler(this.context_tabs_closeall_Click);
            // 
            // context_tabs_closeallbutthis
            // 
            this.context_tabs_closeallbutthis.Image = global::PEngine.Creator.Properties.Resources.Close_6519;
            this.context_tabs_closeallbutthis.Name = "context_tabs_closeallbutthis";
            this.context_tabs_closeallbutthis.Size = new System.Drawing.Size(184, 22);
            this.context_tabs_closeallbutthis.Text = "Close All But This";
            this.context_tabs_closeallbutthis.Click += new System.EventHandler(this.context_tabs_closeallbutthis_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // context_tabs_copypath
            // 
            this.context_tabs_copypath.Name = "context_tabs_copypath";
            this.context_tabs_copypath.Size = new System.Drawing.Size(184, 22);
            this.context_tabs_copypath.Text = "Copy Full Path";
            this.context_tabs_copypath.Click += new System.EventHandler(this.context_tabs_copypath_Click);
            // 
            // context_tabs_reveal
            // 
            this.context_tabs_reveal.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.context_tabs_reveal.Name = "context_tabs_reveal";
            this.context_tabs_reveal.Size = new System.Drawing.Size(184, 22);
            this.context_tabs_reveal.Text = "Reveal in Explorer";
            this.context_tabs_reveal.Click += new System.EventHandler(this.context_tabs_reveal_Click);
            // 
            // MainProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split_main);
            this.Name = "MainProjectView";
            this.Size = new System.Drawing.Size(1158, 796);
            this.split_main.Panel1.ResumeLayout(false);
            this.split_main.Panel2.ResumeLayout(false);
            this.split_main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).EndInit();
            this.split_main.ResumeLayout(false);
            this.tool_project.ResumeLayout(false);
            this.tool_project.PerformLayout();
            this.context_tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_main;
        private Components.Projects.ProjectTree projectTree;
        private System.Windows.Forms.ToolStrip tool_project;
        private System.Windows.Forms.ToolStripButton tool_project_start;
        private System.Windows.Forms.TabControl tabs_main;
        private System.Windows.Forms.ImageList imagelist_tabs;
        private System.Windows.Forms.ToolStripButton tool_save;
        private System.Windows.Forms.ToolStripButton tool_saveall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip context_tabs;
        private System.Windows.Forms.ToolStripMenuItem context_tabs_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem context_tabs_close;
        private System.Windows.Forms.ToolStripMenuItem context_tabs_closeall;
        private System.Windows.Forms.ToolStripMenuItem context_tabs_closeallbutthis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem context_tabs_copypath;
        private System.Windows.Forms.ToolStripMenuItem context_tabs_reveal;
        private System.Windows.Forms.ToolStripDropDownButton tool_project_new;
        private System.Windows.Forms.ToolStripDropDownButton tool_project_list;
        private System.Windows.Forms.ToolStripMenuItem tool_project_new_map;
        private System.Windows.Forms.ToolStripMenuItem tool_project_new_tileset;
    }
}
