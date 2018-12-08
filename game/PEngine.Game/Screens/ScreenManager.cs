using Microsoft.Xna.Framework;
using PEngine.Common.Interop;
using static Core;

namespace PEngine.Game.Screens
{
    internal sealed class ScreenManager : IGameComponent
    {
        internal Screen ActiveScreen { get; private set; }

        void IGameComponent.Initialize()
        {
            var worldScreen = new World.WorldScreen();
            SetScreen(worldScreen);
        }

        internal void SetScreen(Screen screen)
        {
            ActiveScreen?.UnloadContent();
            ActiveScreen = screen;
            Controller.Pipeline.Write(Pipeline.EVENT_SCENE_CHANGED, screen.GetType().Name);
        }
    }
}
