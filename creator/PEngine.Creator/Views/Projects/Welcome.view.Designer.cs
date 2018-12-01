namespace PEngine.Creator.Views.Projects
{
    partial class WelcomeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeView));
            this.heading_main = new PEngine.Creator.Components.Text.Heading(this.components);
            this.heading_sub = new PEngine.Creator.Components.Text.Heading(this.components);
            this.col_main = new PEngine.Creator.Components.Layout.Column(this.components);
            this.row1 = new PEngine.Creator.Components.Layout.Row(this.components);
            this.logo1 = new PEngine.Creator.Components.Logo.Logo(this.components);
            this.btn_create = new System.Windows.Forms.Button();
            this.col_main.SuspendLayout();
            this.row1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo1)).BeginInit();
            this.SuspendLayout();
            // 
            // heading_main
            // 
            this.heading_main.AutoSize = true;
            this.heading_main.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.heading_main.Level = 1;
            this.heading_main.Location = new System.Drawing.Point(41, 0);
            this.heading_main.Name = "heading_main";
            this.heading_main.Size = new System.Drawing.Size(324, 45);
            this.heading_main.TabIndex = 0;
            this.heading_main.Text = "Welcome to PEngine!";
            // 
            // heading_sub
            // 
            this.heading_sub.AutoSize = true;
            this.heading_sub.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.heading_sub.Level = 3;
            this.heading_sub.Location = new System.Drawing.Point(3, 51);
            this.heading_sub.Name = "heading_sub";
            this.heading_sub.Size = new System.Drawing.Size(673, 30);
            this.heading_sub.TabIndex = 1;
            this.heading_sub.Text = "Create a new project or load an existing one from the options below";
            // 
            // col_main
            // 
            this.col_main.AutoSize = true;
            this.col_main.Controls.Add(this.row1);
            this.col_main.Controls.Add(this.heading_sub);
            this.col_main.Controls.Add(this.btn_create);
            this.col_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.col_main.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.col_main.Location = new System.Drawing.Point(0, 0);
            this.col_main.MinimumSize = new System.Drawing.Size(32, 32);
            this.col_main.Name = "col_main";
            this.col_main.Size = new System.Drawing.Size(1182, 879);
            this.col_main.TabIndex = 2;
            // 
            // row1
            // 
            this.row1.AutoSize = true;
            this.row1.Controls.Add(this.logo1);
            this.row1.Controls.Add(this.heading_main);
            this.row1.Dock = System.Windows.Forms.DockStyle.Top;
            this.row1.Location = new System.Drawing.Point(3, 3);
            this.row1.MinimumSize = new System.Drawing.Size(32, 32);
            this.row1.Name = "row1";
            this.row1.Size = new System.Drawing.Size(673, 45);
            this.row1.TabIndex = 2;
            // 
            // logo1
            // 
            this.logo1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logo1.Image = ((System.Drawing.Image)(resources.GetObject("logo1.Image")));
            this.logo1.Location = new System.Drawing.Point(3, 6);
            this.logo1.Name = "logo1";
            this.logo1.Size = new System.Drawing.Size(32, 32);
            this.logo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo1.TabIndex = 1;
            this.logo1.TabStop = false;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(3, 84);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(144, 23);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "Create new project";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // WelcomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.col_main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WelcomeView";
            this.Size = new System.Drawing.Size(1182, 879);
            this.col_main.ResumeLayout(false);
            this.col_main.PerformLayout();
            this.row1.ResumeLayout(false);
            this.row1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Text.Heading heading_main;
        private Components.Text.Heading heading_sub;
        private Components.Layout.Column col_main;
        private Components.Layout.Row row1;
        private Components.Logo.Logo logo1;
        private System.Windows.Forms.Button btn_create;
    }
}
