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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesetEditor));
            this.panel_subtiles = new System.Windows.Forms.Panel();
            this.panel_subtile_container = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add_subtile = new System.Windows.Forms.Button();
            this.lbl_subtiles_title = new System.Windows.Forms.Label();
            this.panel_tiles = new System.Windows.Forms.Panel();
            this.btn_add_tile = new System.Windows.Forms.Button();
            this.lbl_tiles = new System.Windows.Forms.Label();
            this.panel_tiles_container = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_remove_tile = new System.Windows.Forms.Button();
            this.lbl_tile_title = new System.Windows.Forms.Label();
            this.pic_tile_4 = new System.Windows.Forms.PictureBox();
            this.pic_tile_3 = new System.Windows.Forms.PictureBox();
            this.pic_tile_2 = new System.Windows.Forms.PictureBox();
            this.pic_tile_1 = new System.Windows.Forms.PictureBox();
            this.group_selected_subtile = new System.Windows.Forms.GroupBox();
            this.lbl_selected_subtile = new System.Windows.Forms.Label();
            this.pic_selected_subtile = new System.Windows.Forms.PictureBox();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            this.panel_subtiles.SuspendLayout();
            this.panel_tiles.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_1)).BeginInit();
            this.group_selected_subtile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_selected_subtile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_subtiles
            // 
            this.panel_subtiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_subtiles.Controls.Add(this.panel_subtile_container);
            this.panel_subtiles.Controls.Add(this.btn_add_subtile);
            this.panel_subtiles.Controls.Add(this.lbl_subtiles_title);
            this.panel_subtiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_subtiles.Location = new System.Drawing.Point(607, 0);
            this.panel_subtiles.Name = "panel_subtiles";
            this.panel_subtiles.Size = new System.Drawing.Size(215, 644);
            this.panel_subtiles.TabIndex = 3;
            // 
            // panel_subtile_container
            // 
            this.panel_subtile_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_subtile_container.AutoScroll = true;
            this.panel_subtile_container.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel_subtile_container.Location = new System.Drawing.Point(-1, 32);
            this.panel_subtile_container.Name = "panel_subtile_container";
            this.panel_subtile_container.Size = new System.Drawing.Size(215, 611);
            this.panel_subtile_container.TabIndex = 2;
            this.panel_subtile_container.WrapContents = false;
            // 
            // btn_add_subtile
            // 
            this.btn_add_subtile.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_add_subtile.Image = global::PEngine.Creator.Properties.Resources.action_add_16xLG;
            this.btn_add_subtile.Location = new System.Drawing.Point(80, 3);
            this.btn_add_subtile.Name = "btn_add_subtile";
            this.btn_add_subtile.Size = new System.Drawing.Size(26, 23);
            this.btn_add_subtile.TabIndex = 1;
            this.tooltip_main.SetToolTip(this.btn_add_subtile, "Add new subtile");
            this.btn_add_subtile.UseVisualStyleBackColor = true;
            this.btn_add_subtile.Click += new System.EventHandler(this.btn_add_subtile_Click);
            // 
            // lbl_subtiles_title
            // 
            this.lbl_subtiles_title.AutoSize = true;
            this.lbl_subtiles_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_subtiles_title.Location = new System.Drawing.Point(5, 7);
            this.lbl_subtiles_title.Name = "lbl_subtiles_title";
            this.lbl_subtiles_title.Size = new System.Drawing.Size(65, 15);
            this.lbl_subtiles_title.TabIndex = 0;
            this.lbl_subtiles_title.Text = "Subtiles (0)";
            // 
            // panel_tiles
            // 
            this.panel_tiles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_tiles.Controls.Add(this.btn_add_tile);
            this.panel_tiles.Controls.Add(this.lbl_tiles);
            this.panel_tiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tiles.Location = new System.Drawing.Point(0, 0);
            this.panel_tiles.Name = "panel_tiles";
            this.panel_tiles.Size = new System.Drawing.Size(607, 33);
            this.panel_tiles.TabIndex = 4;
            // 
            // btn_add_tile
            // 
            this.btn_add_tile.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_add_tile.Image = global::PEngine.Creator.Properties.Resources.action_add_16xLG;
            this.btn_add_tile.Location = new System.Drawing.Point(65, 4);
            this.btn_add_tile.Name = "btn_add_tile";
            this.btn_add_tile.Size = new System.Drawing.Size(26, 23);
            this.btn_add_tile.TabIndex = 3;
            this.tooltip_main.SetToolTip(this.btn_add_tile, "Add new tile");
            this.btn_add_tile.UseVisualStyleBackColor = true;
            this.btn_add_tile.Click += new System.EventHandler(this.btn_add_tile_Click);
            // 
            // lbl_tiles
            // 
            this.lbl_tiles.AutoSize = true;
            this.lbl_tiles.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_tiles.Location = new System.Drawing.Point(3, 8);
            this.lbl_tiles.Name = "lbl_tiles";
            this.lbl_tiles.Size = new System.Drawing.Size(48, 15);
            this.lbl_tiles.TabIndex = 3;
            this.lbl_tiles.Text = "Tiles (0)";
            // 
            // panel_tiles_container
            // 
            this.panel_tiles_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_tiles_container.AutoScroll = true;
            this.panel_tiles_container.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_tiles_container.Location = new System.Drawing.Point(6, 39);
            this.panel_tiles_container.Name = "panel_tiles_container";
            this.panel_tiles_container.Size = new System.Drawing.Size(595, 475);
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
            this.panel_main.Size = new System.Drawing.Size(607, 644);
            this.panel_main.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_remove_tile);
            this.panel1.Controls.Add(this.lbl_tile_title);
            this.panel1.Controls.Add(this.pic_tile_4);
            this.panel1.Controls.Add(this.pic_tile_3);
            this.panel1.Controls.Add(this.pic_tile_2);
            this.panel1.Controls.Add(this.pic_tile_1);
            this.panel1.Controls.Add(this.group_selected_subtile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 124);
            this.panel1.TabIndex = 5;
            // 
            // btn_remove_tile
            // 
            this.btn_remove_tile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_remove_tile.Enabled = false;
            this.btn_remove_tile.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.btn_remove_tile.Location = new System.Drawing.Point(506, 77);
            this.btn_remove_tile.Name = "btn_remove_tile";
            this.btn_remove_tile.Size = new System.Drawing.Size(94, 23);
            this.btn_remove_tile.TabIndex = 6;
            this.btn_remove_tile.Text = "Delete Tile";
            this.btn_remove_tile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_remove_tile.UseVisualStyleBackColor = true;
            this.btn_remove_tile.Click += new System.EventHandler(this.btn_remove_tile_Click);
            // 
            // lbl_tile_title
            // 
            this.lbl_tile_title.AutoSize = true;
            this.lbl_tile_title.Location = new System.Drawing.Point(17, 14);
            this.lbl_tile_title.Name = "lbl_tile_title";
            this.lbl_tile_title.Size = new System.Drawing.Size(84, 13);
            this.lbl_tile_title.TabIndex = 5;
            this.lbl_tile_title.Text = "(no tile selected)";
            // 
            // pic_tile_4
            // 
            this.pic_tile_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_4.Image = ((System.Drawing.Image)(resources.GetObject("pic_tile_4.Image")));
            this.pic_tile_4.Location = new System.Drawing.Point(49, 68);
            this.pic_tile_4.Name = "pic_tile_4";
            this.pic_tile_4.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_4.TabIndex = 4;
            this.pic_tile_4.TabStop = false;
            this.pic_tile_4.Click += new System.EventHandler(this.pic_tile_4_Click);
            // 
            // pic_tile_3
            // 
            this.pic_tile_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_3.Image = ((System.Drawing.Image)(resources.GetObject("pic_tile_3.Image")));
            this.pic_tile_3.Location = new System.Drawing.Point(17, 68);
            this.pic_tile_3.Name = "pic_tile_3";
            this.pic_tile_3.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_3.TabIndex = 3;
            this.pic_tile_3.TabStop = false;
            this.pic_tile_3.Click += new System.EventHandler(this.pic_tile_3_Click);
            // 
            // pic_tile_2
            // 
            this.pic_tile_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_2.Image = ((System.Drawing.Image)(resources.GetObject("pic_tile_2.Image")));
            this.pic_tile_2.Location = new System.Drawing.Point(49, 36);
            this.pic_tile_2.Name = "pic_tile_2";
            this.pic_tile_2.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_2.TabIndex = 2;
            this.pic_tile_2.TabStop = false;
            this.pic_tile_2.Click += new System.EventHandler(this.pic_tile_2_Click);
            // 
            // pic_tile_1
            // 
            this.pic_tile_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_tile_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_tile_1.Image = global::PEngine.Creator.Properties.Resources.document_16xLG;
            this.pic_tile_1.Location = new System.Drawing.Point(17, 36);
            this.pic_tile_1.Name = "pic_tile_1";
            this.pic_tile_1.Size = new System.Drawing.Size(32, 32);
            this.pic_tile_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_tile_1.TabIndex = 1;
            this.pic_tile_1.TabStop = false;
            this.pic_tile_1.Click += new System.EventHandler(this.pic_tile_1_Click);
            // 
            // group_selected_subtile
            // 
            this.group_selected_subtile.Controls.Add(this.lbl_selected_subtile);
            this.group_selected_subtile.Controls.Add(this.pic_selected_subtile);
            this.group_selected_subtile.Location = new System.Drawing.Point(108, 35);
            this.group_selected_subtile.Name = "group_selected_subtile";
            this.group_selected_subtile.Size = new System.Drawing.Size(153, 65);
            this.group_selected_subtile.TabIndex = 0;
            this.group_selected_subtile.TabStop = false;
            this.group_selected_subtile.Text = "Selected Subtile";
            // 
            // lbl_selected_subtile
            // 
            this.lbl_selected_subtile.AutoSize = true;
            this.lbl_selected_subtile.Location = new System.Drawing.Point(47, 31);
            this.lbl_selected_subtile.Name = "lbl_selected_subtile";
            this.lbl_selected_subtile.Size = new System.Drawing.Size(97, 13);
            this.lbl_selected_subtile.TabIndex = 1;
            this.lbl_selected_subtile.Text = "No subtile selected";
            // 
            // pic_selected_subtile
            // 
            this.pic_selected_subtile.Image = global::PEngine.Creator.Properties.Resources.document_16xLG;
            this.pic_selected_subtile.Location = new System.Drawing.Point(9, 22);
            this.pic_selected_subtile.Name = "pic_selected_subtile";
            this.pic_selected_subtile.Size = new System.Drawing.Size(32, 32);
            this.pic_selected_subtile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_selected_subtile.TabIndex = 0;
            this.pic_selected_subtile.TabStop = false;
            // 
            // TilesetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_subtiles);
            this.Name = "TilesetEditor";
            this.Size = new System.Drawing.Size(822, 644);
            this.panel_subtiles.ResumeLayout(false);
            this.panel_subtiles.PerformLayout();
            this.panel_tiles.ResumeLayout(false);
            this.panel_tiles.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_tile_1)).EndInit();
            this.group_selected_subtile.ResumeLayout(false);
            this.group_selected_subtile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_selected_subtile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_subtiles;
        private System.Windows.Forms.Button btn_add_subtile;
        private System.Windows.Forms.Label lbl_subtiles_title;
        private System.Windows.Forms.FlowLayoutPanel panel_subtile_container;
        private System.Windows.Forms.Label lbl_tiles;
        private System.Windows.Forms.FlowLayoutPanel panel_tiles_container;
        private System.Windows.Forms.Panel panel_tiles;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_tile_title;
        private System.Windows.Forms.PictureBox pic_tile_4;
        private System.Windows.Forms.PictureBox pic_tile_3;
        private System.Windows.Forms.PictureBox pic_tile_2;
        private System.Windows.Forms.PictureBox pic_tile_1;
        private System.Windows.Forms.GroupBox group_selected_subtile;
        private System.Windows.Forms.Label lbl_selected_subtile;
        private System.Windows.Forms.PictureBox pic_selected_subtile;
        private System.Windows.Forms.ToolTip tooltip_main;
        private System.Windows.Forms.Button btn_remove_tile;
        private System.Windows.Forms.Button btn_add_tile;
    }
}
