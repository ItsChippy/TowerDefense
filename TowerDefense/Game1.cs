using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace TowerDefense
{
    internal enum GameState
    {
        StartMenu,
        Playing,
        GameOver
    }

    internal class Game1 : Game
    {
        public static Game1 Self;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static RenderTarget2D RenderTarget;
        public static Song mainTheme;
        public static GameState CurrentState;
        private Dictionary<GameState, IStateHandler> stateHandler;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Self = this;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            mainTheme = Content.Load<Song>("maintheme");
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            RenderTarget = new RenderTarget2D(GraphicsDevice, Window.ClientBounds.Width, Window.ClientBounds.Height);
            Components.Add(new TowerControls(this));
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = spriteBatch;
            Globals.Content = Content;
            Globals.GameWindow = Window;
            Globals.GraphicsDevice = GraphicsDevice;
            CurrentState = GameState.StartMenu;
            MediaPlayer.Play(mainTheme);
            MediaPlayer.Volume = 0.3f;

            //Dictionary that handles the gamestates, using polymorphism for the different classes that are representing the gamestates.
            stateHandler = new Dictionary<GameState, IStateHandler> 
            {
                { GameState.StartMenu, new IStateStartMenu() },
                { GameState.Playing, new IStatePlaying() },
                { GameState.GameOver, new IStateGameOver() }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MediaPlayer.IsRepeating = true;
            Globals.Update(gameTime);
            MouseInputManager.Update();
            ParticleSystem.Update();
            stateHandler[CurrentState].Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            stateHandler[CurrentState].Draw();

            base.Draw(gameTime);
        }

        public void Restart()
        {
            LoadContent();
        }
    }
}
