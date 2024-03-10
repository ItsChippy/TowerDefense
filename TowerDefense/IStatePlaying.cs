using System;
using System.Collections.Generic;
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
        
        public IStatePlaying()
        {
            state = PlayState.NextTurn;
            mapBackground = Globals.Content.Load<Texture2D>("mapbackground");
            enemyPath = new EnemyPath();
            enemyGenerator = new EnemyGenerator(enemyPath.path);       
        }

        public override void Update()
        {
            Game1.Self.IsMouseVisible = true;
            enemyGenerator.UpdateWave1();
        }

        public override void Draw()
        {
            DrawOnRenderTarget();

            Globals.SpriteBatch.Begin();
            
            Globals.SpriteBatch.Draw(mapBackground, Vector2.Zero, Color.White);
            Globals.SpriteBatch.Draw(Game1.RenderTarget, Vector2.Zero, Color.White);
            enemyGenerator.DrawWave1();
            
            Globals.SpriteBatch.End();
        }

        private void DrawOnRenderTarget()
        {
            Globals.GraphicsDevice.SetRenderTarget(Game1.RenderTarget);
            Globals.GraphicsDevice.Clear(Color.Transparent);
            Globals.SpriteBatch.Begin();
            enemyPath.Draw();
            Globals.SpriteBatch.End();

            Globals.GraphicsDevice.SetRenderTarget(null);
        }
    }
}
