namespace PEngine.Creator.Forms
{
    partial class MainForm
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
            this.panel_main = new System.Windows.Forms.Panel();
            this.status_main = new System.Windows.Forms.StatusStrip();
            this.status_label_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_openproject = new System.Windows.Forms.ToolStripMenuItem();
            this.status_main.SuspendLayout();
            this.menu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 24);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(968, 537);
            this.panel_main.TabIndex = 3;
            // 
            // status_main
            // 
            this.status_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_Highlight;
            this.status_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label_status});
            this.status_main.Location = new System.Drawing.Point(0, 561);
            this.status_main.Name = "status_main";
            this.status_main.Size = new System.Drawing.Size(968, 22);
            this.status_main.TabIndex = 1;
            this.status_main.Text = "statusStrip1";
            // 
            // status_label_status
            // 
            this.status_label_status.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.status_label_status.ForeColor = global::PEngine.Creator.Properties.Settings.Default.Color_HighlightText;
            this.status_label_status.Name = "status_label_status";
            this.status_label_status.Size = new System.Drawing.Size(54, 17);
            this.status_label_status.Text = "<status>";
            // 
            // menu_main
            // 
            this.menu_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(968, 24);
            this.menu_main.TabIndex = 2;
            this.menu_main.Text = "menuStrip1";
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file_openproject});
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(37, 20);
            this.menu_file.Text = "File";
            // 
            // menu_file_openproject
            // 
            this.menu_file_openproject.Name = "menu_file_openproject";
            this.menu_file_openproject.Size = new System.Drawing.Size(180, 22);
            this.menu_file_openproject.Text = "Open Project...";
            this.menu_file_openproject.Click += new System.EventHandler(this.menu_file_openproject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(968, 583);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.status_main);
            this.Controls.Add(this.menu_main);
            this.MainMenuStrip = this.menu_main;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.status_main.ResumeLayout(false);
            this.status_main.PerformLayout();
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip status_main;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.ToolStripStatusLabel status_label_status;
        private System.Windows.Forms.ToolStripMenuItem menu_file;
        private System.Windows.Forms.ToolStripMenuItem menu_file_openproject;
    }
}