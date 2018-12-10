namespace PEngine.Creator.Components.Game
{
    partial class TilesetEditor
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
            this.panel_subtiles = new System.Windows.Forms.Panel();
            this.tool_subtiles = new System.Windows.Forms.ToolStrip();
            this.tool_subtiles_lbl_title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_subtiles_add = new System.Windows.Forms.ToolStripButton();
            this.panel_subtile_container = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_tiles = new System.Windows.Forms.Panel();
            this.tool_editor = new System.Windows.Forms.ToolStrip();
            this.tool_editor_lbl_tiles = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_editor_add_tile = new System.Windows.Forms.ToolStripButton();
            this.tool_editor_properties = new System.Windows.Forms.ToolStripButton();
            this.tool_editor_texture = new System.Windows.Forms.ToolStripButton();
            this.panel_tiles_container = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.group_edit_tile = new System.Windows.Forms.GroupBox();
            this.pic_tile_1 = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.pic_edit_mode = new System.Windows.Forms.PictureBox();
            this.pic_tile_4 = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.group_selected_subtile = new System.Windows.Forms.GroupBox();
            this.lbl_no_subtile = new System.Windows.Forms.Label();
            this.pic_tile_2 = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.pic_tile_3 = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.panel_subtiles.SuspendLayout();
            this.tool_subtiles.SuspendLayout();
            this.panel_tiles.SuspendLayout();
            this.tool_editor.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.group_edit_tile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_edit_mode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_4)).BeginInit();
            this.group_selected_subtile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).BeginInit();
            this.split_main.Panel1.SuspendLayout();
            this.split_main.Panel2.SuspendLayout();
            this.split_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_subtiles
            // 
            this.panel_subtiles.Controls.Add(this.tool_subtiles);
            this.panel_subtiles.Controls.Add(this.panel_subtile_container);
            this.panel_subtiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_subtiles.Location = new System.Drawing.Point(0, 0);
            this.panel_subtiles.Name = "panel_subtiles";
            this.panel_subtiles.Size = new System.Drawing.Size(252, 644);
            this.panel_subtiles.TabIndex = 3;
            // 
            // tool_subtiles
            // 
            this.tool_subtiles.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_subtiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_subtiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_subtiles_lbl_title,
            this.toolStripSeparator2,
            this.tool_subtiles_add});
            this.tool_subtiles.Location = new System.Drawing.Point(0, 0);
            this.tool_subtiles.Name = "tool_subtiles";
            this.tool_subtiles.Size = new System.Drawing.Size(252, 25);
            this.tool_subtiles.TabIndex = 3;
            this.tool_subtiles.Text = "toolStrip1";
            // 
            // tool_subtiles_lbl_title
            // 
            this.tool_subtiles_lbl_title.Name = "tool_subtiles_lbl_title";
            this.tool_subtiles_lbl_title.Size = new System.Drawing.Size(65, 22);
            this.tool_subtiles_lbl_title.Text = "Subtiles (0)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_subtiles_add
            // 
            this.tool_subtiles_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_subtiles_add.Image = global::PEngine.Creator.Properties.Resources.new_subtile;
            this.tool_subtiles_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_subtiles_add.Name = "tool_subtiles_add";
            this.tool_subtiles_add.Size = new System.Drawing.Size(23, 22);
            this.tool_subtiles_add.Text = "Add New Subtile";
            this.tool_subtiles_add.Click += new System.EventHandler(this.tool_subtiles_add_Click);
            // 
            // panel_subtile_container
            // 
            this.panel_subtile_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_subtile_container.AutoScroll = true;
            this.panel_subtile_container.Location = new System.Drawing.Point(-1, 27);
            this.panel_subtile_container.Name = "panel_subtile_container";
            this.panel_subtile_container.Size = new System.Drawing.Size(254, 618);
            this.panel_subtile_container.TabIndex = 2;
            // 
            // panel_tiles
            // 
            this.panel_tiles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_tiles.Controls.Add(this.tool_editor);
            this.panel_tiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tiles.Location = new System.Drawing.Point(0, 0);
            this.panel_tiles.Name = "panel_tiles";
            this.panel_tiles.Size = new System.Drawing.Size(566, 26);
            this.panel_tiles.TabIndex = 4;
            // 
            // tool_editor
            // 
            this.tool_editor.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_editor.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.tool_editor.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_editor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_editor_lbl_tiles,
            this.toolStripSeparator1,
            this.tool_editor_add_tile,
            this.tool_editor_properties,
            this.tool_editor_texture});
            this.tool_editor.Location = new System.Drawing.Point(0, 0);
            this.tool_editor.Name = "tool_editor";
            this.tool_editor.Size = new System.Drawing.Size(566, 25);
            this.tool_editor.TabIndex = 0;
            this.tool_editor.Text = "toolStrip1";
            // 
            // tool_editor_lbl_tiles
            // 
            this.tool_editor_lbl_tiles.Name = "tool_editor_lbl_tiles";
            this.tool_editor_lbl_tiles.Size = new System.Drawing.Size(48, 22);
            this.tool_editor_lbl_tiles.Text = "Tiles (0)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_editor_add_tile
            // 
            this.tool_editor_add_tile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_editor_add_tile.Image = global::PEngine.Creator.Properties.Resources.new_tile;
            this.tool_editor_add_tile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_editor_add_tile.Name = "tool_editor_add_tile";
            this.tool_editor_add_tile.Size = new System.Drawing.Size(23, 22);
            this.tool_editor_add_tile.Text = "Add New Tile";
            this.tool_editor_add_tile.Click += new System.EventHandler(this.tool_editor_add_tile_Click);
            // 
            // tool_editor_properties
            // 
            this.tool_editor_properties.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tool_editor_properties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_editor_properties.Image = global::PEngine.Creator.Properties.Resources.properties_16xLG;
            this.tool_editor_properties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_editor_properties.Name = "tool_editor_properties";
            this.tool_editor_properties.Size = new System.Drawing.Size(23, 22);
            this.tool_editor_properties.Text = "Properties";
            this.tool_editor_properties.Click += new System.EventHandler(this.tool_editor_properties_Click);
            // 
            // tool_editor_texture
            // 
            this.tool_editor_texture.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tool_editor_texture.Image = global::PEngine.Creator.Properties.Resources.Image_12x;
            this.tool_editor_texture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_editor_texture.Name = "tool_editor_texture";
            this.tool_editor_texture.Size = new System.Drawing.Size(93, 22);
            this.tool_editor_texture.Text = "View Texture";
            this.tool_editor_texture.Click += new System.EventHandler(this.tool_editor_texture_Click);
            // 
            // panel_tiles_container
            // 
            this.panel_tiles_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_tiles_container.AutoScroll = true;
            this.panel_tiles_container.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_tiles_container.Location = new System.Drawing.Point(6, 28);
            this.panel_tiles_container.Name = "panel_tiles_container";
            this.panel_tiles_container.Size = new System.Drawing.Size(554, 486);
            this.panel_tiles_container.TabIndex = 1;
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.panel1);
            this.panel_main.Controls.Add(this.panel_tiles);
            this.panel_main.Controls.Add(this.panel_tiles_container);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(566, 644);
            this.panel_main.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.group_edit_tile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 124);
            this.panel1.TabIndex = 5;
            // 
            // group_edit_tile
            // 
            this.group_edit_tile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_edit_tile.Controls.Add(this.pic_tile_1);
            this.group_edit_tile.Controls.Add(this.pic_edit_mode);
            this.group_edit_tile.Controls.Add(this.pic_tile_4);
            this.group_edit_tile.Controls.Add(this.group_selected_subtile);
            this.group_edit_tile.Controls.Add(this.pic_tile_2);
            this.group_edit_tile.Controls.Add(this.pic_tile_3);
            this.group_edit_tile.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.group_edit_tile.Location = new System.Drawing.Point(6, 3);
            this.group_edit_tile.Name = "group_edit_tile";
            this.group_edit_tile.Size = new System.Drawing.Size(554, 118);
            this.group_edit_tile.TabIndex = 7;
            this.group_edit_tile.TabStop = false;
            this.group_edit_tile.Text = "Edit tile";
            // 
            // pic_tile_1
            // 
            this.pic_tile_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_1.Image = global::PEngine.Creator.Properties.Resources.subtile;
            this.pic_tile_1.Location = new System.Drawing.Point(13, 31);
            this.pic_tile_1.Name = "pic_tile_1";
            this.pic_tile_1.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_1.TabIndex = 1;
            this.pic_tile_1.TabStop = false;
            this.pic_tile_1.Click += new System.EventHandler(this.pic_tile_1_Click);
            // 
            // pic_edit_mode
            // 
            this.pic_edit_mode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_edit_mode.Image = global::PEngine.Creator.Properties.Resources.arrow_previous_16xLG;
            this.pic_edit_mode.Location = new System.Drawing.Point(88, 54);
            this.pic_edit_mode.Name = "pic_edit_mode";
            this.pic_edit_mode.Size = new System.Drawing.Size(16, 16);
            this.pic_edit_mode.TabIndex = 5;
            this.pic_edit_mode.TabStop = false;
            this.pic_edit_mode.Click += new System.EventHandler(this.pic_edit_mode_Click);
            // 
            // pic_tile_4
            // 
            this.pic_tile_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_4.Image = global::PEngine.Creator.Properties.Resources.subtile;
            this.pic_tile_4.Location = new System.Drawing.Point(45, 63);
            this.pic_tile_4.Name = "pic_tile_4";
            this.pic_tile_4.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_4.TabIndex = 4;
            this.pic_tile_4.TabStop = false;
            this.pic_tile_4.Click += new System.EventHandler(this.pic_tile_4_Click);
            // 
            // group_selected_subtile
            // 
            this.group_selected_subtile.Controls.Add(this.lbl_no_subtile);
            this.group_selected_subtile.Location = new System.Drawing.Point(116, 22);
            this.group_selected_subtile.Name = "group_selected_subtile";
            this.group_selected_subtile.Size = new System.Drawing.Size(256, 77);
            this.group_selected_subtile.TabIndex = 0;
            this.group_selected_subtile.TabStop = false;
            this.group_selected_subtile.Text = "Selected Subtile";
            // 
            // lbl_no_subtile
            // 
            this.lbl_no_subtile.AutoSize = true;
            this.lbl_no_subtile.Location = new System.Drawing.Point(16, 32);
            this.lbl_no_subtile.Name = "lbl_no_subtile";
            this.lbl_no_subtile.Size = new System.Drawing.Size(124, 15);
            this.lbl_no_subtile.TabIndex = 0;
            this.lbl_no_subtile.Text = "<No Subtile selected>";
            // 
            // pic_tile_2
            // 
            this.pic_tile_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_2.Image = global::PEngine.Creator.Properties.Resources.subtile;
            this.pic_tile_2.Location = new System.Drawing.Point(45, 31);
            this.pic_tile_2.Name = "pic_tile_2";
            this.pic_tile_2.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_2.TabIndex = 2;
            this.pic_tile_2.TabStop = false;
            this.pic_tile_2.Click += new System.EventHandler(this.pic_tile_2_Click);
            // 
            // pic_tile_3
            // 
            this.pic_tile_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_3.Image = global::PEngine.Creator.Properties.Resources.subtile;
            this.pic_tile_3.Location = new System.Drawing.Point(13, 63);
            this.pic_tile_3.Name = "pic_tile_3";
            this.pic_tile_3.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_3.TabIndex = 3;
            this.pic_tile_3.TabStop = false;
            this.pic_tile_3.Click += new System.EventHandler(this.pic_tile_3_Click);
            // 
            // split_main
            // 
            this.split_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_main.Location = new System.Drawing.Point(0, 0);
            this.split_main.Name = "split_main";
            // 
            // split_main.Panel1
            // 
            this.split_main.Panel1.Controls.Add(this.panel_main);
            // 
            // split_main.Panel2
            // 
            this.split_main.Panel2.Controls.Add(this.panel_subtiles);
            this.split_main.Size = new System.Drawing.Size(822, 644);
            this.split_main.SplitterDistance = 566;
            this.split_main.TabIndex = 7;
            // 
            // TilesetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.Controls.Add(this.split_main);
            this.Name = "TilesetEditor";
            this.Size = new System.Drawing.Size(822, 644);
            this.panel_subtiles.ResumeLayout(false);
            this.panel_subtiles.PerformLayout();
            this.tool_subtiles.ResumeLayout(false);
            this.tool_subtiles.PerformLayout();
            this.panel_tiles.ResumeLayout(false);
            this.panel_tiles.PerformLayout();
            this.tool_editor.ResumeLayout(false);
            this.tool_editor.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.group_edit_tile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_edit_mode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_4)).EndInit();
            this.group_selected_subtile.ResumeLayout(false);
            this.group_selected_subtile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_3)).EndInit();
            this.split_main.Panel1.ResumeLayout(false);
            this.split_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).EndInit();
            this.split_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_subtiles;
        private System.Windows.Forms.FlowLayoutPanel panel_subtile_container;
        private System.Windows.Forms.FlowLayoutPanel panel_tiles_container;
        private System.Windows.Forms.Panel panel_tiles;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel1;
        private CrispPictureBox pic_tile_4;
        private CrispPictureBox pic_tile_3;
        private CrispPictureBox pic_tile_2;
        private CrispPictureBox pic_tile_1;
        private System.Windows.Forms.GroupBox group_selected_subtile;
        private System.Windows.Forms.ToolTip tooltip_main;
        private System.Windows.Forms.ToolStrip tool_editor;
        private System.Windows.Forms.ToolStripLabel tool_editor_lbl_tiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool_editor_add_tile;
        private System.Windows.Forms.ToolStrip tool_subtiles;
        private System.Windows.Forms.ToolStripLabel tool_subtiles_lbl_title;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tool_subtiles_add;
        private System.Windows.Forms.GroupBox group_edit_tile;
        private System.Windows.Forms.PictureBox pic_edit_mode;
        private System.Windows.Forms.Label lbl_no_subtile;
        private System.Windows.Forms.ToolStripButton tool_editor_properties;
        private System.Windows.Forms.ToolStripButton tool_editor_texture;
        private System.Windows.Forms.SplitContainer split_main;
    }
}
