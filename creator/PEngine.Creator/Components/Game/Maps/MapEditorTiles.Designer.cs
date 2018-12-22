namespace PEngine.Creator.Components.Game.Maps
{
    partial class MapEditorTiles
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
            this.tool_tiles = new System.Windows.Forms.ToolStrip();
            this.tool_tiles_view = new System.Windows.Forms.ToolStripButton();
            this.panel_tiles_container = new System.Windows.Forms.FlowLayoutPanel();
            this.tool_map_tool_create = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_map_tool_erase = new System.Windows.Forms.ToolStripButton();
            this.tool_map_tool_pick = new System.Windows.Forms.ToolStripButton();
            this.tool_map_tool_fill = new System.Windows.Forms.ToolStripButton();
            this.tool_tiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_tiles
            // 
            this.tool_tiles.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_tiles.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.tool_tiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_tiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_map_tool_create,
            this.tool_map_tool_erase,
            this.tool_map_tool_pick,
            this.tool_map_tool_fill,
            this.toolStripSeparator1,
            this.tool_tiles_view});
            this.tool_tiles.Location = new System.Drawing.Point(0, 0);
            this.tool_tiles.Name = "tool_tiles";
            this.tool_tiles.Size = new System.Drawing.Size(281, 25);
            this.tool_tiles.TabIndex = 0;
            this.tool_tiles.Text = "toolStrip1";
            // 
            // tool_tiles_view
            // 
            this.tool_tiles_view.Image = global::PEngine.Creator.Properties.Resources.tileset;
            this.tool_tiles_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_tiles_view.Name = "tool_tiles_view";
            this.tool_tiles_view.Size = new System.Drawing.Size(89, 22);
            this.tool_tiles_view.Text = "View Tileset";
            this.tool_tiles_view.Click += new System.EventHandler(this.tool_tiles_view_Click);
            // 
            // panel_tiles_container
            // 
            this.panel_tiles_container.AutoScroll = true;
            this.panel_tiles_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tiles_container.Location = new System.Drawing.Point(0, 25);
            this.panel_tiles_container.Name = "panel_tiles_container";
            this.panel_tiles_container.Size = new System.Drawing.Size(281, 481);
            this.panel_tiles_container.TabIndex = 1;
            // 
            // tool_map_tool_create
            // 
            this.tool_map_tool_create.Checked = true;
            this.tool_map_tool_create.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tool_map_tool_create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_tool_create.Image = global::PEngine.Creator.Properties.Resources.Select;
            this.tool_map_tool_create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_tool_create.Name = "tool_map_tool_create";
            this.tool_map_tool_create.Size = new System.Drawing.Size(23, 22);
            this.tool_map_tool_create.Text = "Tile Add Mode";
            this.tool_map_tool_create.Click += new System.EventHandler(this.tool_map_tool_create_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_map_tool_erase
            // 
            this.tool_map_tool_erase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_tool_erase.Image = global::PEngine.Creator.Properties.Resources.EraseTool_203;
            this.tool_map_tool_erase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_tool_erase.Name = "tool_map_tool_erase";
            this.tool_map_tool_erase.Size = new System.Drawing.Size(23, 22);
            this.tool_map_tool_erase.Text = "Tile Erase Mode";
            this.tool_map_tool_erase.Click += new System.EventHandler(this.tool_map_tool_erase_Click);
            // 
            // tool_map_tool_pick
            // 
            this.tool_map_tool_pick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_tool_pick.Image = global::PEngine.Creator.Properties.Resources.ColorSelectionTool_202;
            this.tool_map_tool_pick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_tool_pick.Name = "tool_map_tool_pick";
            this.tool_map_tool_pick.Size = new System.Drawing.Size(23, 22);
            this.tool_map_tool_pick.Text = "Tile Pick Mode";
            this.tool_map_tool_pick.Click += new System.EventHandler(this.tool_map_tool_pick_Click);
            // 
            // tool_map_tool_fill
            // 
            this.tool_map_tool_fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_tool_fill.Image = global::PEngine.Creator.Properties.Resources.FillTool_204;
            this.tool_map_tool_fill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_tool_fill.Name = "tool_map_tool_fill";
            this.tool_map_tool_fill.Size = new System.Drawing.Size(23, 22);
            this.tool_map_tool_fill.Text = "Tile Fill Mode";
            this.tool_map_tool_fill.Click += new System.EventHandler(this.tool_map_tool_fill_Click);
            // 
            // MapEditorTiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.Controls.Add(this.panel_tiles_container);
            this.Controls.Add(this.tool_tiles);
            this.Name = "MapEditorTiles";
            this.Size = new System.Drawing.Size(281, 506);
            this.tool_tiles.ResumeLayout(false);
            this.tool_tiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_tiles;
        private System.Windows.Forms.ToolStripButton tool_tiles_view;
        private System.Windows.Forms.FlowLayoutPanel panel_tiles_container;
        private System.Windows.Forms.ToolStripButton tool_map_tool_create;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool_map_tool_erase;
        private System.Windows.Forms.ToolStripButton tool_map_tool_pick;
        private System.Windows.Forms.ToolStripButton tool_map_tool_fill;
    }
}
