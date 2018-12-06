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
            this.pic_subtile1 = new System.Windows.Forms.PictureBox();
            this.pic_subtile2 = new System.Windows.Forms.PictureBox();
            this.pic_subtile4 = new System.Windows.Forms.PictureBox();
            this.pic_subtile3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile3)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_subtile1
            // 
            this.pic_subtile1.Location = new System.Drawing.Point(14, 14);
            this.pic_subtile1.Name = "pic_subtile1";
            this.pic_subtile1.Size = new System.Drawing.Size(16, 16);
            this.pic_subtile1.TabIndex = 0;
            this.pic_subtile1.TabStop = false;
            this.pic_subtile1.Click += new System.EventHandler(this.TileComponent_Click);
            // 
            // pic_subtile2
            // 
            this.pic_subtile2.Location = new System.Drawing.Point(30, 14);
            this.pic_subtile2.Name = "pic_subtile2";
            this.pic_subtile2.Size = new System.Drawing.Size(16, 16);
            this.pic_subtile2.TabIndex = 1;
            this.pic_subtile2.TabStop = false;
            this.pic_subtile2.Click += new System.EventHandler(this.TileComponent_Click);
            // 
            // pic_subtile4
            // 
            this.pic_subtile4.Location = new System.Drawing.Point(30, 30);
            this.pic_subtile4.Name = "pic_subtile4";
            this.pic_subtile4.Size = new System.Drawing.Size(16, 16);
            this.pic_subtile4.TabIndex = 3;
            this.pic_subtile4.TabStop = false;
            this.pic_subtile4.Click += new System.EventHandler(this.TileComponent_Click);
            // 
            // pic_subtile3
            // 
            this.pic_subtile3.Location = new System.Drawing.Point(14, 30);
            this.pic_subtile3.Name = "pic_subtile3";
            this.pic_subtile3.Size = new System.Drawing.Size(16, 16);
            this.pic_subtile3.TabIndex = 2;
            this.pic_subtile3.TabStop = false;
            this.pic_subtile3.Click += new System.EventHandler(this.TileComponent_Click);
            // 
            // TileComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pic_subtile4);
            this.Controls.Add(this.pic_subtile3);
            this.Controls.Add(this.pic_subtile2);
            this.Controls.Add(this.pic_subtile1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TileComponent";
            this.Size = new System.Drawing.Size(62, 62);
            this.Click += new System.EventHandler(this.TileComponent_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_subtile3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_subtile1;
        private System.Windows.Forms.PictureBox pic_subtile2;
        private System.Windows.Forms.PictureBox pic_subtile4;
        private System.Windows.Forms.PictureBox pic_subtile3;
    }
}
