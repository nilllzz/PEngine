﻿namespace PEngine.Creator.Views.Projects
{
    partial class MainProjectView
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
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.projectTree = new PEngine.Creator.Components.Projects.ProjectTree();
            this.tool_project = new System.Windows.Forms.ToolStrip();
            this.tool_project_start = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).BeginInit();
            this.split_main.Panel1.SuspendLayout();
            this.split_main.Panel2.SuspendLayout();
            this.split_main.SuspendLayout();
            this.tool_project.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_main
            // 
            this.split_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split_main.Location = new System.Drawing.Point(0, 0);
            this.split_main.Name = "split_main";
            // 
            // split_main.Panel1
            // 
            this.split_main.Panel1.Controls.Add(this.projectTree);
            this.split_main.Panel1MinSize = 100;
            // 
            // split_main.Panel2
            // 
            this.split_main.Panel2.Controls.Add(this.tool_project);
            this.split_main.Panel2MinSize = 100;
            this.split_main.Size = new System.Drawing.Size(1174, 796);
            this.split_main.SplitterDistance = 300;
            this.split_main.TabIndex = 0;
            // 
            // projectTree
            // 
            this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTree.Location = new System.Drawing.Point(0, 0);
            this.projectTree.Name = "projectTree";
            this.projectTree.Size = new System.Drawing.Size(300, 796);
            this.projectTree.TabIndex = 0;
            // 
            // tool_project
            // 
            this.tool_project.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_project.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_project.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_project_start});
            this.tool_project.Location = new System.Drawing.Point(0, 0);
            this.tool_project.Name = "tool_project";
            this.tool_project.Size = new System.Drawing.Size(870, 25);
            this.tool_project.TabIndex = 0;
            this.tool_project.Text = "toolStrip1";
            // 
            // tool_project_start
            // 
            this.tool_project_start.Image = global::PEngine.Creator.Properties.Resources.arrow_run_16xLG;
            this.tool_project_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_project_start.Name = "tool_project_start";
            this.tool_project_start.Size = new System.Drawing.Size(51, 22);
            this.tool_project_start.Text = "Start";
            this.tool_project_start.Click += new System.EventHandler(this.tool_project_start_Click);
            // 
            // MainProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split_main);
            this.Name = "MainProjectView";
            this.Size = new System.Drawing.Size(1174, 796);
            this.split_main.Panel1.ResumeLayout(false);
            this.split_main.Panel2.ResumeLayout(false);
            this.split_main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).EndInit();
            this.split_main.ResumeLayout(false);
            this.tool_project.ResumeLayout(false);
            this.tool_project.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_main;
        private Components.Projects.ProjectTree projectTree;
        private System.Windows.Forms.ToolStrip tool_project;
        private System.Windows.Forms.ToolStripButton tool_project_start;
    }
}