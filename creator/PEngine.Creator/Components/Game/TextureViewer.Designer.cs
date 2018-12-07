namespace PEngine.Creator.Components.Game
{
    partial class TextureViewer
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
            this.chk_stretch = new System.Windows.Forms.CheckBox();
            this.btn_reveal = new System.Windows.Forms.Button();
            this.pic_texture = new System.Windows.Forms.PictureBox();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_stretch
            // 
            this.chk_stretch.AutoSize = true;
            this.chk_stretch.Location = new System.Drawing.Point(3, 7);
            this.chk_stretch.Name = "chk_stretch";
            this.chk_stretch.Size = new System.Drawing.Size(107, 17);
            this.chk_stretch.TabIndex = 0;
            this.chk_stretch.Text = "Stretch to screen";
            this.chk_stretch.UseVisualStyleBackColor = true;
            this.chk_stretch.CheckedChanged += new System.EventHandler(this.chk_stretch_CheckedChanged);
            // 
            // btn_reveal
            // 
            this.btn_reveal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reveal.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.btn_reveal.Location = new System.Drawing.Point(495, 3);
            this.btn_reveal.Name = "btn_reveal";
            this.btn_reveal.Size = new System.Drawing.Size(23, 23);
            this.btn_reveal.TabIndex = 1;
            this.tooltip_main.SetToolTip(this.btn_reveal, "Reveal in Explorer");
            this.btn_reveal.UseVisualStyleBackColor = true;
            this.btn_reveal.Click += new System.EventHandler(this.btn_reveal_Click);
            // 
            // pic_texture
            // 
            this.pic_texture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_texture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.pic_texture.Location = new System.Drawing.Point(3, 30);
            this.pic_texture.Name = "pic_texture";
            this.pic_texture.Size = new System.Drawing.Size(515, 376);
            this.pic_texture.TabIndex = 2;
            this.pic_texture.TabStop = false;
            // 
            // TextureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pic_texture);
            this.Controls.Add(this.btn_reveal);
            this.Controls.Add(this.chk_stretch);
            this.Name = "TextureViewer";
            this.Size = new System.Drawing.Size(521, 409);
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_stretch;
        private System.Windows.Forms.Button btn_reveal;
        private System.Windows.Forms.PictureBox pic_texture;
        private System.Windows.Forms.ToolTip tooltip_main;
    }
}
