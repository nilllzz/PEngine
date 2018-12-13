namespace PEngine.Creator.Components.Projects
{
    partial class ProjectTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTreeView));
            this.tree_images = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tree_images
            // 
            this.tree_images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tree_images.ImageStream")));
            this.tree_images.TransparentColor = System.Drawing.Color.Transparent;
            this.tree_images.Images.SetKeyName(0, "file_generic");
            this.tree_images.Images.SetKeyName(1, "folder_closed");
            this.tree_images.Images.SetKeyName(2, "folder_open");
            this.tree_images.Images.SetKeyName(3, "file_map");
            this.tree_images.Images.SetKeyName(4, "file_image");
            this.tree_images.Images.SetKeyName(5, "file_tileset");
            this.tree_images.Images.SetKeyName(6, "project_closed");
            this.tree_images.Images.SetKeyName(7, "project_open");
            // 
            // ProjectTreeView
            // 
            this.ImageIndex = 0;
            this.ImageList = this.tree_images;
            this.SelectedImageIndex = 0;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList tree_images;
    }
}
