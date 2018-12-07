namespace PEngine.Creator.Forms
{
    partial class TexturePickerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_reveal = new System.Windows.Forms.Button();
            this.panel_textures = new System.Windows.Forms.FlowLayoutPanel();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_title.Location = new System.Drawing.Point(12, 12);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(211, 15);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Pick a texture from the selection below";
            // 
            // btn_reveal
            // 
            this.btn_reveal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reveal.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.btn_reveal.Location = new System.Drawing.Point(530, 8);
            this.btn_reveal.Name = "btn_reveal";
            this.btn_reveal.Size = new System.Drawing.Size(23, 23);
            this.btn_reveal.TabIndex = 1;
            this.tooltip_main.SetToolTip(this.btn_reveal, "Reveal in Explorer");
            this.btn_reveal.UseVisualStyleBackColor = true;
            this.btn_reveal.Click += new System.EventHandler(this.btn_reveal_Click);
            // 
            // panel_textures
            // 
            this.panel_textures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_textures.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.panel_textures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_textures.Location = new System.Drawing.Point(12, 37);
            this.panel_textures.Name = "panel_textures";
            this.panel_textures.Size = new System.Drawing.Size(541, 292);
            this.panel_textures.TabIndex = 2;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_ok.Location = new System.Drawing.Point(397, 335);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_cancel.Location = new System.Drawing.Point(478, 335);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // TexturePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(565, 370);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.panel_textures);
            this.Controls.Add(this.btn_reveal);
            this.Controls.Add(this.lbl_title);
            this.Name = "TexturePickerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pick a texture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_reveal;
        private System.Windows.Forms.ToolTip tooltip_main;
        private System.Windows.Forms.FlowLayoutPanel panel_textures;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}