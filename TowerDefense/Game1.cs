using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Globals.SpriteBatch = spriteBatch;
            Globals.Content = Content;
            Globals.GameWindow = Window;
            Globals.GraphicsDevice = GraphicsDevice;
            CurrentState = GameState.Playing;

            stateHandler = new Dictionary<GameState, IStateHandler>
            {
                { GameState.StartMenu, new IStateStartMenu() },
                { GameState.Playing, new IStatePlaying() }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Globals.Update(gameTime);
            MouseInputManager.Update();
            ParticleSystem.Update();

            stateHandler[CurrentState].Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            stateHandler[CurrentState].Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
