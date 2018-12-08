namespace PEngine.Creator.Components.Game
{
    partial class TileComponent
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
            this.context_tile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_tile_duplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.context_tile_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.pic_texture = new System.Windows.Forms.PictureBox();
            this.context_tile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).BeginInit();
            this.SuspendLayout();
            // 
            // context_tile
            // 
            this.context_tile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_tile_duplicate,
            this.toolStripSeparator1,
            this.context_tile_delete});
            this.context_tile.Name = "context_tile";
            this.context_tile.Size = new System.Drawing.Size(181, 76);
            this.context_tile.Opening += new System.ComponentModel.CancelEventHandler(this.context_tile_Opening);
            // 
            // context_tile_duplicate
            // 
            this.context_tile_duplicate.Image = global::PEngine.Creator.Properties.Resources.Copy_6524;
            this.context_tile_duplicate.Name = "context_tile_duplicate";
            this.context_tile_duplicate.Size = new System.Drawing.Size(180, 22);
            this.context_tile_duplicate.Text = "Duplicate";
            this.context_tile_duplicate.Click += new System.EventHandler(this.context_tile_duplicate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // context_tile_delete
            // 
            this.context_tile_delete.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.context_tile_delete.Name = "context_tile_delete";
            this.context_tile_delete.Size = new System.Drawing.Size(180, 22);
            this.context_tile_delete.Text = "Delete";
            this.context_tile_delete.Click += new System.EventHandler(this.context_tile_delete_Click);
            // 
            // pic_texture
            // 
            this.pic_texture.Location = new System.Drawing.Point(14, 14);
            this.pic_texture.Name = "pic_texture";
            this.pic_texture.Size = new System.Drawing.Size(32, 32);
            this.pic_texture.TabIndex = 4;
            this.pic_texture.TabStop = false;
            this.pic_texture.Click += new System.EventHandler(this.pic_texture_Click);
            // 
            // TileComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.context_tile;
            this.Controls.Add(this.pic_texture);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TileComponent";
            this.Size = new System.Drawing.Size(62, 62);
            this.Click += new System.EventHandler(this.TileComponent_Click);
            this.context_tile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip context_tile;
        private System.Windows.Forms.ToolStripMenuItem context_tile_duplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem context_tile_delete;
        private System.Windows.Forms.PictureBox pic_texture;
    }
}
