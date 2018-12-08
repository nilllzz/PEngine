namespace PEngine.Creator.Components.Debug
{
    partial class MapPreview
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
            this.panel_container = new System.Windows.Forms.Panel();
            this.tool_map_player_pos = new System.Windows.Forms.ToolStripLabel();
            this.tool_map_pick_player_pos = new System.Windows.Forms.ToolStripButton();
            this.tool_map.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_map
            // 
            this.tool_map.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_map.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_map.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_map_player_pos,
            this.tool_map_pick_player_pos});
            this.tool_map.Location = new System.Drawing.Point(0, 0);
            this.tool_map.Name = "tool_map";
            this.tool_map.Size = new System.Drawing.Size(675, 25);
            this.tool_map.TabIndex = 0;
            this.tool_map.Text = "toolStrip1";
            // 
            // panel_container
            // 
            this.panel_container.AutoScroll = true;
            this.panel_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.Location = new System.Drawing.Point(0, 25);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(675, 378);
            this.panel_container.TabIndex = 1;
            // 
            // tool_map_player_pos
            // 
            this.tool_map_player_pos.Image = global::PEngine.Creator.Properties.Resources.player;
            this.tool_map_player_pos.Name = "tool_map_player_pos";
            this.tool_map_player_pos.Size = new System.Drawing.Size(49, 22);
            this.tool_map_player_pos.Text = "{0, 0}";
            this.tool_map_player_pos.ToolTipText = "Player\'s position";
            // 
            // tool_map_pick_player_pos
            // 
            this.tool_map_pick_player_pos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_map_pick_player_pos.Image = global::PEngine.Creator.Properties.Resources.Select;
            this.tool_map_pick_player_pos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_map_pick_player_pos.Name = "tool_map_pick_player_pos";
            this.tool_map_pick_player_pos.Size = new System.Drawing.Size(23, 22);
            this.tool_map_pick_player_pos.Text = "Pick Player position";
            this.tool_map_pick_player_pos.Click += new System.EventHandler(this.tool_map_pick_player_pos_Click);
            // 
            // MapPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.tool_map);
            this.Name = "MapPreview";
            this.Size = new System.Drawing.Size(675, 403);
            this.tool_map.ResumeLayout(false);
            this.tool_map.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_map;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.ToolStripLabel tool_map_player_pos;
        private System.Windows.Forms.ToolStripButton tool_map_pick_player_pos;
    }
}
