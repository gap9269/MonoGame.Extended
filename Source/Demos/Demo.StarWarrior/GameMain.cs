using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

namespace Demo.StarWarrior
{
    public class GameMain : Game
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
       // private readonly FramesPerSecondCounter _fpsCounter = new FramesPerSecondCounter();
        private readonly Random _random = new Random();

        private SpriteBatch _spriteBatch;
        private BitmapFont _font;

        public GameMain()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = false;
            IsFixedTimeStep = true;

            _graphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = 800,
                PreferredBackBufferHeight = 600,
                PreferredBackBufferFormat = SurfaceFormat.Color,
                PreferMultiSampling = false,
                PreferredDepthStencilFormat = DepthFormat.None,
                SynchronizeWithVerticalRetrace = true,
            };

            Services.AddService(Content);
            Services.AddService(_random);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var graphicsDevice = GraphicsDevice;

            _spriteBatch = new SpriteBatch(graphicsDevice);
            Services.AddService(_spriteBatch);

            _font = Content.Load<BitmapFont>("montserrat-32");
            Services.AddService(_font);
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();
            var gamePadState = GamePad.GetState(PlayerIndex.One);

          //  if (gamePadState.Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Escape))
           //     Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

#if DEBUG
            _spriteBatch.DrawString(_font, "tesssst", new Vector2(16, 62), Color.White);
#endif

            _spriteBatch.End();
        }
    }
}
