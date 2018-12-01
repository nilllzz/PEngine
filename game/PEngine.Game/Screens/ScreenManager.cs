using Microsoft.Xna.Framework;

namespace PEngine.Game.Screens
{
    internal sealed class ScreenManager : IGameComponent
    {
        internal Screen ActiveScreen { get; private set; }

        public void Initialize()
        {
            var worldScreen = new World.WorldScreen();
            SetScreen(worldScreen);
        }

        public void SetScreen(Screen screen)
        {
            ActiveScreen?.UnloadContent();
            ActiveScreen = screen;
        }
    }
}
