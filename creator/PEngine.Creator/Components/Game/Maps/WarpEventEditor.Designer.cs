namespace PEngine.Creator.Components.Game.Maps
{
    partial class WarpEventEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.num_x = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.num_y = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_rot = new System.Windows.Forms.ComboBox();
            this.btn_pick_position = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_y)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target Position:";
            // 
            // num_x
            // 
            this.num_x.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.num_x.Location = new System.Drawing.Point(36, 32);
            this.num_x.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.num_x.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            -2147483648});
            this.num_x.Name = "num_x";
            this.num_x.Size = new System.Drawing.Size(38, 23);
            this.num_x.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.label3.Location = new System.Drawing.Point(16, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y";
            // 
            // num_y
            // 
            this.num_y.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.num_y.Location = new System.Drawing.Point(36, 61);
            this.num_y.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.num_y.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            -2147483648});
            this.num_y.Name = "num_y";
            this.num_y.Size = new System.Drawing.Size(38, 23);
            this.num_y.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Target Rotation:";
            // 
            // combo_rot
            // 
            this.combo_rot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_rot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_rot.FormattingEnabled = true;
            this.combo_rot.Location = new System.Drawing.Point(6, 111);
            this.combo_rot.Name = "combo_rot";
            this.combo_rot.Size = new System.Drawing.Size(205, 21);
            this.combo_rot.TabIndex = 6;
            // 
            // btn_pick_position
            // 
            this.btn_pick_position.Image = global::PEngine.Creator.Properties.Resources.Select;
            this.btn_pick_position.Location = new System.Drawing.Point(98, 8);
            this.btn_pick_position.Name = "btn_pick_position";
            this.btn_pick_position.Size = new System.Drawing.Size(23, 23);
            this.btn_pick_position.TabIndex = 7;
            this.btn_pick_position.UseVisualStyleBackColor = true;
            this.btn_pick_position.Click += new System.EventHandler(this.btn_pick_position_Click);
            // 
            // WarpEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btn_pick_position);
            this.Controls.Add(this.combo_rot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_x);
            this.Controls.Add(this.label1);
            this.Name = "WarpEventEditor";
            this.Size = new System.Drawing.Size(214, 143);
            ((System.ComponentModel.ISupportInitialize)(this.num_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_rot;
        private System.Windows.Forms.Button btn_pick_position;
    }
}
