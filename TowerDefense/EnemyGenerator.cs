using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace TowerDefense
{
    internal class EnemyGenerator
    {
        string nextRoundText = "PRESS ENTER FOR NEXT ROUND";
        SpriteFont font;
        bool waitingForNextRound;
        Vector2 startingPosition;
        double updateInterval = 1000;
        double elapsedTimeWave1 = 0;
        double elapsedTimeWave2 = 0;
        public BaseEnemy[] enemyWave1 { get; private set; }
        public BaseEnemy[] enemyWave2 { get; private set; }
        SimplePath enemyPath;
        
        public EnemyGenerator(SimplePath enemyPath)
        {
            font = Globals.Content.Load<SpriteFont>(@"menufont");
            this.enemyPath = enemyPath;
            enemyWave1 = new CommonEnemy[10];
            enemyWave2 = new BaseEnemy[9];
            startingPosition = enemyPath.GetPos(0);
            SetEnemyWave1();
            SetEnemyWave2();
        }

        //Checks if all the enemies in the current round are dead or reached the end of the path
        public bool CheckIfRoundIsOver(BaseEnemy[]enemyWave)
        {
            for (int i = 0; i < enemyWave.Length; i++)
            {
                if (!enemyWave[i].CheckForOutOfBounds())
                {
                    return false;
                }
            }
            return true;
        }

        //Transitions to the next round when player has pressed Enter
        public void WaitForNextRound(PlayState state)
        {
            KeyboardState keys = Keyboard.GetState();
            waitingForNextRound = true;
            if (keys.IsKeyDown(Keys.Enter))
            {
                waitingForNextRound = false;
                IStatePlaying.state = state;
            }
        }

        public void DrawNextRoundText()
        {
            if (waitingForNextRound)
            {
                Globals.SpriteBatch.DrawString(font, nextRoundText, new Vector2(50, 100), Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1f);
            }
        }

        //Initializes Round 2
        private void SetEnemyWave2()
        {
            for (int i = 0;  i < enemyWave2.Length; i++)
            {
                enemyWave2[i] = new CommonEnemy(startingPosition);
            }
            enemyWave2[3] = new BossEnemy(startingPosition);
        }

        public void UpdateWave2()
        {
            elapsedTimeWave2 += Globals.DeltaTime;

            for (int i = 0; i < enemyWave2.Length; i++)
            {
                if (elapsedTimeWave2 >= i * updateInterval)
                {
                    BaseEnemy enemy = enemyWave2[i];
                    if (!enemy.isDead || !enemy.dealtDamage)
                    {
                        enemy.Update(enemyPath);
                    }
                }
            }
        }

        public void DrawWave2()
        {
            foreach (BaseEnemy enemy in enemyWave2)
            {
                if (!enemy.isDead || !enemy.dealtDamage)
                {
                    enemy.Draw();
                }
            }
        }

        //Initializes Round 1
        private void SetEnemyWave1()
        {
            for (int i = 0; i < enemyWave1.Length; i++)
            {
                enemyWave1[i] = new CommonEnemy(startingPosition);
            }
        }

        public void UpdateWave1()
        {
            elapsedTimeWave1 += Globals.DeltaTime;

            for(int i = 0; i < enemyWave1.Length; i++)
            {
                if (elapsedTimeWave1 >= i * updateInterval)
                {
                    BaseEnemy enemy = enemyWave1[i];
                    if (!enemy.isDead || !enemy.dealtDamage)
                    {
                        enemy.Update(enemyPath);
                    }
                }
            }
        }

        public void DrawWave1()
        {
            foreach (BaseEnemy enemy in enemyWave1)
            {
                if (!enemy.isDead || !enemy.dealtDamage)
                {
                    enemy.Draw();
                }
            }
        }

    }
}
