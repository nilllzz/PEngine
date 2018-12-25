namespace PEngine.Creator.Components.Game.World
{
    partial class WorldmapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldmapEditor));
            this.panel_world_container = new System.Windows.Forms.Panel();
            this.tool_main = new System.Windows.Forms.ToolStrip();
            this.tool_main_add_map = new System.Windows.Forms.ToolStripButton();
            this.tool_main_zoom_in = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_main_zoom_0 = new System.Windows.Forms.ToolStripButton();
            this.tool_main_zoom_out = new System.Windows.Forms.ToolStripButton();
            this.tool_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_world_container
            // 
            this.panel_world_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_world_container.AutoScroll = true;
            this.panel_world_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.panel_world_container.Location = new System.Drawing.Point(0, 28);
            this.panel_world_container.Name = "panel_world_container";
            this.panel_world_container.Size = new System.Drawing.Size(741, 445);
            this.panel_world_container.TabIndex = 1;
            // 
            // tool_main
            // 
            this.tool_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_main_add_map,
            this.toolStripSeparator1,
            this.tool_main_zoom_out,
            this.tool_main_zoom_0,
            this.tool_main_zoom_in});
            this.tool_main.Location = new System.Drawing.Point(0, 0);
            this.tool_main.Name = "tool_main";
            this.tool_main.Size = new System.Drawing.Size(741, 25);
            this.tool_main.TabIndex = 2;
            this.tool_main.Text = "toolStrip1";
            // 
            // tool_main_add_map
            // 
            this.tool_main_add_map.Image = global::PEngine.Creator.Properties.Resources.map_add;
            this.tool_main_add_map.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_main_add_map.Name = "tool_main_add_map";
            this.tool_main_add_map.Size = new System.Drawing.Size(76, 22);
            this.tool_main_add_map.Text = "Add map";
            this.tool_main_add_map.ToolTipText = "Add an existing map to this worldmap";
            this.tool_main_add_map.Click += new System.EventHandler(this.tool_main_add_map_Click);
            // 
            // tool_main_zoom_in
            // 
            this.tool_main_zoom_in.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_main_zoom_in.Image = global::PEngine.Creator.Properties.Resources.zoom_16xLG;
            this.tool_main_zoom_in.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_main_zoom_in.Name = "tool_main_zoom_in";
            this.tool_main_zoom_in.Size = new System.Drawing.Size(23, 22);
            this.tool_main_zoom_in.Text = "Zoom in";
            this.tool_main_zoom_in.Click += new System.EventHandler(this.tool_main_zoom_in_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_main_zoom_0
            // 
            this.tool_main_zoom_0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool_main_zoom_0.Image = ((System.Drawing.Image)(resources.GetObject("tool_main_zoom_0.Image")));
            this.tool_main_zoom_0.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_main_zoom_0.Name = "tool_main_zoom_0";
            this.tool_main_zoom_0.Size = new System.Drawing.Size(33, 22);
            this.tool_main_zoom_0.Text = "25%";
            this.tool_main_zoom_0.ToolTipText = "Reset Zoom";
            this.tool_main_zoom_0.Click += new System.EventHandler(this.tool_main_zoom_0_Click);
            // 
            // tool_main_zoom_out
            // 
            this.tool_main_zoom_out.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_main_zoom_out.Image = global::PEngine.Creator.Properties.Resources.ZoomOut_12927;
            this.tool_main_zoom_out.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_main_zoom_out.Name = "tool_main_zoom_out";
            this.tool_main_zoom_out.Size = new System.Drawing.Size(23, 22);
            this.tool_main_zoom_out.Text = "Zoom out";
            this.tool_main_zoom_out.Click += new System.EventHandler(this.tool_main_zoom_out_Click);
            // 
            // WorldmapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tool_main);
            this.Controls.Add(this.panel_world_container);
            this.Name = "WorldmapEditor";
            this.Size = new System.Drawing.Size(741, 473);
            this.tool_main.ResumeLayout(false);
            this.tool_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_world_container;
        private System.Windows.Forms.ToolStrip tool_main;
        private System.Windows.Forms.ToolStripButton tool_main_add_map;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool_main_zoom_out;
        private System.Windows.Forms.ToolStripButton tool_main_zoom_0;
        private System.Windows.Forms.ToolStripButton tool_main_zoom_in;
    }
}
