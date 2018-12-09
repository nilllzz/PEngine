namespace PEngine.Creator.Components.Projects
{
    partial class ProjectLoadButton
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
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_title = new System.Windows.Forms.Label();
            this.context_main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_main_open = new System.Windows.Forms.ToolStripMenuItem();
            this.context_main_reveal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.context_main_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.btn = new System.Windows.Forms.Button();
            this.context_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.lbl_title.ContextMenuStrip = this.context_main;
            this.lbl_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_title.Location = new System.Drawing.Point(0, 47);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(124, 34);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "<Project>";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // context_main
            // 
            this.context_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_main_open,
            this.context_main_reveal,
            this.toolStripSeparator1,
            this.context_main_remove});
            this.context_main.Name = "context_main";
            this.context_main.Size = new System.Drawing.Size(170, 76);
            // 
            // context_main_open
            // 
            this.context_main_open.Name = "context_main_open";
            this.context_main_open.Size = new System.Drawing.Size(169, 22);
            this.context_main_open.Text = "Open";
            this.context_main_open.Click += new System.EventHandler(this.context_main_open_Click);
            // 
            // context_main_reveal
            // 
            this.context_main_reveal.Image = global::PEngine.Creator.Properties.Resources.folder_Open_16xLG;
            this.context_main_reveal.Name = "context_main_reveal";
            this.context_main_reveal.Size = new System.Drawing.Size(169, 22);
            this.context_main_reveal.Text = "Reveal in Explorer";
            this.context_main_reveal.Click += new System.EventHandler(this.context_main_reveal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // context_main_remove
            // 
            this.context_main_remove.Image = global::PEngine.Creator.Properties.Resources.Clearwindowcontent_6304;
            this.context_main_remove.Name = "context_main_remove";
            this.context_main_remove.Size = new System.Drawing.Size(169, 22);
            this.context_main_remove.Text = "Remove From List";
            this.context_main_remove.Click += new System.EventHandler(this.context_main_remove_Click);
            // 
            // btn
            // 
            this.btn.ContextMenuStrip = this.context_main;
            this.btn.Image = global::PEngine.Creator.Properties.Resources.Folder_special__5843_32x;
            this.btn.Location = new System.Drawing.Point(0, 0);
            this.btn.Margin = new System.Windows.Forms.Padding(0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(124, 47);
            this.btn.TabIndex = 0;
            this.btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // ProjectLoadButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn);
            this.Name = "ProjectLoadButton";
            this.Size = new System.Drawing.Size(124, 81);
            this.context_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ToolTip tooltip_main;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.ContextMenuStrip context_main;
        private System.Windows.Forms.ToolStripMenuItem context_main_open;
        private System.Windows.Forms.ToolStripMenuItem context_main_reveal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem context_main_remove;
    }
}
