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
            this.chk_walkout = new System.Windows.Forms.CheckBox();
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
            this.num_x.ValueChanged += new System.EventHandler(this.num_x_ValueChanged);
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
            this.num_y.ValueChanged += new System.EventHandler(this.num_y_ValueChanged);
            // 
            // chk_walkout
            // 
            this.chk_walkout.AutoSize = true;
            this.chk_walkout.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.chk_walkout.Location = new System.Drawing.Point(19, 90);
            this.chk_walkout.Name = "chk_walkout";
            this.chk_walkout.Size = new System.Drawing.Size(73, 19);
            this.chk_walkout.TabIndex = 5;
            this.chk_walkout.Text = "Walk out";
            this.chk_walkout.UseVisualStyleBackColor = true;
            this.chk_walkout.CheckedChanged += new System.EventHandler(this.chk_walkout_CheckedChanged);
            // 
            // WarpEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chk_walkout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_x);
            this.Controls.Add(this.label1);
            this.Name = "WarpEventEditor";
            this.Size = new System.Drawing.Size(214, 142);
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
        private System.Windows.Forms.CheckBox chk_walkout;
    }
}
