namespace PEngine.Creator.Components.Game.Maps
{
    partial class MapEditorEvents
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.chk_warp = new System.Windows.Forms.RadioButton();
            this.chk_script = new System.Windows.Forms.RadioButton();
            this.group_selected_event = new System.Windows.Forms.GroupBox();
            this.group_event_props = new System.Windows.Forms.GroupBox();
            this.btn_event_target_open = new System.Windows.Forms.Button();
            this.btn_event_target_select = new System.Windows.Forms.Button();
            this.txt_event_target = new System.Windows.Forms.TextBox();
            this.lbl_selected_event_target_title = new System.Windows.Forms.Label();
            this.lbl_event_name = new System.Windows.Forms.Label();
            this.pic_event_type = new System.Windows.Forms.PictureBox();
            this.combo_select_event = new System.Windows.Forms.ComboBox();
            this.group_selected_event.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_event_type)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_title.Location = new System.Drawing.Point(16, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(57, 15);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Add new:";
            // 
            // chk_warp
            // 
            this.chk_warp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_warp.Checked = true;
            this.chk_warp.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.chk_warp.Image = global::PEngine.Creator.Properties.Resources.eventWarp;
            this.chk_warp.Location = new System.Drawing.Point(19, 35);
            this.chk_warp.Name = "chk_warp";
            this.chk_warp.Size = new System.Drawing.Size(78, 24);
            this.chk_warp.TabIndex = 1;
            this.chk_warp.TabStop = true;
            this.chk_warp.Text = "Warp";
            this.chk_warp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chk_warp.UseVisualStyleBackColor = true;
            this.chk_warp.CheckedChanged += new System.EventHandler(this.chk_warp_CheckedChanged);
            // 
            // chk_script
            // 
            this.chk_script.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_script.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.chk_script.Image = global::PEngine.Creator.Properties.Resources.eventScript;
            this.chk_script.Location = new System.Drawing.Point(103, 35);
            this.chk_script.Name = "chk_script";
            this.chk_script.Size = new System.Drawing.Size(78, 24);
            this.chk_script.TabIndex = 2;
            this.chk_script.Text = "Script";
            this.chk_script.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chk_script.UseVisualStyleBackColor = true;
            this.chk_script.CheckedChanged += new System.EventHandler(this.chk_script_CheckedChanged);
            // 
            // group_selected_event
            // 
            this.group_selected_event.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_selected_event.Controls.Add(this.group_event_props);
            this.group_selected_event.Controls.Add(this.btn_event_target_open);
            this.group_selected_event.Controls.Add(this.btn_event_target_select);
            this.group_selected_event.Controls.Add(this.txt_event_target);
            this.group_selected_event.Controls.Add(this.lbl_selected_event_target_title);
            this.group_selected_event.Controls.Add(this.lbl_event_name);
            this.group_selected_event.Controls.Add(this.pic_event_type);
            this.group_selected_event.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.group_selected_event.Location = new System.Drawing.Point(19, 119);
            this.group_selected_event.Name = "group_selected_event";
            this.group_selected_event.Size = new System.Drawing.Size(281, 270);
            this.group_selected_event.TabIndex = 3;
            this.group_selected_event.TabStop = false;
            this.group_selected_event.Text = "Selected Event";
            // 
            // group_event_props
            // 
            this.group_event_props.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_event_props.Location = new System.Drawing.Point(13, 136);
            this.group_event_props.Name = "group_event_props";
            this.group_event_props.Size = new System.Drawing.Size(254, 128);
            this.group_event_props.TabIndex = 6;
            this.group_event_props.TabStop = false;
            this.group_event_props.Text = "Event Properties";
            // 
            // btn_event_target_open
            // 
            this.btn_event_target_open.Enabled = false;
            this.btn_event_target_open.Location = new System.Drawing.Point(94, 107);
            this.btn_event_target_open.Name = "btn_event_target_open";
            this.btn_event_target_open.Size = new System.Drawing.Size(75, 23);
            this.btn_event_target_open.TabIndex = 5;
            this.btn_event_target_open.Text = "View";
            this.btn_event_target_open.UseVisualStyleBackColor = true;
            this.btn_event_target_open.Click += new System.EventHandler(this.btn_event_target_open_Click);
            // 
            // btn_event_target_select
            // 
            this.btn_event_target_select.Enabled = false;
            this.btn_event_target_select.Location = new System.Drawing.Point(13, 107);
            this.btn_event_target_select.Name = "btn_event_target_select";
            this.btn_event_target_select.Size = new System.Drawing.Size(75, 23);
            this.btn_event_target_select.TabIndex = 4;
            this.btn_event_target_select.Text = "Select...";
            this.btn_event_target_select.UseVisualStyleBackColor = true;
            this.btn_event_target_select.Click += new System.EventHandler(this.btn_event_target_select_Click);
            // 
            // txt_event_target
            // 
            this.txt_event_target.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_event_target.Location = new System.Drawing.Point(13, 77);
            this.txt_event_target.Name = "txt_event_target";
            this.txt_event_target.ReadOnly = true;
            this.txt_event_target.Size = new System.Drawing.Size(254, 23);
            this.txt_event_target.TabIndex = 3;
            // 
            // lbl_selected_event_target_title
            // 
            this.lbl_selected_event_target_title.AutoSize = true;
            this.lbl_selected_event_target_title.Location = new System.Drawing.Point(10, 59);
            this.lbl_selected_event_target_title.Name = "lbl_selected_event_target_title";
            this.lbl_selected_event_target_title.Size = new System.Drawing.Size(43, 15);
            this.lbl_selected_event_target_title.TabIndex = 2;
            this.lbl_selected_event_target_title.Text = "Target:";
            // 
            // lbl_event_name
            // 
            this.lbl_event_name.AutoSize = true;
            this.lbl_event_name.Location = new System.Drawing.Point(41, 30);
            this.lbl_event_name.Name = "lbl_event_name";
            this.lbl_event_name.Size = new System.Drawing.Size(117, 15);
            this.lbl_event_name.TabIndex = 1;
            this.lbl_event_name.Text = "<No event selected>";
            // 
            // pic_event_type
            // 
            this.pic_event_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_event_type.Location = new System.Drawing.Point(13, 28);
            this.pic_event_type.Name = "pic_event_type";
            this.pic_event_type.Size = new System.Drawing.Size(20, 20);
            this.pic_event_type.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_event_type.TabIndex = 0;
            this.pic_event_type.TabStop = false;
            // 
            // combo_select_event
            // 
            this.combo_select_event.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_select_event.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_select_event.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.combo_select_event.FormattingEnabled = true;
            this.combo_select_event.Location = new System.Drawing.Point(19, 92);
            this.combo_select_event.Name = "combo_select_event";
            this.combo_select_event.Size = new System.Drawing.Size(281, 23);
            this.combo_select_event.TabIndex = 4;
            this.combo_select_event.SelectedIndexChanged += new System.EventHandler(this.combo_select_event_SelectedIndexChanged);
            // 
            // MapEditorEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.Controls.Add(this.combo_select_event);
            this.Controls.Add(this.group_selected_event);
            this.Controls.Add(this.chk_script);
            this.Controls.Add(this.chk_warp);
            this.Controls.Add(this.lbl_title);
            this.Name = "MapEditorEvents";
            this.Size = new System.Drawing.Size(318, 397);
            this.group_selected_event.ResumeLayout(false);
            this.group_selected_event.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_event_type)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.RadioButton chk_warp;
        private System.Windows.Forms.RadioButton chk_script;
        private System.Windows.Forms.GroupBox group_selected_event;
        private System.Windows.Forms.Label lbl_event_name;
        private System.Windows.Forms.PictureBox pic_event_type;
        private System.Windows.Forms.ComboBox combo_select_event;
        private System.Windows.Forms.Button btn_event_target_open;
        private System.Windows.Forms.Button btn_event_target_select;
        private System.Windows.Forms.TextBox txt_event_target;
        private System.Windows.Forms.Label lbl_selected_event_target_title;
        private System.Windows.Forms.GroupBox group_event_props;
    }
}
