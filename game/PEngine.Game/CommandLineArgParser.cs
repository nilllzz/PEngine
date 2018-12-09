using Microsoft.Xna.Framework;
using PEngine.Common.Interop;
using static Core;

namespace PEngine.Game
{
    internal static class CommandLineArgParser
    {
        internal static bool IsDebugging { get; private set; }
        internal static int Scale { get; private set; } = 1;
        internal static string StartMap { get; private set; } = null;

        internal static void Parse(string[] args)
        {
            GamePipeline.Log(LogType.Info, "Start with args: \"" + string.Join("\", \"", args) + "\"");
            foreach (var arg in args)
            {
                var name = arg;
                var value = "";
                if (arg.Contains("="))
                {
                    name = arg.Substring(0, arg.IndexOf("="));
                    value = arg.Substring(arg.IndexOf("=") + 1);
                }

                switch (name.ToLower())
                {
                    case "debug":
                        if (value == "" || value.ToLower() == "true")
                        {
                            IsDebugging = true;
                        }
                        break;
                    case "project":
                        ProjectHelper.ProjectPath = value;
                        break;
                    case "scale":
                        if (int.TryParse(value, out var scale))
                        {
                            Scale = MathHelper.Clamp(scale, 1, 5);
                        }
                        break;
                    case "map":
                        if (value.Length > 0)
                        {
                            StartMap = value;
                        }
                        break;
                }
            }
        }
    }
}
