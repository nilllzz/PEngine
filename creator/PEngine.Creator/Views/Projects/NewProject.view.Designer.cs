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
            this.column1 = new PEngine.Creator.Components.Layout.Column(this.components);
            this.heading_main = new PEngine.Creator.Components.Text.Heading(this.components);
            this.panel_spacer1 = new System.Windows.Forms.Panel();
            this.row1 = new PEngine.Creator.Components.Layout.Row(this.components);
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.row2 = new PEngine.Creator.Components.Layout.Row(this.components);
            this.lbl_author = new System.Windows.Forms.Label();
            this.txt_author = new System.Windows.Forms.TextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.column1.SuspendLayout();
            this.row1.SuspendLayout();
            this.row2.SuspendLayout();
            this.SuspendLayout();
            // 
            // column1
            // 
            this.column1.AutoSize = true;
            this.column1.Controls.Add(this.heading_main);
            this.column1.Controls.Add(this.panel_spacer1);
            this.column1.Controls.Add(this.row1);
            this.column1.Controls.Add(this.row2);
            this.column1.Controls.Add(this.btn_confirm);
            this.column1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.column1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.column1.Location = new System.Drawing.Point(0, 0);
            this.column1.MinimumSize = new System.Drawing.Size(32, 32);
            this.column1.Name = "column1";
            this.column1.Size = new System.Drawing.Size(1182, 879);
            this.column1.TabIndex = 0;
            // 
            // heading_main
            // 
            this.heading_main.AutoSize = true;
            this.heading_main.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.heading_main.Level = 1;
            this.heading_main.Location = new System.Drawing.Point(3, 0);
            this.heading_main.Name = "heading_main";
            this.heading_main.Size = new System.Drawing.Size(288, 45);
            this.heading_main.TabIndex = 0;
            this.heading_main.Text = "Create new project";
            // 
            // panel_spacer1
            // 
            this.panel_spacer1.Location = new System.Drawing.Point(3, 48);
            this.panel_spacer1.Name = "panel_spacer1";
            this.panel_spacer1.Size = new System.Drawing.Size(200, 24);
            this.panel_spacer1.TabIndex = 1;
            // 
            // row1
            // 
            this.row1.AutoSize = true;
            this.row1.Controls.Add(this.lbl_name);
            this.row1.Controls.Add(this.txt_name);
            this.row1.Dock = System.Windows.Forms.DockStyle.Top;
            this.row1.Location = new System.Drawing.Point(3, 78);
            this.row1.MinimumSize = new System.Drawing.Size(32, 32);
            this.row1.Name = "row1";
            this.row1.Size = new System.Drawing.Size(361, 32);
            this.row1.TabIndex = 2;
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(3, 6);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // txt_name
            // 
            this.txt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_name.Location = new System.Drawing.Point(47, 3);
            this.txt_name.MaxLength = 20;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(311, 20);
            this.txt_name.TabIndex = 1;
            // 
            // row2
            // 
            this.row2.AutoSize = true;
            this.row2.Controls.Add(this.lbl_author);
            this.row2.Controls.Add(this.txt_author);
            this.row2.Dock = System.Windows.Forms.DockStyle.Top;
            this.row2.Location = new System.Drawing.Point(3, 116);
            this.row2.MinimumSize = new System.Drawing.Size(32, 32);
            this.row2.Name = "row2";
            this.row2.Size = new System.Drawing.Size(361, 32);
            this.row2.TabIndex = 4;
            // 
            // lbl_author
            // 
            this.lbl_author.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(3, 6);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_author.TabIndex = 0;
            this.lbl_author.Text = "Author:";
            // 
            // txt_author
            // 
            this.txt_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_author.Location = new System.Drawing.Point(50, 3);
            this.txt_author.MaxLength = 20;
            this.txt_author.Name = "txt_author";
            this.txt_author.Size = new System.Drawing.Size(308, 20);
            this.txt_author.TabIndex = 1;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(3, 154);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 5;
            this.btn_confirm.Text = "Create";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // NewProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.column1);
            this.Name = "NewProjectView";
            this.Size = new System.Drawing.Size(1182, 879);
            this.column1.ResumeLayout(false);
            this.column1.PerformLayout();
            this.row1.ResumeLayout(false);
            this.row1.PerformLayout();
            this.row2.ResumeLayout(false);
            this.row2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Layout.Column column1;
        private Components.Text.Heading heading_main;
        private System.Windows.Forms.Panel panel_spacer1;
        private Components.Layout.Row row1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private Components.Layout.Row row2;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.TextBox txt_author;
        private System.Windows.Forms.Button btn_confirm;
    }
}
