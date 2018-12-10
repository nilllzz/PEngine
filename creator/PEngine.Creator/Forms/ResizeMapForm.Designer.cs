namespace PEngine.Creator.Forms
{
    partial class ResizeMapForm
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.num_left = new System.Windows.Forms.NumericUpDown();
            this.num_right = new System.Windows.Forms.NumericUpDown();
            this.num_down = new System.Windows.Forms.NumericUpDown();
            this.num_up = new System.Windows.Forms.NumericUpDown();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_up)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(183, 15);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Resize the map in the map editor.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(122, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 80);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.panel2.Controls.Add(this.num_up);
            this.panel2.Controls.Add(this.num_down);
            this.panel2.Controls.Add(this.num_right);
            this.panel2.Controls.Add(this.num_left);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 326);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(52)))));
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(78, 78);
            this.panel3.TabIndex = 3;
            // 
            // num_left
            // 
            this.num_left.Location = new System.Drawing.Point(41, 154);
            this.num_left.Name = "num_left";
            this.num_left.Size = new System.Drawing.Size(75, 23);
            this.num_left.TabIndex = 3;
            // 
            // num_right
            // 
            this.num_right.Location = new System.Drawing.Point(208, 154);
            this.num_right.Name = "num_right";
            this.num_right.Size = new System.Drawing.Size(75, 23);
            this.num_right.TabIndex = 4;
            // 
            // num_down
            // 
            this.num_down.Location = new System.Drawing.Point(124, 209);
            this.num_down.Name = "num_down";
            this.num_down.Size = new System.Drawing.Size(75, 23);
            this.num_down.TabIndex = 5;
            // 
            // num_up
            // 
            this.num_up.Location = new System.Drawing.Point(124, 95);
            this.num_up.Name = "num_up";
            this.num_up.Size = new System.Drawing.Size(75, 23);
            this.num_up.TabIndex = 6;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(263, 371);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(182, 371);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ResizeMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(350, 403);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbl_title);
            this.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResizeMapForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResizeMapForm";
            this.Load += new System.EventHandler(this.ResizeMapForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_up)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown num_up;
        private System.Windows.Forms.NumericUpDown num_down;
        private System.Windows.Forms.NumericUpDown num_right;
        private System.Windows.Forms.NumericUpDown num_left;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}