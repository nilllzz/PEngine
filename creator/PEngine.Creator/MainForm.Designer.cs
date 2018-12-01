namespace PEngine.Creator
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
            this.menu_main = new System.Windows.Forms.MenuStrip();
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
            this.status_main.Location = new System.Drawing.Point(0, 561);
            this.status_main.Name = "status_main";
            this.status_main.Size = new System.Drawing.Size(968, 22);
            this.status_main.TabIndex = 1;
            this.status_main.Text = "statusStrip1";
            // 
            // menu_main
            // 
            this.menu_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.Size = new System.Drawing.Size(968, 24);
            this.menu_main.TabIndex = 2;
            this.menu_main.Text = "menuStrip1";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip status_main;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.Panel panel_main;
    }
}