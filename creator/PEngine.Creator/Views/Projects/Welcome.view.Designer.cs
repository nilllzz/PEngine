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
            this.btn_create = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel_divider = new System.Windows.Forms.Panel();
            this.group_recent = new System.Windows.Forms.GroupBox();
            this.panel_recent_container = new System.Windows.Forms.FlowLayoutPanel();
            this.logo1 = new PEngine.Creator.Components.Logo.Logo(this.components);
            this.group_recent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_create.Image = global::PEngine.Creator.Properties.Resources.NewBuildDefinition_8952;
            this.btn_create.Location = new System.Drawing.Point(81, 104);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(111, 41);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "Create new project";
            this.btn_create.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_H1;
            this.lbl_title.Location = new System.Drawing.Point(73, 22);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(429, 45);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "Welcome to PEngine Creator";
            // 
            // panel_divider
            // 
            this.panel_divider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_divider.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_Highlight;
            this.panel_divider.Location = new System.Drawing.Point(81, 85);
            this.panel_divider.Name = "panel_divider";
            this.panel_divider.Size = new System.Drawing.Size(1000, 2);
            this.panel_divider.TabIndex = 5;
            // 
            // group_recent
            // 
            this.group_recent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_recent.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.group_recent.Controls.Add(this.panel_recent_container);
            this.group_recent.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.group_recent.Location = new System.Drawing.Point(81, 166);
            this.group_recent.Name = "group_recent";
            this.group_recent.Size = new System.Drawing.Size(1000, 685);
            this.group_recent.TabIndex = 6;
            this.group_recent.TabStop = false;
            this.group_recent.Text = "Recent Projects";
            // 
            // panel_recent_container
            // 
            this.panel_recent_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_recent_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_recent_container.Location = new System.Drawing.Point(3, 19);
            this.panel_recent_container.Name = "panel_recent_container";
            this.panel_recent_container.Size = new System.Drawing.Size(994, 663);
            this.panel_recent_container.TabIndex = 0;
            // 
            // logo1
            // 
            this.logo1.Image = ((System.Drawing.Image)(resources.GetObject("logo1.Image")));
            this.logo1.Location = new System.Drawing.Point(9, 15);
            this.logo1.Name = "logo1";
            this.logo1.Size = new System.Drawing.Size(64, 64);
            this.logo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo1.TabIndex = 7;
            this.logo1.TabStop = false;
            // 
            // WelcomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logo1);
            this.Controls.Add(this.group_recent);
            this.Controls.Add(this.panel_divider);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_create);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WelcomeView";
            this.Size = new System.Drawing.Size(1158, 879);
            this.group_recent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel_divider;
        private System.Windows.Forms.GroupBox group_recent;
        private System.Windows.Forms.FlowLayoutPanel panel_recent_container;
        private Components.Logo.Logo logo1;
    }
}
