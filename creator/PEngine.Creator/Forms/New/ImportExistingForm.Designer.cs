namespace PEngine.Creator.Forms.New
{
    partial class ImportExistingForm
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
            this.crispPictureBox1 = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.lbl_file = new System.Windows.Forms.Label();
            this.btn_select_file = new System.Windows.Forms.Button();
            this.group_type = new System.Windows.Forms.GroupBox();
            this.radio_texture_character = new System.Windows.Forms.RadioButton();
            this.radio_texture_tileset = new System.Windows.Forms.RadioButton();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crispPictureBox1)).BeginInit();
            this.group_type.SuspendLayout();
            this.SuspendLayout();
            // 
            // crispPictureBox1
            // 
            this.crispPictureBox1.Image = global::PEngine.Creator.Properties.Resources.document_16xLG;
            this.crispPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.crispPictureBox1.Name = "crispPictureBox1";
            this.crispPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.crispPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.crispPictureBox1.TabIndex = 0;
            this.crispPictureBox1.TabStop = false;
            // 
            // lbl_file
            // 
            this.lbl_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_file.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_file.Location = new System.Drawing.Point(50, 12);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(275, 32);
            this.lbl_file.TabIndex = 1;
            this.lbl_file.Text = "<No File Selected>";
            this.lbl_file.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_select_file
            // 
            this.btn_select_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_file.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_select_file.Location = new System.Drawing.Point(331, 17);
            this.btn_select_file.Name = "btn_select_file";
            this.btn_select_file.Size = new System.Drawing.Size(26, 23);
            this.btn_select_file.TabIndex = 2;
            this.btn_select_file.Text = "...";
            this.btn_select_file.UseVisualStyleBackColor = true;
            this.btn_select_file.Click += new System.EventHandler(this.btn_select_file_Click);
            // 
            // group_type
            // 
            this.group_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_type.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.group_type.Controls.Add(this.radio_texture_character);
            this.group_type.Controls.Add(this.radio_texture_tileset);
            this.group_type.Enabled = false;
            this.group_type.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.group_type.Location = new System.Drawing.Point(12, 50);
            this.group_type.Name = "group_type";
            this.group_type.Size = new System.Drawing.Size(345, 83);
            this.group_type.TabIndex = 3;
            this.group_type.TabStop = false;
            this.group_type.Text = "File Type";
            // 
            // radio_texture_character
            // 
            this.radio_texture_character.AutoSize = true;
            this.radio_texture_character.Location = new System.Drawing.Point(6, 47);
            this.radio_texture_character.Name = "radio_texture_character";
            this.radio_texture_character.Size = new System.Drawing.Size(117, 19);
            this.radio_texture_character.TabIndex = 1;
            this.radio_texture_character.TabStop = true;
            this.radio_texture_character.Text = "Character Texture";
            this.radio_texture_character.UseVisualStyleBackColor = true;
            this.radio_texture_character.CheckedChanged += new System.EventHandler(this.radio_texture_character_CheckedChanged);
            // 
            // radio_texture_tileset
            // 
            this.radio_texture_tileset.AutoSize = true;
            this.radio_texture_tileset.Location = new System.Drawing.Point(6, 22);
            this.radio_texture_tileset.Name = "radio_texture_tileset";
            this.radio_texture_tileset.Size = new System.Drawing.Size(100, 19);
            this.radio_texture_tileset.TabIndex = 0;
            this.radio_texture_tileset.TabStop = true;
            this.radio_texture_tileset.Text = "Tileset Texture";
            this.radio_texture_tileset.UseVisualStyleBackColor = true;
            this.radio_texture_tileset.CheckedChanged += new System.EventHandler(this.radio_texture_tileset_CheckedChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_cancel.Location = new System.Drawing.Point(282, 139);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_ok.Location = new System.Drawing.Point(201, 139);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // ImportExistingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(369, 174);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.group_type);
            this.Controls.Add(this.btn_select_file);
            this.Controls.Add(this.lbl_file);
            this.Controls.Add(this.crispPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportExistingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import existing file...";
            this.Shown += new System.EventHandler(this.ImportExistingForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.crispPictureBox1)).EndInit();
            this.group_type.ResumeLayout(false);
            this.group_type.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.Game.CrispPictureBox crispPictureBox1;
        private System.Windows.Forms.Label lbl_file;
        private System.Windows.Forms.Button btn_select_file;
        private System.Windows.Forms.GroupBox group_type;
        private System.Windows.Forms.RadioButton radio_texture_character;
        private System.Windows.Forms.RadioButton radio_texture_tileset;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}