namespace PEngine.Creator.Components.Game.Scripts
{
    partial class ScriptEditor
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
            this.txt_main = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_main
            // 
            this.txt_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_main.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_main.Location = new System.Drawing.Point(0, 0);
            this.txt_main.Multiline = true;
            this.txt_main.Name = "txt_main";
            this.txt_main.Size = new System.Drawing.Size(150, 150);
            this.txt_main.TabIndex = 0;
            this.txt_main.TextChanged += new System.EventHandler(this.txt_main_TextChanged);
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_main);
            this.Name = "ScriptEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_main;
    }
}
