namespace PEngine.Creator.Components.Game.Monsters
{
    partial class MonsterEditor
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
            this.btn_switch_view = new System.Windows.Forms.Button();
            this.toolTip_main = new System.Windows.Forms.ToolTip(this.components);
            this.tabs_main = new System.Windows.Forms.TabControl();
            this.tab_info = new System.Windows.Forms.TabPage();
            this.panel_info = new System.Windows.Forms.Panel();
            this.group_types = new System.Windows.Forms.GroupBox();
            this.lbl_type2 = new System.Windows.Forms.Label();
            this.enum_type2 = new PEngine.Creator.Components.Fieldset.EnumField();
            this.lbl_type1 = new System.Windows.Forms.Label();
            this.enum_type1 = new PEngine.Creator.Components.Fieldset.EnumField();
            this.lbl_gender_expl = new System.Windows.Forms.Label();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.enum_gender = new PEngine.Creator.Components.Fieldset.EnumField();
            this.num_number = new PEngine.Creator.Components.Fieldset.IntField();
            this.txt_name = new PEngine.Creator.Components.Fieldset.TextField();
            this.lbl_number_edit = new System.Windows.Forms.Label();
            this.lbl_name_edit = new System.Windows.Forms.Label();
            this.tab_dex = new System.Windows.Forms.TabPage();
            this.tab_texture = new System.Windows.Forms.TabPage();
            this.tab_moves = new System.Windows.Forms.TabPage();
            this.lbl_number = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.pic_monster = new PEngine.Creator.Components.Game.CrispPictureBox();
            this.tabs_main.SuspendLayout();
            this.tab_info.SuspendLayout();
            this.panel_info.SuspendLayout();
            this.group_types.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_monster)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_switch_view
            // 
            this.btn_switch_view.Image = global::PEngine.Creator.Properties.Resources.arrow_Sync_16xLG;
            this.btn_switch_view.Location = new System.Drawing.Point(121, 92);
            this.btn_switch_view.Name = "btn_switch_view";
            this.btn_switch_view.Size = new System.Drawing.Size(23, 23);
            this.btn_switch_view.TabIndex = 2;
            this.toolTip_main.SetToolTip(this.btn_switch_view, "Switch View");
            this.btn_switch_view.UseVisualStyleBackColor = true;
            this.btn_switch_view.Click += new System.EventHandler(this.btn_switch_view_Click);
            // 
            // tabs_main
            // 
            this.tabs_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs_main.Controls.Add(this.tab_info);
            this.tabs_main.Controls.Add(this.tab_dex);
            this.tabs_main.Controls.Add(this.tab_texture);
            this.tabs_main.Controls.Add(this.tab_moves);
            this.tabs_main.Location = new System.Drawing.Point(3, 121);
            this.tabs_main.Name = "tabs_main";
            this.tabs_main.SelectedIndex = 0;
            this.tabs_main.Size = new System.Drawing.Size(718, 427);
            this.tabs_main.TabIndex = 4;
            // 
            // tab_info
            // 
            this.tab_info.Controls.Add(this.panel_info);
            this.tab_info.Location = new System.Drawing.Point(4, 22);
            this.tab_info.Name = "tab_info";
            this.tab_info.Padding = new System.Windows.Forms.Padding(3);
            this.tab_info.Size = new System.Drawing.Size(710, 401);
            this.tab_info.TabIndex = 0;
            this.tab_info.Text = "Info";
            this.tab_info.UseVisualStyleBackColor = true;
            // 
            // panel_info
            // 
            this.panel_info.AutoScroll = true;
            this.panel_info.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.panel_info.Controls.Add(this.group_types);
            this.panel_info.Controls.Add(this.lbl_gender_expl);
            this.panel_info.Controls.Add(this.lbl_gender);
            this.panel_info.Controls.Add(this.enum_gender);
            this.panel_info.Controls.Add(this.num_number);
            this.panel_info.Controls.Add(this.txt_name);
            this.panel_info.Controls.Add(this.lbl_number_edit);
            this.panel_info.Controls.Add(this.lbl_name_edit);
            this.panel_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_info.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.panel_info.Location = new System.Drawing.Point(3, 3);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(704, 395);
            this.panel_info.TabIndex = 0;
            // 
            // group_types
            // 
            this.group_types.Controls.Add(this.lbl_type2);
            this.group_types.Controls.Add(this.enum_type2);
            this.group_types.Controls.Add(this.lbl_type1);
            this.group_types.Controls.Add(this.enum_type1);
            this.group_types.Location = new System.Drawing.Point(6, 100);
            this.group_types.Name = "group_types";
            this.group_types.Size = new System.Drawing.Size(200, 100);
            this.group_types.TabIndex = 8;
            this.group_types.TabStop = false;
            this.group_types.Text = "Types";
            // 
            // lbl_type2
            // 
            this.lbl_type2.AutoSize = true;
            this.lbl_type2.Location = new System.Drawing.Point(6, 63);
            this.lbl_type2.Name = "lbl_type2";
            this.lbl_type2.Size = new System.Drawing.Size(65, 15);
            this.lbl_type2.TabIndex = 12;
            this.lbl_type2.Text = "Secondary:";
            // 
            // enum_type2
            // 
            this.enum_type2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enum_type2.EnumType = null;
            this.enum_type2.FieldSource = null;
            this.enum_type2.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Monospace;
            this.enum_type2.FormattingEnabled = true;
            this.enum_type2.Location = new System.Drawing.Point(77, 60);
            this.enum_type2.Name = "enum_type2";
            this.enum_type2.Size = new System.Drawing.Size(110, 23);
            this.enum_type2.TabIndex = 11;
            // 
            // lbl_type1
            // 
            this.lbl_type1.AutoSize = true;
            this.lbl_type1.Location = new System.Drawing.Point(6, 28);
            this.lbl_type1.Name = "lbl_type1";
            this.lbl_type1.Size = new System.Drawing.Size(51, 15);
            this.lbl_type1.TabIndex = 10;
            this.lbl_type1.Text = "Primary:";
            // 
            // enum_type1
            // 
            this.enum_type1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enum_type1.EnumType = null;
            this.enum_type1.FieldSource = null;
            this.enum_type1.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Monospace;
            this.enum_type1.FormattingEnabled = true;
            this.enum_type1.Location = new System.Drawing.Point(77, 25);
            this.enum_type1.Name = "enum_type1";
            this.enum_type1.Size = new System.Drawing.Size(110, 23);
            this.enum_type1.TabIndex = 9;
            // 
            // lbl_gender_expl
            // 
            this.lbl_gender_expl.AutoSize = true;
            this.lbl_gender_expl.Location = new System.Drawing.Point(190, 74);
            this.lbl_gender_expl.Name = "lbl_gender_expl";
            this.lbl_gender_expl.Size = new System.Drawing.Size(72, 15);
            this.lbl_gender_expl.TabIndex = 7;
            this.lbl_gender_expl.Text = "m: 0%, f: 0%";
            // 
            // lbl_gender
            // 
            this.lbl_gender.AutoSize = true;
            this.lbl_gender.Location = new System.Drawing.Point(3, 74);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(48, 15);
            this.lbl_gender.TabIndex = 6;
            this.lbl_gender.Text = "Gender:";
            // 
            // enum_gender
            // 
            this.enum_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enum_gender.EnumType = null;
            this.enum_gender.FieldSource = null;
            this.enum_gender.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Monospace;
            this.enum_gender.FormattingEnabled = true;
            this.enum_gender.Location = new System.Drawing.Point(63, 71);
            this.enum_gender.Name = "enum_gender";
            this.enum_gender.Size = new System.Drawing.Size(121, 23);
            this.enum_gender.TabIndex = 5;
            this.enum_gender.SelectedIndexChanged += new System.EventHandler(this.enum_gender_SelectedIndexChanged);
            // 
            // num_number
            // 
            this.num_number.FieldSource = null;
            this.num_number.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Monospace;
            this.num_number.Location = new System.Drawing.Point(63, 42);
            this.num_number.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.num_number.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_number.Name = "num_number";
            this.num_number.Size = new System.Drawing.Size(120, 23);
            this.num_number.TabIndex = 4;
            this.num_number.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txt_name
            // 
            this.txt_name.FieldSource = null;
            this.txt_name.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Monospace;
            this.txt_name.Location = new System.Drawing.Point(63, 13);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(120, 23);
            this.txt_name.TabIndex = 3;
            // 
            // lbl_number_edit
            // 
            this.lbl_number_edit.AutoSize = true;
            this.lbl_number_edit.Location = new System.Drawing.Point(3, 44);
            this.lbl_number_edit.Name = "lbl_number_edit";
            this.lbl_number_edit.Size = new System.Drawing.Size(54, 15);
            this.lbl_number_edit.TabIndex = 2;
            this.lbl_number_edit.Text = "Number:";
            // 
            // lbl_name_edit
            // 
            this.lbl_name_edit.AutoSize = true;
            this.lbl_name_edit.Location = new System.Drawing.Point(3, 16);
            this.lbl_name_edit.Name = "lbl_name_edit";
            this.lbl_name_edit.Size = new System.Drawing.Size(42, 15);
            this.lbl_name_edit.TabIndex = 0;
            this.lbl_name_edit.Text = "Name:";
            // 
            // tab_dex
            // 
            this.tab_dex.Location = new System.Drawing.Point(4, 22);
            this.tab_dex.Name = "tab_dex";
            this.tab_dex.Size = new System.Drawing.Size(710, 401);
            this.tab_dex.TabIndex = 1;
            this.tab_dex.Text = "Dex";
            this.tab_dex.UseVisualStyleBackColor = true;
            // 
            // tab_texture
            // 
            this.tab_texture.Location = new System.Drawing.Point(4, 22);
            this.tab_texture.Name = "tab_texture";
            this.tab_texture.Size = new System.Drawing.Size(710, 401);
            this.tab_texture.TabIndex = 2;
            this.tab_texture.Text = "Texture";
            this.tab_texture.UseVisualStyleBackColor = true;
            // 
            // tab_moves
            // 
            this.tab_moves.Location = new System.Drawing.Point(4, 22);
            this.tab_moves.Name = "tab_moves";
            this.tab_moves.Size = new System.Drawing.Size(710, 401);
            this.tab_moves.TabIndex = 3;
            this.tab_moves.Text = "Moves";
            this.tab_moves.UseVisualStyleBackColor = true;
            // 
            // lbl_number
            // 
            this.lbl_number.AutoSize = true;
            this.lbl_number.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::PEngine.Creator.Properties.Settings.Default, "Font_H3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbl_number.Font = global::PEngine.Creator.Properties.Settings.Default.Font_H3;
            this.lbl_number.Location = new System.Drawing.Point(152, 46);
            this.lbl_number.Name = "lbl_number";
            this.lbl_number.Size = new System.Drawing.Size(67, 30);
            this.lbl_number.TabIndex = 3;
            this.lbl_number.Text = "# XXX";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = global::PEngine.Creator.Properties.Settings.Default.Font_H2;
            this.lbl_name.Location = new System.Drawing.Point(148, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(124, 37);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "<Name>";
            // 
            // pic_monster
            // 
            this.pic_monster.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.pic_monster.Location = new System.Drawing.Point(3, 3);
            this.pic_monster.Name = "pic_monster";
            this.pic_monster.Size = new System.Drawing.Size(112, 112);
            this.pic_monster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_monster.TabIndex = 0;
            this.pic_monster.TabStop = false;
            this.pic_monster.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_monster_Paint);
            // 
            // MonsterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabs_main);
            this.Controls.Add(this.lbl_number);
            this.Controls.Add(this.btn_switch_view);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.pic_monster);
            this.Name = "MonsterEditor";
            this.Size = new System.Drawing.Size(724, 551);
            this.tabs_main.ResumeLayout(false);
            this.tab_info.ResumeLayout(false);
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            this.group_types.ResumeLayout(false);
            this.group_types.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_monster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrispPictureBox pic_monster;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_switch_view;
        private System.Windows.Forms.ToolTip toolTip_main;
        private System.Windows.Forms.Label lbl_number;
        private System.Windows.Forms.TabControl tabs_main;
        private System.Windows.Forms.TabPage tab_info;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.TabPage tab_dex;
        private System.Windows.Forms.TabPage tab_texture;
        private System.Windows.Forms.TabPage tab_moves;
        private System.Windows.Forms.Label lbl_name_edit;
        private System.Windows.Forms.Label lbl_number_edit;
        private Fieldset.IntField num_number;
        private Fieldset.TextField txt_name;
        private Fieldset.EnumField enum_gender;
        private System.Windows.Forms.Label lbl_gender_expl;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.GroupBox group_types;
        private System.Windows.Forms.Label lbl_type2;
        private Fieldset.EnumField enum_type2;
        private System.Windows.Forms.Label lbl_type1;
        private Fieldset.EnumField enum_type1;
    }
}
