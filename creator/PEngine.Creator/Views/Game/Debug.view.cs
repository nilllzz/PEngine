using PEngine.Common;
using PEngine.Common.Interop;
using PEngine.Creator.Components.Game;
using PEngine.Creator.Components.Projects;
using PEngine.Creator.Forms;
using PEngine.Creator.Properties;
using PEngine.Creator.Views.Projects;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PEngine.Creator.Views.Game
{
    internal partial class DebugView : BaseView
    {
        private MainProjectView _previousView;
        private GameProcess _process;

        private bool _isConnected = false;
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
                    map_preview.GameProcess = _process;

                    Status = $"Connected (PID: {_process.ProcessId})";
                    Title = Project.ActiveProject.Name + " (Running)";
                    StatusColor = Color.FromArgb(202, 81, 0);
                }
                else
                {
                    Status = $"Disconnected";
                    Title = Project.ActiveProject.Name;
                    StatusColor = Settings.Default.Color_Highlight;
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
                MessageBox.Show("You have to stop debugging first to close the debugging overlay.",
                    "Debugging", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
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
            txt_log.Text = "";
            Status = "Waiting for process...";

            tree_resources.Nodes.Clear();
            tree_resources.Nodes.Add("Game");
            tree_resources.Nodes[0].Expand();

            _process = new GameProcess();
            _process.ProcessStopped += Process_ProcessStopped;
            _process.OutputReceived += Process_Output;

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

        private void AddLogEntry(LogEntry entry)
        {
            var message = $"[{entry.Type.ToString().PadRight(10)}] {entry.Message}";
            if (txt_log.Text.Length > 0)
            {
                txt_log.Text += Environment.NewLine;
            }
            txt_log.Text += message;
        }

        private void ProcessEvent(PipelineMessage message)
        {
            switch (message.Event)
            {
                case Pipeline.EVENT_STARTUP:
                    IsConnected = true;
                    break;
                case Pipeline.EVENT_LOAD_MAP:
                    AddLoadedResource(ProjectItemType.Map, message.Content);
                    break;
                case Pipeline.EVENT_LOAD_TILESET:
                    AddLoadedResource(ProjectItemType.Tileset, message.Content);
                    break;
                case Pipeline.EVENT_SET_MAP:
                    map_preview.LoadMap(message.Content);
                    break;
                case Pipeline.EVENT_PLAYER_MOVED:
                    var coordinates = message.Content.Split(',').Select(c => int.Parse(c)).ToArray();
                    map_preview.SetPlayerPosition(new Point(coordinates[0], coordinates[1]));
                    break;
            }

            if (tool_log_chk_events.Checked && message.Event != Pipeline.EVENT_PLAYER_MOVED)
            {
                AddLogEntry(new LogEntry
                {
                    Type = LogType.Debug,
                    Message = "[Event: " + message.Event + "] Content: \"" + message.Content + "\""
                });
            }
        }

        private void Process_ProcessStopped()
        {
            Dispatch(() =>
            {
                IsConnected = false;
            });
        }

        private void CloseView()
        {
            MainForm.Instance.SetView(_previousView);
        }

        private void AddLoadedResource(ProjectItemType itemType, string id)
        {
            var parent = GetNodeForItemType(itemType);
            var node = new TreeNode(id);
            parent.Nodes.Add(node);
            parent.Expand();
        }

        private TreeNode GetNodeForItemType(ProjectItemType itemType)
        {
            var text = itemType.ToString();
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
    }
}
