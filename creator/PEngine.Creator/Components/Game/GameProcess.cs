using PEngine.Common;
using PEngine.Common.Interop;
using PEngine.Creator.Helpers;
using PEngine.Creator.Properties;
using System;
using System.Diagnostics;

namespace PEngine.Creator.Components.Game
{
    internal class GameProcess
    {
        internal event Action<string> OutputReceived;
        internal event Action<string> ErrorReceived;
        internal event Action ProcessStopped;

        private Process _processHandle;

        internal int ProcessId => _processHandle.Id;
        internal int ExitCode => _processHandle.ExitCode;
        internal Pipeline Pipeline { get; private set; }

        internal void Start()
        {
            var args = CommandLineArgsHelper.CreateArgs(new[]
            {
                new CommandLineArg
                {
                    Name = "debug",
                    Value = "true",
                },
                new CommandLineArg
                {
                    Name = "project",
                    Value = Project.ActiveProject.BaseDirectory,
                },
                new CommandLineArg
                {
                    Name = "scale",
                    Value = Settings.Default.GameScale.ToString(),
                },
            });
            var startInfo = new ProcessStartInfo
            {
                FileName = "PEngine.Game.exe",
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                Arguments = args,
            };
            _processHandle = Process.Start(startInfo);
            _processHandle.EnableRaisingEvents = true;
            _processHandle.BeginOutputReadLine();
            _processHandle.BeginErrorReadLine();

            _processHandle.OutputDataReceived += _processHandle_OutputDataReceived;
            _processHandle.ErrorDataReceived += _processHandle_ErrorDataReceived;
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

        private void _processHandle_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.Length > 0)
            {
                ErrorReceived?.Invoke(e.Data);
            }
        }

        internal void Stop()
        {
            if (!_processHandle.HasExited)
            {
                _processHandle.Kill();
            }
            _processHandle.OutputDataReceived -= _processHandle_OutputDataReceived;
            _processHandle.ErrorDataReceived -= _processHandle_ErrorDataReceived;
            _processHandle.Exited -= _processHandle_Exited;
            _processHandle = null;
        }
    }
}
