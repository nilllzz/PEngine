using PEngine.Common.Interop;
using System;
using System.Diagnostics;
using System.Drawing;

namespace PEngine.Creator.Components.Game
{
    internal class GameProcess
    {
        internal event Action<string> OutputReceived;
        internal event Action ProcessStopped;

        private Process _processHandle;

        internal int ProcessId => _processHandle.Id;
        internal Pipeline Pipeline { get; private set; }

        internal void Start()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "PEngine.Game.exe",
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            _processHandle = Process.Start(startInfo);
            _processHandle.EnableRaisingEvents = true;
            _processHandle.BeginOutputReadLine();

            _processHandle.OutputDataReceived += _processHandle_OutputDataReceived;
            _processHandle.Exited += _processHandle_Exited;

            Pipeline = new Pipeline(_processHandle.StandardInput);
        }

        private void _processHandle_Exited(object sender, EventArgs e)
        {
            ProcessStopped?.Invoke();
            Stop();
        }

        private void _processHandle_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputReceived?.Invoke(e.Data);
        }

        internal void Stop()
        {
            if (!_processHandle.HasExited)
            {
                _processHandle.Kill();
            }
            _processHandle.OutputDataReceived -= _processHandle_OutputDataReceived;
            _processHandle.Exited -= _processHandle_Exited;
            _processHandle = null;
        }
    }
}
