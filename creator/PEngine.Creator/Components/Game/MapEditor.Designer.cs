namespace PEngine.Creator.Components.Game
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.panel_map_container = new System.Windows.Forms.Panel();
            this.tool_map_layer_tiles = new System.Windows.Forms.ToolStripButton();
            this.tool_map_layer_objects = new System.Windows.Forms.ToolStripButton();
            this.tool_map_layer_events = new System.Windows.Forms.ToolStripButton();
            this.tool_map_tool_create = new System.Windows.Forms.ToolStripButton();
            this.tool_map_tool_erase = new System.Windows.Forms.ToolStripButton();
            this.tool_map_tool_pick = new System.Windows.Forms.ToolStripButton();
            this.tool_map_tool_fill = new System.Windows.Forms.ToolStripButton();
            this.tool_map_resize = new System.Windows.Forms.ToolStripButton();
            this.tool_map_grid = new System.Windows.Forms.ToolStripButton();
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
            this.tool_map_tool_create,
            this.tool_map_tool_erase,
            this.tool_map_tool_pick,
            this.tool_map_tool_fill,
            this.toolStripSeparator2,
            this.tool_map_resize,
            this.tool_map_grid});
            this.tool_map.Location = new System.Drawing.Point(0, 0);
            this.tool_map.Name = "tool_map";
            this.tool_map.Size = new System.Drawing.Size(730, 25);
            this.tool_map.TabIndex = 0;
            this.tool_map.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // 
            // tool_map_layer_objects
            // 
            this.tool_map_layer_objects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_layer_objects.Image = global::PEngine.Creator.Properties.Resources.Diamond_16xLG;
            this.tool_map_layer_objects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_layer_objects.Name = "tool_map_layer_objects";
            this.tool_map_layer_objects.Size = new System.Drawing.Size(23, 22);
            this.tool_map_layer_objects.Text = "Objects layer";
            // 
            // tool_map_layer_events
            // 
            this.tool_map_layer_events.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_layer_events.Image = global::PEngine.Creator.Properties.Resources.animation_16xLG;
            this.tool_map_layer_events.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_layer_events.Name = "tool_map_layer_events";
            this.tool_map_layer_events.Size = new System.Drawing.Size(23, 22);
            this.tool_map_layer_events.Text = "Events layer";
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
        private System.Windows.Forms.ToolStripButton tool_map_tool_create;
        private System.Windows.Forms.ToolStripButton tool_map_tool_erase;
        private System.Windows.Forms.ToolStripButton tool_map_tool_pick;
        private System.Windows.Forms.ToolStripButton tool_map_tool_fill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tool_map_grid;
    }
}
