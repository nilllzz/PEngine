using Microsoft.Xna.Framework;
using PEngine.Common.Interop;
using PEngine.Game;
using System;

internal static class Core
{
    internal static GameController Controller { get; private set; }

    internal static T GetComponent<T>() where T : IGameComponent
        => Controller.ComponentManager.GetComponent<T>();

    internal static Pipeline GamePipeline { get; private set; }
    internal static bool IsDebugging { get; private set; }

    [STAThread]
    private static void Main(string[] args)
    {
        GamePipeline = new Pipeline(Console.Out);

        CommandLineArgParser.Parse(args);
        IsDebugging = CommandLineArgParser.IsDebugging;

        using (Controller = new GameController())
            Controller.Run();
    }

}
