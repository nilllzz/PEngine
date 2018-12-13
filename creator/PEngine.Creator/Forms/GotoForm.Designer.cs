namespace PEngine.Creator.Forms
{
    partial class GotoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GotoForm));
            this.txt_input = new System.Windows.Forms.TextBox();
            this.list_results = new System.Windows.Forms.ListView();
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.images_results = new System.Windows.Forms.ImageList(this.components);
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_results_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_input
            // 
            this.txt_input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_input.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.txt_input.Location = new System.Drawing.Point(12, 11);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(547, 23);
            this.txt_input.TabIndex = 0;
            this.txt_input.TextChanged += new System.EventHandler(this.txt_input_TextChanged);
            this.txt_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_input_KeyDown);
            // 
            // list_results
            // 
            this.list_results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_results.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.list_results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list_results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_name,
            this.col_type,
            this.col_path});
            this.list_results.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_results.FullRowSelect = true;
            this.list_results.HideSelection = false;
            this.list_results.Location = new System.Drawing.Point(12, 41);
            this.list_results.MultiSelect = false;
            this.list_results.Name = "list_results";
            this.list_results.Size = new System.Drawing.Size(578, 308);
            this.list_results.SmallImageList = this.images_results;
            this.list_results.TabIndex = 1;
            this.list_results.UseCompatibleStateImageBehavior = false;
            this.list_results.View = System.Windows.Forms.View.Details;
            this.list_results.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_results_KeyDown);
            // 
            // col_name
            // 
            this.col_name.Text = "Name";
            this.col_name.Width = 154;
            // 
            // col_type
            // 
            this.col_type.Text = "Type";
            // 
            // col_path
            // 
            this.col_path.Text = "File path";
            this.col_path.Width = 354;
            // 
            // images_results
            // 
            this.images_results.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images_results.ImageStream")));
            this.images_results.TransparentColor = System.Drawing.Color.Transparent;
            this.images_results.Images.SetKeyName(0, "file_generic");
            this.images_results.Images.SetKeyName(1, "file_texture");
            this.images_results.Images.SetKeyName(2, "file_tileset");
            this.images_results.Images.SetKeyName(3, "file_map");
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Image = global::PEngine.Creator.Properties.Resources.Close_16xLG;
            this.btn_close.Location = new System.Drawing.Point(563, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(27, 24);
            this.btn_close.TabIndex = 2;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_results_title
            // 
            this.lbl_results_title.AutoSize = true;
            this.lbl_results_title.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.lbl_results_title.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_results_title.Location = new System.Drawing.Point(22, 79);
            this.lbl_results_title.Name = "lbl_results_title";
            this.lbl_results_title.Size = new System.Drawing.Size(130, 15);
            this.lbl_results_title.TabIndex = 3;
            this.lbl_results_title.Text = "Start typing to find files";
            // 
            // GotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.ClientSize = new System.Drawing.Size(602, 361);
            this.Controls.Add(this.lbl_results_title);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.list_results);
            this.Controls.Add(this.txt_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GotoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GotoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.ListView list_results;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_results_title;
        private System.Windows.Forms.ImageList images_results;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_type;
        private System.Windows.Forms.ColumnHeader col_path;
    }
}