namespace PEngine.Creator.Forms.New
{
    partial class NewMapForm
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.group_main = new System.Windows.Forms.GroupBox();
            this.pic_id_status = new System.Windows.Forms.PictureBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.combo_tileset = new System.Windows.Forms.ComboBox();
            this.lbl_tileset = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.group_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_id_status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(52, 23);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(104, 15);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Create a New Map";
            // 
            // group_main
            // 
            this.group_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.group_main.Controls.Add(this.pic_id_status);
            this.group_main.Controls.Add(this.txt_name);
            this.group_main.Controls.Add(this.lbl_name);
            this.group_main.Controls.Add(this.combo_tileset);
            this.group_main.Controls.Add(this.lbl_tileset);
            this.group_main.Controls.Add(this.txt_id);
            this.group_main.Controls.Add(this.lbl_id);
            this.group_main.Location = new System.Drawing.Point(55, 60);
            this.group_main.Name = "group_main";
            this.group_main.Size = new System.Drawing.Size(357, 132);
            this.group_main.TabIndex = 2;
            this.group_main.TabStop = false;
            this.group_main.Text = "Details";
            // 
            // pic_id_status
            // 
            this.pic_id_status.Image = global::PEngine.Creator.Properties.Resources.StatusAnnotations_Warning_16xLG_color;
            this.pic_id_status.Location = new System.Drawing.Point(318, 60);
            this.pic_id_status.Name = "pic_id_status";
            this.pic_id_status.Size = new System.Drawing.Size(16, 16);
            this.pic_id_status.TabIndex = 6;
            this.pic_id_status.TabStop = false;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(62, 28);
            this.txt_name.MaxLength = 16;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(272, 23);
            this.txt_name.TabIndex = 0;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
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
            // combo_tileset
            // 
            this.combo_tileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_tileset.FormattingEnabled = true;
            this.combo_tileset.Location = new System.Drawing.Point(62, 86);
            this.combo_tileset.Name = "combo_tileset";
            this.combo_tileset.Size = new System.Drawing.Size(272, 23);
            this.combo_tileset.TabIndex = 2;
            // 
            // lbl_tileset
            // 
            this.lbl_tileset.AutoSize = true;
            this.lbl_tileset.Location = new System.Drawing.Point(12, 89);
            this.lbl_tileset.Name = "lbl_tileset";
            this.lbl_tileset.Size = new System.Drawing.Size(44, 15);
            this.lbl_tileset.TabIndex = 2;
            this.lbl_tileset.Text = "Tileset:";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(85, 57);
            this.txt_id.MaxLength = 32;
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(225, 23);
            this.txt_id.TabIndex = 1;
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(59, 60);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(20, 15);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "Id:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(337, 198);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(256, 198);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pic_title
            // 
            this.pic_title.Image = global::PEngine.Creator.Properties.Resources.MapTileLayer_32x;
            this.pic_title.Location = new System.Drawing.Point(14, 14);
            this.pic_title.Name = "pic_title";
            this.pic_title.Size = new System.Drawing.Size(32, 32);
            this.pic_title.TabIndex = 0;
            this.pic_title.TabStop = false;
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(424, 231);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.group_main);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.pic_title);
            this.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewMapForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Map";
            this.group_main.ResumeLayout(false);
            this.group_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_id_status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_title;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox group_main;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.ComboBox combo_tileset;
        private System.Windows.Forms.Label lbl_tileset;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox pic_id_status;
    }
}