using PEngine.Common.Interop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PEngine.Game
{
    internal class StdInReader
    {
        private readonly List<string> _buffer = new List<string>();

        internal event Action<PipelineMessage> PipelineItemArrived;

        internal void HandleBuffer()
        {
            foreach (var item in _buffer)
            {
                var message = Pipeline.Parse(item);
                PipelineItemArrived?.Invoke(message);
            }
            _buffer.Clear();
        }

        internal void StartListening()
        {
            _buffer.Clear();
            Task.Run(() =>
            {
                var reachedEnd = false;
                do
                {
                    var line = Console.ReadLine();
                    if (line == null)
                    {
                        reachedEnd = true;
                    }
                    else
                    {
                        _buffer.Add(line);
                    }
                } while (!reachedEnd);
            });
        }
    }
}
