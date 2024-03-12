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
        PlayState state;
        Texture2D mapBackground;
        EnemyPath enemyPath;
        EnemyGenerator enemyGenerator;
        Resources resources;
        TowerPlacer placer;

        public IStatePlaying()
        {
            //state = PlayState.NextTurn;
            mapBackground = Globals.Content.Load<Texture2D>("mapbackground");
            enemyPath = new EnemyPath();
            enemyGenerator = new EnemyGenerator(enemyPath.path);  
            resources = new Resources();
            placer = new TowerPlacer();
            DrawOnRenderTarget();
        }

        public override void Update()
        {
            switch (state)
            {
                case PlayState.Round1:
                    enemyGenerator.UpdateWave1();
                    break;
                case PlayState.Round2:
                    break;
                case PlayState.NextTurn:
                    break;
            }
           placer.Update();
           Game1.Self.IsMouseVisible = true;
           enemyGenerator.UpdateWave1();
        }

        public override void Draw()
        {
            DrawOnRenderTarget();
            Globals.SpriteBatch.Begin(SpriteSortMode.FrontToBack);
            
            Globals.SpriteBatch.Draw(mapBackground, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Globals.SpriteBatch.Draw(Game1.RenderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.9f);
            placer.DrawSelectedTower();
            enemyGenerator.DrawWave1();
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
