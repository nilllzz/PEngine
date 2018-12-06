using System;
using System.Diagnostics;

namespace PEngine.Creator.Components.Game
{
    class GameProcess
    {
        internal event Action<string> OutputReceived;
        internal event Action ProcessStopped;

        private Process _processHandle;

        internal void Start()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "PEngine.Game.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };
            _processHandle = Process.Start(startInfo);
            _processHandle.EnableRaisingEvents = true;
            _processHandle.BeginOutputReadLine();

            _processHandle.OutputDataReceived += _processHandle_OutputDataReceived;
            _processHandle.Exited += _processHandle_Exited;
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
            _processHandle.Close();
            _processHandle.OutputDataReceived -= _processHandle_OutputDataReceived;
            _processHandle.Exited -= _processHandle_Exited;
            _processHandle = null;
        }
    }
}
