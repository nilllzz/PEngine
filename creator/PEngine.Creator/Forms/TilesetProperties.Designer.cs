﻿namespace PEngine.Creator.Forms
{
    partial class TilesetProperties
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
            this.group_main = new System.Windows.Forms.GroupBox();
            this.pic_info_id = new System.Windows.Forms.PictureBox();
            this.combo_texture = new System.Windows.Forms.ComboBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.lbl_texture = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            this.group_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_info_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // group_main
            // 
            this.group_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_main.Controls.Add(this.pic_info_id);
            this.group_main.Controls.Add(this.combo_texture);
            this.group_main.Controls.Add(this.txt_id);
            this.group_main.Controls.Add(this.lbl_texture);
            this.group_main.Controls.Add(this.lbl_id);
            this.group_main.Location = new System.Drawing.Point(12, 12);
            this.group_main.Name = "group_main";
            this.group_main.Size = new System.Drawing.Size(283, 126);
            this.group_main.TabIndex = 0;
            this.group_main.TabStop = false;
            this.group_main.Text = "      Properties";
            // 
            // pic_info_id
            // 
            this.pic_info_id.Cursor = System.Windows.Forms.Cursors.Help;
            this.pic_info_id.Image = global::PEngine.Creator.Properties.Resources.StatusAnnotations_Information_16xLG_color;
            this.pic_info_id.Location = new System.Drawing.Point(252, 41);
            this.pic_info_id.Name = "pic_info_id";
            this.pic_info_id.Size = new System.Drawing.Size(16, 16);
            this.pic_info_id.TabIndex = 4;
            this.pic_info_id.TabStop = false;
            this.tooltip_main.SetToolTip(this.pic_info_id, "Changing the tileset id requires you to save the entire project.\r\nYou also need t" +
        "o update all maps that used this tileset with its old id.");
            // 
            // combo_texture
            // 
            this.combo_texture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_texture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_texture.FormattingEnabled = true;
            this.combo_texture.Location = new System.Drawing.Point(60, 76);
            this.combo_texture.Name = "combo_texture";
            this.combo_texture.Size = new System.Drawing.Size(208, 23);
            this.combo_texture.TabIndex = 3;
            // 
            // txt_id
            // 
            this.txt_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_id.Location = new System.Drawing.Point(60, 38);
            this.txt_id.MaxLength = 64;
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(188, 23);
            this.txt_id.TabIndex = 2;
            // 
            // lbl_texture
            // 
            this.lbl_texture.AutoSize = true;
            this.lbl_texture.Location = new System.Drawing.Point(6, 79);
            this.lbl_texture.Name = "lbl_texture";
            this.lbl_texture.Size = new System.Drawing.Size(48, 15);
            this.lbl_texture.TabIndex = 1;
            this.lbl_texture.Text = "Texture:";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(6, 41);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 15);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "ID:";
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Location = new System.Drawing.Point(139, 144);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(220, 144);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PEngine.Creator.Properties.Resources.properties_16xLG;
            this.pictureBox1.Location = new System.Drawing.Point(21, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tooltip_main
            // 
            this.tooltip_main.AutoPopDelay = 5000;
            this.tooltip_main.InitialDelay = 500;
            this.tooltip_main.ReshowDelay = 100;
            // 
            // TilesetProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(309, 179);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.group_main);
            this.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TilesetProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Tileset";
            this.group_main.ResumeLayout(false);
            this.group_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_info_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_main;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ComboBox combo_texture;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label lbl_texture;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.PictureBox pic_info_id;
        private System.Windows.Forms.ToolTip tooltip_main;
    }
}