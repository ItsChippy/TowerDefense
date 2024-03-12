using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class GameOverScreen
    {
        MenuButton restartButton;
        MenuButton exitButton;

        GameTitle gameTitle;
        Texture2D menuBackground;

        string winText = $"YOU SAVED THE GALAXY!";
        string loseText = $"THE GALAXY IS DESTROYED!";
        SpriteFont font;
        MouseEmitter mouseEmitter = new();
        
        public GameOverScreen() 
        {
            gameTitle = new GameTitle();

            restartButton = new MenuButton("resetbutton");
            restartButton.ChangePosition(new Vector2(0, 300));

            exitButton = new MenuButton("exitbutton");
            exitButton.ChangePosition(new Vector2(0, 450));

            menuBackground = Globals.Content.Load<Texture2D>("spacebackground");
            font = Globals.Content.Load<SpriteFont>("menufont");

            ParticleEmitterData mousePed = new()
            {
                Interval = 0.01f,
                EmitCount = 10,
                AngleVariance = 360f,
                LifespanMin = 0.5f,
                LifespanMax = 0.5f,
                particleData = new()
                {
                    ColorStart = Color.White,
                    ColorEnd = Color.DeepPink,
                    SizeStart = 5f,
                    SizeEnd = 10f,
                }
            };

            ParticleEmitter pe = new(mouseEmitter, mousePed);
            ParticleSystem.AddParticleEmitter(pe);
        }
        
        public void Update()
        {
            Game1.Self.IsMouseVisible = false;
            restartButton.Update();
            exitButton.Update();
            if (restartButton.IsSelected)
            {
                Game1.Self.Restart();
            }
            if (exitButton.IsSelected) Game1.Self.Exit();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(menuBackground, Vector2.Zero, Color.White);
            if (IStateGameOver.hasWon)
            {
                Globals.SpriteBatch.DrawString(font, winText, new Vector2(100, 200), Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            }
            else
            {
                Globals.SpriteBatch.DrawString(font, loseText, new Vector2(100, 200), Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            }
            Globals.SpriteBatch.DrawString(font, $"Points: {Resources.GetGold()}", new Vector2(280, 260), Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            gameTitle.Draw();
            restartButton.Draw();
            exitButton.Draw();
            ParticleSystem.Draw();
        }
    }
}
