using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public enum PlayState
    {
        NextTurn,
        Playing,
        Paused
    }
    internal class IStatePlaying : IStateHandler
    {
        PlayState state;
        Texture2D mapBackground;
        EnemyPath enemyPath;
        CommonEnemy enemy;
        
        public IStatePlaying()
        {
            state = PlayState.NextTurn;
            mapBackground = Globals.Content.Load<Texture2D>("mapbackground");
            enemyPath = new EnemyPath();
            enemy = new CommonEnemy(enemyPath.path.GetPos(0));
        }

        public override void Update()
        {
            Game1.Self.IsMouseVisible = true;
            enemy.Update(enemyPath.path);
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(mapBackground, Vector2.Zero, Color.White);
            enemyPath.Draw();
            enemy.Draw();
        }
    }
}
