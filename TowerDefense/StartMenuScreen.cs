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

        Button playButton;
        Button exitButton;
        Button settingsButton;

        GameTitle gameTitle;
        Texture2D menuBackground;

        MouseEmitter mouseEmitter = new();
        public StartMenuScreen()
        {
            gameTitle = new GameTitle();

            playButton = new Button("playbutton");
            playButton.ChangePosition(new Vector2(0, 250));

            exitButton = new Button("exitbutton");
            exitButton.ChangePosition(new Vector2(0, 450));

            settingsButton = new Button("settingsbutton");
            settingsButton.ChangePosition(new Vector2(0, 350));

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
            settingsButton.Update();
            exitButton.Update();
            if (playButton.IsSelected) Game1.CurrentState = GameState.Playing;
            if (exitButton.IsSelected) Game1.Self.Exit();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(menuBackground, Vector2.Zero, Color.White);
            gameTitle.Draw();
            playButton.Draw();
            settingsButton.Draw();
            exitButton.Draw();
            ParticleSystem.Draw();
        }
    }
}
