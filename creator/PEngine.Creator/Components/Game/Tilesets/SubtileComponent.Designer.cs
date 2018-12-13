namespace PEngine.Creator.Components.Game.Tilesets
{
    partial class SubtileComponent
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
            this.pic_texture = new CrispPictureBox();
            this.lbl_behavior = new System.Windows.Forms.Label();
            this.context_subtile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_subtile_duplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.context_subtile_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).BeginInit();
            this.context_subtile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_texture
            // 
            this.pic_texture.ContextMenuStrip = this.context_subtile;
            this.pic_texture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_texture.Location = new System.Drawing.Point(27, 3);
            this.pic_texture.Name = "pic_texture";
            this.pic_texture.Size = new System.Drawing.Size(32, 32);
            this.pic_texture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_texture.TabIndex = 0;
            this.pic_texture.TabStop = false;
            this.pic_texture.Click += new System.EventHandler(this.pic_texture_Click);
            // 
            // lbl_behavior
            // 
            this.lbl_behavior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_behavior.ContextMenuStrip = this.context_subtile;
            this.lbl_behavior.Location = new System.Drawing.Point(-1, 38);
            this.lbl_behavior.Name = "lbl_behavior";
            this.lbl_behavior.Size = new System.Drawing.Size(91, 22);
            this.lbl_behavior.TabIndex = 1;
            this.lbl_behavior.Text = "<behavior>";
            this.lbl_behavior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_behavior.Click += new System.EventHandler(this.lbl_behavior_Click);
            // 
            // context_subtile
            // 
            this.context_subtile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_subtile_duplicate,
            this.toolStripSeparator1,
            this.context_subtile_delete});
            this.context_subtile.Name = "context_subtile";
            this.context_subtile.Size = new System.Drawing.Size(181, 76);
            this.context_subtile.Opening += new System.ComponentModel.CancelEventHandler(this.context_subtile_Opening);
            // 
            // context_subtile_duplicate
            // 
            this.context_subtile_duplicate.Image = global::PEngine.Creator.Properties.Resources.Copy_6524;
            this.context_subtile_duplicate.Name = "context_subtile_duplicate";
            this.context_subtile_duplicate.Size = new System.Drawing.Size(180, 22);
            this.context_subtile_duplicate.Text = "Duplicate";
            this.context_subtile_duplicate.Click += new System.EventHandler(this.context_subtile_duplicate_Click);
            // 
            // context_subtile_delete
            // 
            this.context_subtile_delete.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.context_subtile_delete.Name = "context_subtile_delete";
            this.context_subtile_delete.Size = new System.Drawing.Size(180, 22);
            this.context_subtile_delete.Text = "Delete";
            this.context_subtile_delete.Click += new System.EventHandler(this.context_subtile_delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // SubtileComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.context_subtile;
            this.Controls.Add(this.lbl_behavior);
            this.Controls.Add(this.pic_texture);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SubtileComponent";
            this.Size = new System.Drawing.Size(89, 60);
            this.Click += new System.EventHandler(this.SubtileComponent_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).EndInit();
            this.context_subtile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrispPictureBox pic_texture;
        private System.Windows.Forms.Label lbl_behavior;
        private System.Windows.Forms.ContextMenuStrip context_subtile;
        private System.Windows.Forms.ToolStripMenuItem context_subtile_duplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem context_subtile_delete;
    }
}
