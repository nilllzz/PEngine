using System.Linq;

namespace PEngine.Creator.Helpers
{
    internal struct CommandLineArg
    {
        internal string Name;
        internal string Value;
    }

    internal static class CommandLineArgsHelper
    {
        internal static string CreateArgs(CommandLineArg[] args)
        {
            return string.Join(" ", args.Select(a => $"{a.Name}=\"{a.Value}\""));
        }
    }
}
