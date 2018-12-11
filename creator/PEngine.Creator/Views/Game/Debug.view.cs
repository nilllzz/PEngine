using PEngine.Common;
using PEngine.Common.Data;
using PEngine.Common.Interop;
using PEngine.Creator.Components.Debug;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Forms;
using PEngine.Creator.Properties;
using PEngine.Creator.Views.Projects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Game
{
    internal partial class DebugView : BaseView
    {
        private MainProjectView _previousView;
        private GameProcess _process;
        private bool _isConnected = false;

        private BaseDebugComponent ActiveComponent
        {
            get
            {
                var container = split_game.Panel2;
                if (container.Controls.Count == 1 &&
                    container.Controls[0] is BaseDebugComponent debugComp)
                {
                    return debugComp;
                }
                return null;
            }
            set
            {
                var container = split_game.Panel2;
                container.Controls.Clear();
                if (value != null)
                {
                    value.Dock = DockStyle.Fill;
                    container.Controls.Add(value);
                }
            }
        }

        private bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;

                tool_debug_stop.Enabled = _isConnected;
                if (_isConnected)
                {
                    tree_resources.Nodes[0].Text = $"Game ({_process.ProcessId})";
                    ActiveComponent?.SetGameProcess(_process);

                    Status = $"Connected (PID: {_process.ProcessId})";
                    Title = Project.ActiveProject.Name + " (Running)";
                    StatusColor = Color.FromArgb(202, 81, 0);
                }
                else
                {
                    Status = $"Disconnected";
                    Title = Project.ActiveProject.Name;
                    StatusColor = Settings.Default.Color_Highlight;
                    ActiveComponent?.DebuggingStopped();
                }
            }
        }

        internal DebugView()
        {
            InitializeComponent();
        }

        #region ui

        private void tool_debug_stop_Click(object sender, System.EventArgs e)
        {
            StopDebug();
        }

        private void tool_debug_close_Click(object sender, System.EventArgs e)
        {
            if (IsConnected)
            {
                var result = MessageBox.Show("The game is still running, do you want to close it to close this overlay?",
                    "Debugging", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    return;
                }
                StopDebug();
            }
            CloseView();
        }

        private void tool_log_clear_Click(object sender, System.EventArgs e)
        {
            txt_log.Text = "";
        }

        private void tool_log_chk_events_Click(object sender, System.EventArgs e)
        {
            tool_log_chk_events.Checked = !tool_log_chk_events.Checked;
        }

        private void tool_debug_restart_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                StopDebug();
            }

            StartDebug();
        }

        #endregion

        internal override bool FormClosing()
        {
            if (IsConnected)
            {
                _process.Stop();
            }
            return base.FormClosing();
        }

        internal void SetPreviousView(MainProjectView view)
        {
            _previousView = view;
        }

        internal void StartDebug()
        {
            ActiveComponent = null;
            txt_log.Text = "";
            Status = "Waiting for process...";

            tree_resources.Nodes.Clear();
            tree_resources.Nodes.Add("Game");
            tree_resources.Nodes[0].Expand();

            _process = new GameProcess();
            _process.ProcessStopped += Process_ProcessStopped;
            _process.OutputReceived += Process_Output;
            _process.ErrorReceived += Process_Error;

            _process.Start();
        }

        private void StopDebug()
        {
            _process.Stop();
            AddLogEntry(new LogEntry
            {
                Type = LogType.Debug,
                Message = "Debugging aborted"
            });
            IsConnected = false;
        }

        private void Process_Output(string log)
        {
            if (log == null)
            {
                return;
            }
            Dispatch(() =>
            {
                var message = Pipeline.Parse(log);
                if (message.Event == Pipeline.EVENT_MESSAGE)
                {
                    AddLogEntry(message.GetEntry());
                }
                else
                {
                    ProcessEvent(message);
                }
            });
        }

        private void Process_Error(string message)
        {
            Dispatch(() =>
            {
                AddLogEntry(new LogEntry
                {
                    Type = LogType.Error,
                    Message = message,
                });
            });
        }

        private void AddLogEntry(LogEntry entry)
        {
            var message = $"[{entry.Type.ToString().PadRight(7)}] {entry.Message}";
            AddLogEntry(message);
        }

        private void AddLogEntry(string entry)
        {
            if (txt_log.Text.Length > 0)
            {
                txt_log.Text += Environment.NewLine;
            }
            txt_log.AppendText(entry);
        }

        private void ProcessEvent(PipelineMessage message)
        {
            switch (message.Event)
            {
                case Pipeline.EVENT_STARTUP:
                    IsConnected = true;
                    break;
                case Pipeline.EVENT_LOAD_MAP:
                    AddLoadedResource(ProjectFileType.Map, message.Content);
                    break;
                case Pipeline.EVENT_LOAD_TILESET:
                    AddLoadedResource(ProjectFileType.Tileset, message.Content);
                    break;
                case Pipeline.EVENT_SCENE_CHANGED:
                    SceneChanged(message);
                    break;
            }

            ActiveComponent?.HandlePipelineEvent(message);

            if (tool_log_chk_events.Checked && message.Event != Pipeline.EVENT_PLAYER_MOVED)
            {
                AddLogEntry(new LogEntry
                {
                    Type = LogType.Debug,
                    Message = "[Event: " + message.Event + "] " + message.Content
                });
            }
        }

        private void Process_ProcessStopped()
        {
            _process.ProcessStopped -= Process_ProcessStopped;
            _process.OutputReceived -= Process_Output;
            _process.ErrorReceived -= Process_Error;

            Dispatch(() =>
            {
                AddLogEntry($"Process {_process.ProcessId} exited with code {_process.ExitCode}");
                IsConnected = false;
            });
        }

        private void CloseView()
        {
            MainForm.Instance.SetView(_previousView);
        }

        private void AddLoadedResource(ProjectFileType fileType, string id)
        {
            var parent = GetNodeForFileType(fileType);
            var node = new TreeNode(id);
            parent.Nodes.Add(node);
            parent.Expand();
        }

        private TreeNode GetNodeForFileType(ProjectFileType fileType)
        {
            var text = fileType.ToString();
            foreach (var node in tree_resources.Nodes)
            {
                if (node is TreeNode treeNode && treeNode.Text == text)
                {
                    return treeNode;
                }
            }
            var newNode = new TreeNode(text);
            tree_resources.Nodes[0].Nodes.Add(newNode);
            newNode.Expand();
            return newNode;
        }

        private void SceneChanged(PipelineMessage message)
        {
            BaseDebugComponent comp = null;
            switch (message.Content)
            {
                case "WorldScreen":
                    comp = new MapPreview();
                    comp.SetGameProcess(_process);
                    break;
            }
            ActiveComponent = comp;
        }

        private void txt_command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // execute command
                txt_command.Text = "";
            }
        }
    }
}
