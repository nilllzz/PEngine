using GameDevCommon.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Core;

namespace PEngine.Game.Screens.World
{
    internal class WorldScreen : Screen
    {
        internal const float SPRITE_LAYER_MAP = 0;
        internal const float SPRITE_LAYER_ANIMATIONS = 0.1f;
        internal const float SPRITE_LAYER_ENTITY = 0.2f;
        internal const float SPRITE_LAYER_PLAYER = 0.3f;

        private SpriteBatch _batch;
        private Components.World.World _world;

        internal override void LoadContent()
        {
            _batch = new SpriteBatch(Controller.GraphicsDevice);

            _world = new Components.World.World();
            _world.LoadMap(CommandLineArgParser.StartMap ?? "default");
        }

        internal override void UnloadContent()
        {

        }

        internal override void Draw(GameTime gameTime)
        {
            // draw map
            _batch.Begin(sortMode: SpriteSortMode.FrontToBack);

            // draw default background
            _batch.DrawRectangle(Controller.ClientRectangle, new Color(53, 53, 53));

            _world.Draw(_batch);

            _batch.End();

            // draw grid
            //_batch.Begin();

            //for (var x = 0; x < Controller.ClientRectangle.Width; x += 16)
            //{
            //    _batch.DrawRectangle(new Rectangle(x, 0, 1, Controller.ClientRectangle.Height), Color.Black);
            //}
            //for (var y = 0; y < Controller.ClientRectangle.Height; y += 16)
            //{
            //    _batch.DrawRectangle(new Rectangle(0, y, Controller.ClientRectangle.Width, 1), Color.Black);
            //}

            //_batch.End();

        }

        internal override void Update(GameTime gameTime)
        {
            _world.Update();
        }
    }
}
