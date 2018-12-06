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
            this.tool_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree_main
            // 
            this.tree_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.tree_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree_main.FullRowSelect = true;
            this.tree_main.ImageIndex = 0;
            this.tree_main.ImageList = this.tree_images;
            this.tree_main.Location = new System.Drawing.Point(0, 28);
            this.tree_main.Name = "tree_main";
            this.tree_main.SelectedImageIndex = 0;
            this.tree_main.Size = new System.Drawing.Size(326, 568);
            this.tree_main.TabIndex = 0;
            // 
            // tree_images
            // 
            this.tree_images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tree_images.ImageStream")));
            this.tree_images.TransparentColor = System.Drawing.Color.Transparent;
            this.tree_images.Images.SetKeyName(0, "file_generic");
            this.tree_images.Images.SetKeyName(1, "folder_closed");
            this.tree_images.Images.SetKeyName(2, "folder_open");
            this.tree_images.Images.SetKeyName(3, "file_map");
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
            // 
            // tool_collapse
            // 
            this.tool_collapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_collapse.Image = global::PEngine.Creator.Properties.Resources.Collapse_16xLG;
            this.tool_collapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_collapse.Name = "tool_collapse";
            this.tool_collapse.Size = new System.Drawing.Size(23, 22);
            this.tool_collapse.Text = "Collapse All";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree_main;
        private System.Windows.Forms.ToolStrip tool_main;
        private System.Windows.Forms.ToolStripButton tool_refresh;
        private System.Windows.Forms.ToolStripButton tool_collapse;
        private System.Windows.Forms.ImageList tree_images;
    }
}
