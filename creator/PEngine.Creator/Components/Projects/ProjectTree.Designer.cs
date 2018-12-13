namespace PEngine.Creator.Components.Projects
{
    partial class ProjectTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTree));
            this.tree_main = new System.Windows.Forms.TreeView();
            this.tree_images = new System.Windows.Forms.ImageList(this.components);
            this.tool_main = new System.Windows.Forms.ToolStrip();
            this.tool_refresh = new System.Windows.Forms.ToolStripButton();
            this.tool_collapse = new System.Windows.Forms.ToolStripButton();
            this.context_folders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_folders_add = new System.Windows.Forms.ToolStripMenuItem();
            this.context_folders_add_existing = new System.Windows.Forms.ToolStripMenuItem();
            this.context_folders_add_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.context_folder_add_map = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.context_folders_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.context_folders_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.context_folders_reveal = new System.Windows.Forms.ToolStripMenuItem();
            this.context_files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_files_open = new System.Windows.Forms.ToolStripMenuItem();
            this.context_files_reveal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.context_files_exclude = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.context_files_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.context_files_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_main.SuspendLayout();
            this.context_folders.SuspendLayout();
            this.context_files.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree_main
            // 
            this.tree_main.AllowDrop = true;
            this.tree_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.tree_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree_main.FullRowSelect = true;
            this.tree_main.HideSelection = false;
            this.tree_main.ImageIndex = 0;
            this.tree_main.ImageList = this.tree_images;
            this.tree_main.LabelEdit = true;
            this.tree_main.Location = new System.Drawing.Point(0, 28);
            this.tree_main.Name = "tree_main";
            this.tree_main.SelectedImageIndex = 0;
            this.tree_main.ShowLines = false;
            this.tree_main.Size = new System.Drawing.Size(326, 568);
            this.tree_main.TabIndex = 0;
            this.tree_main.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tree_main_AfterLabelEdit);
            this.tree_main.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_main_ItemDrag);
            this.tree_main.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_main_NodeMouseClick);
            this.tree_main.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_main_NodeMouseDoubleClick);
            this.tree_main.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_main_DragDrop);
            this.tree_main.DragEnter += new System.Windows.Forms.DragEventHandler(this.tree_main_DragEnter);
            // 
            // tree_images
            // 
            this.tree_images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tree_images.ImageStream")));
            this.tree_images.TransparentColor = System.Drawing.Color.Transparent;
            this.tree_images.Images.SetKeyName(0, "file_generic");
            this.tree_images.Images.SetKeyName(1, "folder_closed");
            this.tree_images.Images.SetKeyName(2, "folder_open");
            this.tree_images.Images.SetKeyName(3, "file_map");
            this.tree_images.Images.SetKeyName(4, "file_image");
            this.tree_images.Images.SetKeyName(5, "file_tileset");
            this.tree_images.Images.SetKeyName(6, "project_closed");
            this.tree_images.Images.SetKeyName(7, "project_open");
            // 
            // tool_main
            // 
            this.tool_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_refresh,
            this.tool_collapse});
            this.tool_main.Location = new System.Drawing.Point(0, 0);
            this.tool_main.Name = "tool_main";
            this.tool_main.Size = new System.Drawing.Size(326, 25);
            this.tool_main.TabIndex = 1;
            // 
            // tool_refresh
            // 
            this.tool_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_refresh.Image = global::PEngine.Creator.Properties.Resources.refresh_16xLG;
            this.tool_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_refresh.Name = "tool_refresh";
            this.tool_refresh.Size = new System.Drawing.Size(23, 22);
            this.tool_refresh.Text = "Refresh";
            this.tool_refresh.Click += new System.EventHandler(this.tool_refresh_Click);
            // 
            // tool_collapse
            // 
            this.tool_collapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_collapse.Image = global::PEngine.Creator.Properties.Resources.collapseAll;
            this.tool_collapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_collapse.Name = "tool_collapse";
            this.tool_collapse.Size = new System.Drawing.Size(23, 22);
            this.tool_collapse.Text = "Collapse All";
            this.tool_collapse.Click += new System.EventHandler(this.tool_collapse_Click);
            // 
            // context_folders
            // 
            this.context_folders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_folders_add,
            this.toolStripSeparator3,
            this.context_folders_rename,
            this.context_folders_delete,
            this.toolStripSeparator5,
            this.context_folders_reveal});
            this.context_folders.Name = "context_containers";
            this.context_folders.Size = new System.Drawing.Size(167, 104);
            this.context_folders.Opening += new System.ComponentModel.CancelEventHandler(this.context_folders_Opening);
            // 
            // context_folders_add
            // 
            this.context_folders_add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_folders_add_existing,
            this.context_folders_add_folder,
            this.toolStripSeparator4,
            this.context_folder_add_map});
            this.context_folders_add.Name = "context_folders_add";
            this.context_folders_add.Size = new System.Drawing.Size(166, 22);
            this.context_folders_add.Text = "Add...";
            // 
            // context_folders_add_existing
            // 
            this.context_folders_add_existing.Image = global::PEngine.Creator.Properties.Resources.AddExistingItem_6269;
            this.context_folders_add_existing.Name = "context_folders_add_existing";
            this.context_folders_add_existing.Size = new System.Drawing.Size(180, 22);
            this.context_folders_add_existing.Text = "Existing Item...";
            // 
            // context_folders_add_folder
            // 
            this.context_folders_add_folder.Image = global::PEngine.Creator.Properties.Resources.newFolder;
            this.context_folders_add_folder.Name = "context_folders_add_folder";
            this.context_folders_add_folder.Size = new System.Drawing.Size(180, 22);
            this.context_folders_add_folder.Text = "New Folder";
            this.context_folders_add_folder.Click += new System.EventHandler(this.context_folders_add_folder_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // context_folder_add_map
            // 
            this.context_folder_add_map.Image = global::PEngine.Creator.Properties.Resources.newMap;
            this.context_folder_add_map.Name = "context_folder_add_map";
            this.context_folder_add_map.Size = new System.Drawing.Size(180, 22);
            this.context_folder_add_map.Text = "Map";
            this.context_folder_add_map.Click += new System.EventHandler(this.context_folder_add_map_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // context_folders_delete
            // 
            this.context_folders_delete.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.context_folders_delete.Name = "context_folders_delete";
            this.context_folders_delete.Size = new System.Drawing.Size(166, 22);
            this.context_folders_delete.Text = "Delete";
            this.context_folders_delete.Click += new System.EventHandler(this.context_folders_delete_Click);
            // 
            // context_folders_rename
            // 
            this.context_folders_rename.Image = global::PEngine.Creator.Properties.Resources.Rename_6779;
            this.context_folders_rename.Name = "context_folders_rename";
            this.context_folders_rename.Size = new System.Drawing.Size(166, 22);
            this.context_folders_rename.Text = "Rename";
            this.context_folders_rename.Click += new System.EventHandler(this.context_folders_rename_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(163, 6);
            // 
            // context_folders_reveal
            // 
            this.context_folders_reveal.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.context_folders_reveal.Name = "context_folders_reveal";
            this.context_folders_reveal.Size = new System.Drawing.Size(166, 22);
            this.context_folders_reveal.Text = "Reveal in Explorer";
            this.context_folders_reveal.Click += new System.EventHandler(this.context_folders_reveal_Click);
            // 
            // context_files
            // 
            this.context_files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_files_open,
            this.toolStripSeparator1,
            this.context_files_rename,
            this.context_files_delete,
            this.context_files_exclude,
            this.toolStripSeparator2,
            this.context_files_reveal});
            this.context_files.Name = "context_items";
            this.context_files.Size = new System.Drawing.Size(184, 148);
            // 
            // context_files_open
            // 
            this.context_files_open.Name = "context_files_open";
            this.context_files_open.Size = new System.Drawing.Size(183, 22);
            this.context_files_open.Text = "Open";
            this.context_files_open.Click += new System.EventHandler(this.context_files_open_Click);
            // 
            // context_files_reveal
            // 
            this.context_files_reveal.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.context_files_reveal.Name = "context_files_reveal";
            this.context_files_reveal.Size = new System.Drawing.Size(183, 22);
            this.context_files_reveal.Text = "Reveal in Explorer";
            this.context_files_reveal.Click += new System.EventHandler(this.context_files_reveal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // context_files_exclude
            // 
            this.context_files_exclude.Image = global::PEngine.Creator.Properties.Resources.HiddenFolder_427;
            this.context_files_exclude.Name = "context_files_exclude";
            this.context_files_exclude.Size = new System.Drawing.Size(183, 22);
            this.context_files_exclude.Text = "Exclude from Project";
            this.context_files_exclude.Click += new System.EventHandler(this.context_files_exclude_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // context_files_delete
            // 
            this.context_files_delete.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.context_files_delete.Name = "context_files_delete";
            this.context_files_delete.Size = new System.Drawing.Size(183, 22);
            this.context_files_delete.Text = "Delete";
            this.context_files_delete.Click += new System.EventHandler(this.context_files_delete_Click);
            // 
            // context_files_rename
            // 
            this.context_files_rename.Image = global::PEngine.Creator.Properties.Resources.Rename_6779;
            this.context_files_rename.Name = "context_files_rename";
            this.context_files_rename.Size = new System.Drawing.Size(183, 22);
            this.context_files_rename.Text = "Rename";
            this.context_files_rename.Click += new System.EventHandler(this.context_files_rename_Click);
            // 
            // ProjectTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tool_main);
            this.Controls.Add(this.tree_main);
            this.Name = "ProjectTree";
            this.Size = new System.Drawing.Size(326, 596);
            this.tool_main.ResumeLayout(false);
            this.tool_main.PerformLayout();
            this.context_folders.ResumeLayout(false);
            this.context_files.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree_main;
        private System.Windows.Forms.ToolStrip tool_main;
        private System.Windows.Forms.ToolStripButton tool_refresh;
        private System.Windows.Forms.ToolStripButton tool_collapse;
        private System.Windows.Forms.ImageList tree_images;
        private System.Windows.Forms.ContextMenuStrip context_folders;
        private System.Windows.Forms.ToolStripMenuItem context_folders_reveal;
        private System.Windows.Forms.ContextMenuStrip context_files;
        private System.Windows.Forms.ToolStripMenuItem context_files_open;
        private System.Windows.Forms.ToolStripMenuItem context_files_reveal;
        private System.Windows.Forms.ToolStripMenuItem context_files_exclude;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem context_files_delete;
        private System.Windows.Forms.ToolStripMenuItem context_folders_add;
        private System.Windows.Forms.ToolStripMenuItem context_folders_add_existing;
        private System.Windows.Forms.ToolStripMenuItem context_folders_add_folder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem context_folder_add_map;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem context_folders_delete;
        private System.Windows.Forms.ToolStripMenuItem context_folders_rename;
        private System.Windows.Forms.ToolStripMenuItem context_files_rename;
    }
}
