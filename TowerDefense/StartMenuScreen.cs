using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class StartMenuScreen
    {

        MenuButton playButton;
        MenuButton exitButton;

        GameTitle gameTitle;
        Texture2D menuBackground;

        MouseEmitter mouseEmitter = new();
        public StartMenuScreen()
        {
            gameTitle = new GameTitle();

            playButton = new MenuButton("playbutton");
            playButton.ChangePosition(new Vector2(0, 350));

            exitButton = new MenuButton("exitbutton");
            exitButton.ChangePosition(new Vector2(0, 450));

            menuBackground = Globals.Content.Load<Texture2D>("spacebackground");

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
            playButton.Update();
            exitButton.Update();
            if (playButton.IsSelected) Game1.CurrentState = GameState.Playing;
            if (exitButton.IsSelected) Game1.Self.Exit();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(menuBackground, Vector2.Zero, Color.White);
            gameTitle.Draw();
            playButton.Draw();
            exitButton.Draw();
            ParticleSystem.Draw();
        }
    }
}
