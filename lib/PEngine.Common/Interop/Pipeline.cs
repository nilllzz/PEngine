﻿using System;
using System.IO;

namespace PEngine.Common.Interop
{
    public struct PipelineMessage
    {
        public string Event;
        public string Content;

        public LogEntry GetEntry()
        {
            if (Event == Pipeline.EVENT_MESSAGE)
            {
                var type = (LogType)int.Parse(Content.Substring(0, 1));
                var message = Content.Substring(1);
                return new LogEntry
                {
                    Type = type,
                    Message = message,
                };
            }
            else
            {
                return new LogEntry
                {
                    Message = Content,
                    Type = LogType.Debug
                };
            }
        }
    }

    public struct LogEntry
    {
        public LogType Type;
        public string Message;
    }

    public class Pipeline
    {
        // normal log message
        public const string EVENT_MESSAGE = "MESSAGE";
        // general
        public const string EVENT_STARTUP = "STARTUP";
        public const string EVENT_STOP = "STOP";
        // resources
        public const string EVENT_LOAD_MAP = "LOAD_MAP"; // loaded a map resource
        public const string EVENT_LOAD_TILESET = "LOAD_TILESET"; // loaded a tileset resource
        public const string EVENT_SET_MAP = "SET_MAP"; // changes the active map
        public const string EVENT_UNLOAD_MAP = "UNLOAD_MAP"; // unloaded a map resource
        public const string EVENT_UNLOAD_TILESET = "UNLOAD_TILESET";
        // gameplay
        public const string EVENT_PLAYER_MOVED = "PLAYER_MOVED";
        public const string EVENT_SCENE_CHANGED = "SCENE_CHANGED";

        private readonly TextWriter _stdout;

        public Pipeline(TextWriter stdout)
        {
            _stdout = stdout;
        }

        public void Write(string eventType, string content = "")
        {
            if (content == "")
            {
                _stdout.WriteLine(eventType);
            }
            else
            {
                _stdout.WriteLine(eventType + "|" + content);
            }
        }

        public void Log(LogType type, string message)
        {
            Write(EVENT_MESSAGE, ((int)type).ToString() + message);
        }

        public static PipelineMessage Parse(string line)
        {
            if (line.Contains("|"))
            {
                var splitIndex = line.IndexOf("|");
                return new PipelineMessage
                {
                    Event = line.Substring(0, splitIndex),
                    Content = line.Substring(splitIndex + 1),
                };
            }
            else
            {
                return new PipelineMessage
                {
                    Event = line,
                    Content = "",
                };
            }
        }
    }
}
