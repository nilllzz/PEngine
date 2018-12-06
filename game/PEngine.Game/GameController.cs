using GameDevCommon;
using GameDevCommon.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PEngine.Common;
using PEngine.Common.Data.Maps;
using PEngine.Game.Components;
using PEngine.Game.Screens;
using static Core;

namespace PEngine.Game
{
    internal sealed class GameController : Microsoft.Xna.Framework.Game, IGame
    {
        public const int RENDER_WIDTH = 160;
        public const int RENDER_HEIGHT = 144;

        private SpriteBatch _batch;

        internal GraphicsDeviceManager DeviceManager { get; }
        internal ComponentManager ComponentManager { get; }
        public Microsoft.Xna.Framework.Game GetGame() => this;
        public ComponentManager GetComponentManager() => ComponentManager;
        internal Rectangle ClientRectangle => new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        internal ContentManager ProjectContent { get; private set; }

        public GameController()
        {
            DeviceManager = new GraphicsDeviceManager(this);
            DeviceManager.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            ComponentManager = new ComponentManager();
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            // TODO: remove this
            ProjectHelper.LoadTestProject();
            // TODO: set this to the correct project
            ProjectContent = new ContentManager(Services, "test/content");

            GameInstanceProvider.SetInstance(this);
            ComponentManager.LoadComponents();

            DeviceManager.PreferredBackBufferWidth = RENDER_WIDTH * 4;
            DeviceManager.PreferredBackBufferHeight = RENDER_HEIGHT * 4;
            DeviceManager.ApplyChanges();

            base.Initialize();

            GameboyInputs.Initialize();

            System.Console.WriteLine("Started successfully");
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _batch = new SpriteBatch(GraphicsDevice);
            RenderTargetManager.Initialize(RENDER_WIDTH, RENDER_HEIGHT);
            GetComponent<ScreenManager>().ActiveScreen.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GetComponent<ControlsHandler>().Update();
            GetComponent<ScreenManager>().ActiveScreen.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);
            GraphicsDevice.SetRenderTarget(RenderTargetManager.DefaultTarget);

            GetComponent<ScreenManager>().ActiveScreen.Draw(gameTime);

            GraphicsDevice.SetRenderTarget(null);

            _batch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
            _batch.Draw(RenderTargetManager.DefaultTarget, ClientRectangle, Color.White);
            _batch.End();

            base.Draw(gameTime);
        }
    }
}
