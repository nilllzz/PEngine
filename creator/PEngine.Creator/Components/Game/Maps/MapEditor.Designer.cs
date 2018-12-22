namespace PEngine.Creator.Components.Game.Maps
{
    partial class MapEditor
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
            this.tool_map = new System.Windows.Forms.ToolStrip();
            this.tool_map_layer_tiles = new System.Windows.Forms.ToolStripButton();
            this.tool_map_layer_objects = new System.Windows.Forms.ToolStripButton();
            this.tool_map_layer_events = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_map_resize = new System.Windows.Forms.ToolStripButton();
            this.tool_map_grid = new System.Windows.Forms.ToolStripButton();
            this.tool_map_fill_tile = new System.Windows.Forms.ToolStripButton();
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.panel_map_container = new System.Windows.Forms.Panel();
            this.tool_map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).BeginInit();
            this.split_main.Panel1.SuspendLayout();
            this.split_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_map
            // 
            this.tool_map.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_map.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_map.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_map_layer_tiles,
            this.tool_map_layer_objects,
            this.tool_map_layer_events,
            this.toolStripSeparator1,
            this.tool_map_resize,
            this.tool_map_grid,
            this.tool_map_fill_tile});
            this.tool_map.Location = new System.Drawing.Point(0, 0);
            this.tool_map.Name = "tool_map";
            this.tool_map.Size = new System.Drawing.Size(730, 25);
            this.tool_map.TabIndex = 0;
            this.tool_map.Text = "toolStrip1";
            // 
            // tool_map_layer_tiles
            // 
            this.tool_map_layer_tiles.Checked = true;
            this.tool_map_layer_tiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tool_map_layer_tiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_layer_tiles.Image = global::PEngine.Creator.Properties.Resources.tile;
            this.tool_map_layer_tiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_layer_tiles.Name = "tool_map_layer_tiles";
            this.tool_map_layer_tiles.Size = new System.Drawing.Size(23, 22);
            this.tool_map_layer_tiles.Text = "Tiles layer";
            this.tool_map_layer_tiles.Click += new System.EventHandler(this.tool_map_layer_tiles_Click);
            // 
            // tool_map_layer_objects
            // 
            this.tool_map_layer_objects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_layer_objects.Image = global::PEngine.Creator.Properties.Resources.Diamond_16xLG;
            this.tool_map_layer_objects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_layer_objects.Name = "tool_map_layer_objects";
            this.tool_map_layer_objects.Size = new System.Drawing.Size(23, 22);
            this.tool_map_layer_objects.Text = "Objects layer";
            this.tool_map_layer_objects.Click += new System.EventHandler(this.tool_map_layer_objects_Click);
            // 
            // tool_map_layer_events
            // 
            this.tool_map_layer_events.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_layer_events.Image = global::PEngine.Creator.Properties.Resources.animation_16xLG;
            this.tool_map_layer_events.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_layer_events.Name = "tool_map_layer_events";
            this.tool_map_layer_events.Size = new System.Drawing.Size(23, 22);
            this.tool_map_layer_events.Text = "Events layer";
            this.tool_map_layer_events.Click += new System.EventHandler(this.tool_map_layer_events_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_map_resize
            // 
            this.tool_map_resize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_resize.Image = global::PEngine.Creator.Properties.Resources.Dimension_16xLG;
            this.tool_map_resize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_resize.Name = "tool_map_resize";
            this.tool_map_resize.Size = new System.Drawing.Size(23, 22);
            this.tool_map_resize.Text = "Resize map";
            this.tool_map_resize.Click += new System.EventHandler(this.tool_map_resize_Click);
            // 
            // tool_map_grid
            // 
            this.tool_map_grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_grid.Image = global::PEngine.Creator.Properties.Resources.GridDark_epx;
            this.tool_map_grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_grid.Name = "tool_map_grid";
            this.tool_map_grid.Size = new System.Drawing.Size(23, 22);
            this.tool_map_grid.Text = "Overlay Grid";
            this.tool_map_grid.Click += new System.EventHandler(this.tool_map_grid_Click);
            // 
            // tool_map_fill_tile
            // 
            this.tool_map_fill_tile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_fill_tile.Image = global::PEngine.Creator.Properties.Resources.grid_Web_16xLG;
            this.tool_map_fill_tile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_fill_tile.Name = "tool_map_fill_tile";
            this.tool_map_fill_tile.Size = new System.Drawing.Size(23, 22);
            this.tool_map_fill_tile.Text = "Pick fill tile";
            this.tool_map_fill_tile.Click += new System.EventHandler(this.tool_map_fill_tile_Click);
            // 
            // split_main
            // 
            this.split_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.split_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_main.Location = new System.Drawing.Point(0, 25);
            this.split_main.Name = "split_main";
            // 
            // split_main.Panel1
            // 
            this.split_main.Panel1.Controls.Add(this.panel_map_container);
            this.split_main.Size = new System.Drawing.Size(730, 431);
            this.split_main.SplitterDistance = 500;
            this.split_main.TabIndex = 1;
            // 
            // panel_map_container
            // 
            this.panel_map_container.AutoScroll = true;
            this.panel_map_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.panel_map_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_map_container.Location = new System.Drawing.Point(0, 0);
            this.panel_map_container.Name = "panel_map_container";
            this.panel_map_container.Size = new System.Drawing.Size(500, 431);
            this.panel_map_container.TabIndex = 0;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split_main);
            this.Controls.Add(this.tool_map);
            this.Name = "MapEditor";
            this.Size = new System.Drawing.Size(730, 456);
            this.tool_map.ResumeLayout(false);
            this.tool_map.PerformLayout();
            this.split_main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).EndInit();
            this.split_main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_map;
        private System.Windows.Forms.SplitContainer split_main;
        private System.Windows.Forms.Panel panel_map_container;
        private System.Windows.Forms.ToolStripButton tool_map_layer_tiles;
        private System.Windows.Forms.ToolStripButton tool_map_layer_objects;
        private System.Windows.Forms.ToolStripButton tool_map_layer_events;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool_map_resize;
        private System.Windows.Forms.ToolStripButton tool_map_grid;
        private System.Windows.Forms.ToolStripButton tool_map_fill_tile;
    }
}
