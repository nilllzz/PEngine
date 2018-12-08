namespace PEngine.Creator.Components.Game
{
    partial class SubtileEditComponent
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
            this.combo_behavior = new System.Windows.Forms.ComboBox();
            this.pic_pick_texture = new System.Windows.Forms.PictureBox();
            this.pic_texture = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.tooltip_main = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_pick_texture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_behavior
            // 
            this.combo_behavior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_behavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_behavior.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.combo_behavior.FormattingEnabled = true;
            this.combo_behavior.Location = new System.Drawing.Point(52, 5);
            this.combo_behavior.Name = "combo_behavior";
            this.combo_behavior.Size = new System.Drawing.Size(132, 23);
            this.combo_behavior.TabIndex = 1;
            this.combo_behavior.SelectedIndexChanged += new System.EventHandler(this.combo_behavior_SelectedIndexChanged);
            // 
            // pic_pick_texture
            // 
            this.pic_pick_texture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_pick_texture.Image = global::PEngine.Creator.Properties.Resources.ColorSelectionTool_202;
            this.pic_pick_texture.Location = new System.Drawing.Point(32, 16);
            this.pic_pick_texture.Name = "pic_pick_texture";
            this.pic_pick_texture.Size = new System.Drawing.Size(16, 16);
            this.pic_pick_texture.TabIndex = 3;
            this.pic_pick_texture.TabStop = false;
            this.tooltip_main.SetToolTip(this.pic_pick_texture, "Pick Texture");
            this.pic_pick_texture.Click += new System.EventHandler(this.pic_pick_texture_Click);
            // 
            // pic_texture
            // 
            this.pic_texture.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pic_texture.Location = new System.Drawing.Point(0, 0);
            this.pic_texture.Name = "pic_texture";
            this.pic_texture.Size = new System.Drawing.Size(32, 32);
            this.pic_texture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_texture.TabIndex = 0;
            this.pic_texture.TabStop = false;
            // 
            // SubtileEditComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pic_pick_texture);
            this.Controls.Add(this.combo_behavior);
            this.Controls.Add(this.pic_texture);
            this.Name = "SubtileEditComponent";
            this.Size = new System.Drawing.Size(187, 34);
            ((System.ComponentModel.ISupportInitialize)(this.pic_pick_texture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_texture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrispPictureBox pic_texture;
        private System.Windows.Forms.ComboBox combo_behavior;
        private System.Windows.Forms.PictureBox pic_pick_texture;
        private System.Windows.Forms.ToolTip tooltip_main;
    }
}
