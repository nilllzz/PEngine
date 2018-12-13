namespace PEngine.Creator.Forms
{
    partial class SelectFileForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_selected = new System.Windows.Forms.Label();
            this.tree_main = new PEngine.Creator.Components.Projects.ProjectTreeView();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_cancel.Location = new System.Drawing.Point(314, 496);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Enabled = false;
            this.btn_ok.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.btn_ok.Location = new System.Drawing.Point(233, 496);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // lbl_selected
            // 
            this.lbl_selected.AutoSize = true;
            this.lbl_selected.Location = new System.Drawing.Point(12, 501);
            this.lbl_selected.Name = "lbl_selected";
            this.lbl_selected.Size = new System.Drawing.Size(0, 13);
            this.lbl_selected.TabIndex = 3;
            // 
            // tree_main
            // 
            this.tree_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_main.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.tree_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree_main.FileTypeFilter = new PEngine.Common.Data.ProjectFileType[0];
            this.tree_main.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.tree_main.FullRowSelect = true;
            this.tree_main.HideSelection = false;
            this.tree_main.ImageIndex = 0;
            this.tree_main.Location = new System.Drawing.Point(12, 12);
            this.tree_main.Name = "tree_main";
            this.tree_main.SelectedImageIndex = 0;
            this.tree_main.ShowLines = false;
            this.tree_main.Size = new System.Drawing.Size(377, 478);
            this.tree_main.Sorted = true;
            this.tree_main.TabIndex = 0;
            this.tree_main.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_main_AfterSelect);
            this.tree_main.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_main_NodeMouseDoubleClick);
            // 
            // SelectFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(401, 531);
            this.Controls.Add(this.lbl_selected);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tree_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectFileForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select File...";
            this.Shown += new System.EventHandler(this.SelectFileForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Projects.ProjectTreeView tree_main;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_selected;
    }
}