namespace PEngine.Creator.Views.Projects
{
    partial class NewProjectView
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_author = new System.Windows.Forms.Label();
            this.txt_author = new System.Windows.Forms.TextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.crispPictureBox1 = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.panel_divider = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.group_main = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_dest_folder = new System.Windows.Forms.TextBox();
            this.btn_select_dest_folder = new System.Windows.Forms.Button();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.crispPictureBox1)).BeginInit();
            this.group_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_name.Location = new System.Drawing.Point(16, 37);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(42, 15);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // txt_name
            // 
            this.txt_name.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.txt_name.Location = new System.Drawing.Point(69, 34);
            this.txt_name.MaxLength = 20;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(295, 23);
            this.txt_name.TabIndex = 1;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_author.Location = new System.Drawing.Point(16, 78);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(47, 15);
            this.lbl_author.TabIndex = 0;
            this.lbl_author.Text = "Author:";
            // 
            // txt_author
            // 
            this.txt_author.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.txt_author.Location = new System.Drawing.Point(69, 75);
            this.txt_author.MaxLength = 20;
            this.txt_author.Name = "txt_author";
            this.txt_author.Size = new System.Drawing.Size(295, 23);
            this.txt_author.TabIndex = 1;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confirm.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_confirm.Location = new System.Drawing.Point(928, 272);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 5;
            this.btn_confirm.Text = "Create";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // crispPictureBox1
            // 
            this.crispPictureBox1.Image = global::PEngine.Creator.Properties.Resources.Folder_special__5843_32x;
            this.crispPictureBox1.Location = new System.Drawing.Point(9, 15);
            this.crispPictureBox1.Name = "crispPictureBox1";
            this.crispPictureBox1.Size = new System.Drawing.Size(64, 64);
            this.crispPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.crispPictureBox1.TabIndex = 7;
            this.crispPictureBox1.TabStop = false;
            // 
            // panel_divider
            // 
            this.panel_divider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_divider.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_Highlight;
            this.panel_divider.Location = new System.Drawing.Point(84, 78);
            this.panel_divider.Name = "panel_divider";
            this.panel_divider.Size = new System.Drawing.Size(1000, 2);
            this.panel_divider.TabIndex = 9;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_H1;
            this.lbl_title.Location = new System.Drawing.Point(76, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(288, 45);
            this.lbl_title.TabIndex = 8;
            this.lbl_title.Text = "Create new project";
            // 
            // group_main
            // 
            this.group_main.Controls.Add(this.lbl_name);
            this.group_main.Controls.Add(this.txt_name);
            this.group_main.Controls.Add(this.lbl_author);
            this.group_main.Controls.Add(this.txt_author);
            this.group_main.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.group_main.Location = new System.Drawing.Point(84, 101);
            this.group_main.Name = "group_main";
            this.group_main.Size = new System.Drawing.Size(384, 122);
            this.group_main.TabIndex = 10;
            this.group_main.TabStop = false;
            this.group_main.Text = "Properties";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_Highlight;
            this.panel1.Location = new System.Drawing.Point(84, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 2);
            this.panel1.TabIndex = 10;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_cancel.Location = new System.Drawing.Point(1009, 272);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_dest_folder
            // 
            this.txt_dest_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dest_folder.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.txt_dest_folder.Location = new System.Drawing.Point(84, 272);
            this.txt_dest_folder.Name = "txt_dest_folder";
            this.txt_dest_folder.Size = new System.Drawing.Size(774, 23);
            this.txt_dest_folder.TabIndex = 12;
            // 
            // btn_select_dest_folder
            // 
            this.btn_select_dest_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_dest_folder.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_select_dest_folder.Location = new System.Drawing.Point(864, 272);
            this.btn_select_dest_folder.Name = "btn_select_dest_folder";
            this.btn_select_dest_folder.Size = new System.Drawing.Size(28, 24);
            this.btn_select_dest_folder.TabIndex = 13;
            this.btn_select_dest_folder.Text = "...";
            this.tooltip_main.SetToolTip(this.btn_select_dest_folder, "Select Project Directory");
            this.btn_select_dest_folder.UseVisualStyleBackColor = true;
            this.btn_select_dest_folder.Click += new System.EventHandler(this.btn_select_dest_folder_Click);
            // 
            // NewProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_select_dest_folder);
            this.Controls.Add(this.txt_dest_folder);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.group_main);
            this.Controls.Add(this.panel_divider);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.crispPictureBox1);
            this.Controls.Add(this.btn_confirm);
            this.Name = "NewProjectView";
            this.Size = new System.Drawing.Size(1158, 796);
            ((System.ComponentModel.ISupportInitialize)(this.crispPictureBox1)).EndInit();
            this.group_main.ResumeLayout(false);
            this.group_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.TextBox txt_author;
        private System.Windows.Forms.Button btn_confirm;
        private Components.Game.CrispPictureBox crispPictureBox1;
        private System.Windows.Forms.Panel panel_divider;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox group_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_dest_folder;
        private System.Windows.Forms.Button btn_select_dest_folder;
        private System.Windows.Forms.ToolTip tooltip_main;
    }
}
