﻿namespace PEngine.Creator.Forms.New
{
    partial class NewScriptForm
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.group_main = new System.Windows.Forms.GroupBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.group_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_ok.Location = new System.Drawing.Point(256, 134);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 11;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_cancel.Location = new System.Drawing.Point(337, 134);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // group_main
            // 
            this.group_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.group_main.Controls.Add(this.txt_name);
            this.group_main.Controls.Add(this.lbl_name);
            this.group_main.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.group_main.Location = new System.Drawing.Point(55, 60);
            this.group_main.Name = "group_main";
            this.group_main.Size = new System.Drawing.Size(357, 68);
            this.group_main.TabIndex = 9;
            this.group_main.TabStop = false;
            this.group_main.Text = "Details";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(62, 28);
            this.txt_name.MaxLength = 16;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(272, 23);
            this.txt_name.TabIndex = 0;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 31);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(42, 15);
            this.lbl_name.TabIndex = 4;
            this.lbl_name.Text = "Name:";
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_title.Location = new System.Drawing.Point(52, 23);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(110, 15);
            this.lbl_title.TabIndex = 8;
            this.lbl_title.Text = "Create a New Script";
            // 
            // pic_title
            // 
            this.pic_title.Image = global::PEngine.Creator.Properties.Resources.script_32xLG;
            this.pic_title.Location = new System.Drawing.Point(14, 14);
            this.pic_title.Name = "pic_title";
            this.pic_title.Size = new System.Drawing.Size(32, 32);
            this.pic_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_title.TabIndex = 7;
            this.pic_title.TabStop = false;
            // 
            // NewScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 169);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.group_main);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.pic_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewScriptForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new script";
            this.group_main.ResumeLayout(false);
            this.group_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox group_main;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.PictureBox pic_title;
    }
}