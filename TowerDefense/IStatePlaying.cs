using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public enum PlayState
    {
        Round1,
        NextTurn,
        Round2,
        Paused,
    }
    internal class IStatePlaying : IStateHandler
    {
        public static PlayState state;
        Texture2D mapBackground;
        EnemyPath enemyPath;
        EnemyGenerator enemyGenerator;
        Resources resources;
        TowerPlacer placer;

        public IStatePlaying()
        {
            mapBackground = Globals.Content.Load<Texture2D>("mapbackground");
            enemyPath = new EnemyPath();
            enemyGenerator = new EnemyGenerator(enemyPath.path);  
            resources = new Resources();
            placer = new TowerPlacer();
            state = PlayState.NextTurn;
            DrawOnRenderTarget();
        }

        public override void Update()
        {
            if (Resources.GetHealth() <= 0)
            {
                IStateGameOver.hasWon = false;
                Game1.CurrentState = GameState.GameOver;
            }
            switch (state)
            {
                case PlayState.Round1:
                    enemyGenerator.UpdateWave1();
                    if(enemyGenerator.CheckIfRoundIsOver(enemyGenerator.enemyWave1))
                    {
                        enemyGenerator.WaitForNextRound(PlayState.Round2);
                    }
                    break;
                case PlayState.Round2:
                    enemyGenerator.UpdateWave2();
                    if (enemyGenerator.CheckIfRoundIsOver(enemyGenerator.enemyWave2))
                    {
                        IStateGameOver.hasWon = true;
                        Game1.CurrentState = GameState.GameOver;
                    }
                    break;
                case PlayState.NextTurn:
                    enemyGenerator.WaitForNextRound(PlayState.Round1);
                    break;
            }
            ParticleSystem.Update();
            placer.Update(enemyGenerator.enemyWave1);
            placer.Update(enemyGenerator.enemyWave2);
        }

        public override void Draw()
        {
            DrawOnRenderTarget();
            Globals.SpriteBatch.Begin(SpriteSortMode.FrontToBack);
            switch(state)
            {
                case PlayState.Round1:
                    enemyGenerator.DrawWave1();
                    break;
                case PlayState.Round2:
                    enemyGenerator.DrawWave2();
                    break;
            }
            enemyGenerator.DrawNextRoundText();
            ParticleSystem.Draw();
            Globals.SpriteBatch.Draw(mapBackground, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Globals.SpriteBatch.Draw(Game1.RenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.9f);
            placer.DrawSelectedTower();
            resources.Draw();
            
            Globals.SpriteBatch.End();
        }

        private void DrawOnRenderTarget()
        {
            Globals.GraphicsDevice.SetRenderTarget(Game1.RenderTarget);
            Globals.GraphicsDevice.Clear(Color.Transparent);
            
            Globals.SpriteBatch.Begin(SpriteSortMode.FrontToBack);
            
            enemyPath.Draw();
            placer.DrawPlacedTowers();

            Globals.SpriteBatch.End();

            Globals.GraphicsDevice.SetRenderTarget(null);
        }
    }
}
