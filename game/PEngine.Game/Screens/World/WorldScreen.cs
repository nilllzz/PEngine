using GameDevCommon.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Core;

namespace PEngine.Game.Screens.World
{
    class WorldScreen : Screen
    {
        private SpriteBatch _batch;

        internal override void LoadContent()
        {
            _batch = new SpriteBatch(Controller.GraphicsDevice);
        }

        internal override void UnloadContent()
        {

        }

        internal override void Draw(GameTime gameTime)
        {
            _batch.Begin();
            _batch.DrawRectangle(new Rectangle(0, 0, 10, 10), Color.Red);
            _batch.End();
        }

        internal override void Update(GameTime gameTime)
        {

        }
    }
}
