namespace PEngine.Creator.Views.Game
{
    partial class DebugView
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
            this.tool_debug = new System.Windows.Forms.ToolStrip();
            this.tool_debug_stop = new System.Windows.Forms.ToolStripButton();
            this.tool_debug_restart = new System.Windows.Forms.ToolStripButton();
            this.tool_debug_close = new System.Windows.Forms.ToolStripButton();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.split_game = new System.Windows.Forms.SplitContainer();
            this.tool_resources = new System.Windows.Forms.ToolStrip();
            this.tool_resources_lbl_title = new System.Windows.Forms.ToolStripLabel();
            this.tree_resources = new System.Windows.Forms.TreeView();
            this.lbl_command = new System.Windows.Forms.Label();
            this.txt_command = new System.Windows.Forms.TextBox();
            this.tool_log = new System.Windows.Forms.ToolStrip();
            this.tool_log_clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_log_chk_events = new System.Windows.Forms.ToolStripButton();
            this.tool_main = new System.Windows.Forms.ToolTip(this.components);
            this.tool_debug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).BeginInit();
            this.split_main.Panel1.SuspendLayout();
            this.split_main.Panel2.SuspendLayout();
            this.split_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_game)).BeginInit();
            this.split_game.Panel1.SuspendLayout();
            this.split_game.SuspendLayout();
            this.tool_resources.SuspendLayout();
            this.tool_log.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_debug
            // 
            this.tool_debug.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_debug.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.tool_debug.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_debug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_debug_stop,
            this.tool_debug_restart,
            this.tool_debug_close});
            this.tool_debug.Location = new System.Drawing.Point(0, 0);
            this.tool_debug.Name = "tool_debug";
            this.tool_debug.Size = new System.Drawing.Size(1158, 25);
            this.tool_debug.TabIndex = 0;
            this.tool_debug.Text = "toolStrip1";
            // 
            // tool_debug_stop
            // 
            this.tool_debug_stop.Enabled = false;
            this.tool_debug_stop.Image = global::PEngine.Creator.Properties.Resources.stopDebug;
            this.tool_debug_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_debug_stop.Name = "tool_debug_stop";
            this.tool_debug_stop.Size = new System.Drawing.Size(51, 22);
            this.tool_debug_stop.Text = "Stop";
            this.tool_debug_stop.ToolTipText = "Stop Game execution";
            this.tool_debug_stop.Click += new System.EventHandler(this.tool_debug_stop_Click);
            // 
            // tool_debug_restart
            // 
            this.tool_debug_restart.Image = global::PEngine.Creator.Properties.Resources.refresh_16xLG;
            this.tool_debug_restart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_debug_restart.Name = "tool_debug_restart";
            this.tool_debug_restart.Size = new System.Drawing.Size(63, 22);
            this.tool_debug_restart.Text = "Restart";
            this.tool_debug_restart.ToolTipText = "Restart Game";
            this.tool_debug_restart.Click += new System.EventHandler(this.tool_debug_restart_Click);
            // 
            // tool_debug_close
            // 
            this.tool_debug_close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tool_debug_close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_debug_close.Image = global::PEngine.Creator.Properties.Resources.Close_16xLG;
            this.tool_debug_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_debug_close.Name = "tool_debug_close";
            this.tool_debug_close.Size = new System.Drawing.Size(23, 22);
            this.tool_debug_close.Text = "Close overlay";
            this.tool_debug_close.ToolTipText = "Close overlay";
            this.tool_debug_close.Click += new System.EventHandler(this.tool_debug_close_Click);
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.txt_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_log.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log.Location = new System.Drawing.Point(3, 28);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.Size = new System.Drawing.Size(1152, 322);
            this.txt_log.TabIndex = 1;
            this.txt_log.WordWrap = false;
            // 
            // split_main
            // 
            this.split_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_main.Location = new System.Drawing.Point(0, 25);
            this.split_main.Name = "split_main";
            this.split_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_main.Panel1
            // 
            this.split_main.Panel1.Controls.Add(this.split_game);
            // 
            // split_main.Panel2
            // 
            this.split_main.Panel2.Controls.Add(this.lbl_command);
            this.split_main.Panel2.Controls.Add(this.txt_command);
            this.split_main.Panel2.Controls.Add(this.tool_log);
            this.split_main.Panel2.Controls.Add(this.txt_log);
            this.split_main.Size = new System.Drawing.Size(1158, 771);
            this.split_main.SplitterDistance = 385;
            this.split_main.TabIndex = 2;
            // 
            // split_game
            // 
            this.split_game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_game.Location = new System.Drawing.Point(0, 0);
            this.split_game.Name = "split_game";
            // 
            // split_game.Panel1
            // 
            this.split_game.Panel1.Controls.Add(this.tool_resources);
            this.split_game.Panel1.Controls.Add(this.tree_resources);
            this.split_game.Size = new System.Drawing.Size(1158, 385);
            this.split_game.SplitterDistance = 340;
            this.split_game.TabIndex = 0;
            // 
            // tool_resources
            // 
            this.tool_resources.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_MainGray;
            this.tool_resources.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_resources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_resources_lbl_title});
            this.tool_resources.Location = new System.Drawing.Point(0, 0);
            this.tool_resources.Name = "tool_resources";
            this.tool_resources.Size = new System.Drawing.Size(340, 25);
            this.tool_resources.TabIndex = 1;
            this.tool_resources.Text = "toolStrip1";
            // 
            // tool_resources_lbl_title
            // 
            this.tool_resources_lbl_title.Name = "tool_resources_lbl_title";
            this.tool_resources_lbl_title.Size = new System.Drawing.Size(102, 22);
            this.tool_resources_lbl_title.Text = "Loaded Resources";
            // 
            // tree_resources
            // 
            this.tree_resources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_resources.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.tree_resources.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree_resources.Location = new System.Drawing.Point(3, 28);
            this.tree_resources.Name = "tree_resources";
            this.tree_resources.Size = new System.Drawing.Size(334, 354);
            this.tree_resources.TabIndex = 0;
            // 
            // lbl_command
            // 
            this.lbl_command.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_command.AutoSize = true;
            this.lbl_command.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.lbl_command.Location = new System.Drawing.Point(6, 360);
            this.lbl_command.Name = "lbl_command";
            this.lbl_command.Size = new System.Drawing.Size(15, 15);
            this.lbl_command.TabIndex = 4;
            this.lbl_command.Text = ">";
            this.tool_main.SetToolTip(this.lbl_command, "Enter command");
            // 
            // txt_command
            // 
            this.txt_command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_command.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.txt_command.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_command.Location = new System.Drawing.Point(24, 356);
            this.txt_command.Name = "txt_command";
            this.txt_command.Size = new System.Drawing.Size(1131, 23);
            this.txt_command.TabIndex = 3;
            this.txt_command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_command_KeyDown);
            // 
            // tool_log
            // 
            this.tool_log.BackColor = global::PEngine.Creator.Properties.Settings.Default.Color_LightGray;
            this.tool_log.Font = global::PEngine.Creator.Properties.Settings.Default.Font_Status;
            this.tool_log.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_log_clear,
            this.toolStripSeparator1,
            this.tool_log_chk_events});
            this.tool_log.Location = new System.Drawing.Point(0, 0);
            this.tool_log.Name = "tool_log";
            this.tool_log.Size = new System.Drawing.Size(1158, 25);
            this.tool_log.TabIndex = 2;
            this.tool_log.Text = "toolStrip1";
            // 
            // tool_log_clear
            // 
            this.tool_log_clear.Image = global::PEngine.Creator.Properties.Resources.Clearallrequests_8816;
            this.tool_log_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_log_clear.Name = "tool_log_clear";
            this.tool_log_clear.Size = new System.Drawing.Size(77, 22);
            this.tool_log_clear.Text = "Clear Log";
            this.tool_log_clear.Click += new System.EventHandler(this.tool_log_clear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_log_chk_events
            // 
            this.tool_log_chk_events.Checked = true;
            this.tool_log_chk_events.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tool_log_chk_events.Image = global::PEngine.Creator.Properties.Resources.EventLog_5735;
            this.tool_log_chk_events.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_log_chk_events.Name = "tool_log_chk_events";
            this.tool_log_chk_events.Size = new System.Drawing.Size(84, 22);
            this.tool_log_chk_events.Text = "Log Events";
            this.tool_log_chk_events.ToolTipText = "Whether all events should be logged";
            this.tool_log_chk_events.Click += new System.EventHandler(this.tool_log_chk_events_Click);
            // 
            // DebugView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split_main);
            this.Controls.Add(this.tool_debug);
            this.Name = "DebugView";
            this.Size = new System.Drawing.Size(1158, 796);
            this.tool_debug.ResumeLayout(false);
            this.tool_debug.PerformLayout();
            this.split_main.Panel1.ResumeLayout(false);
            this.split_main.Panel2.ResumeLayout(false);
            this.split_main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).EndInit();
            this.split_main.ResumeLayout(false);
            this.split_game.Panel1.ResumeLayout(false);
            this.split_game.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_game)).EndInit();
            this.split_game.ResumeLayout(false);
            this.tool_resources.ResumeLayout(false);
            this.tool_resources.PerformLayout();
            this.tool_log.ResumeLayout(false);
            this.tool_log.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_debug;
        private System.Windows.Forms.ToolStripButton tool_debug_stop;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.ToolStripButton tool_debug_restart;
        private System.Windows.Forms.ToolStripButton tool_debug_close;
        private System.Windows.Forms.SplitContainer split_main;
        private System.Windows.Forms.ToolStrip tool_log;
        private System.Windows.Forms.ToolStripButton tool_log_clear;
        private System.Windows.Forms.ToolStripButton tool_log_chk_events;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer split_game;
        private System.Windows.Forms.ToolStrip tool_resources;
        private System.Windows.Forms.ToolStripLabel tool_resources_lbl_title;
        private System.Windows.Forms.TreeView tree_resources;
        private System.Windows.Forms.Label lbl_command;
        private System.Windows.Forms.ToolTip tool_main;
        private System.Windows.Forms.TextBox txt_command;
    }
}
