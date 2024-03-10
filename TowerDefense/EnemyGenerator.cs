using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Spline;

namespace TowerDefense
{
    internal class EnemyGenerator
    {
        Vector2 startingPosition;
        double updateInterval = 1000;
        double elapsedTime = 0;
        CommonEnemy[] enemyWave1;
        SimplePath enemyPath;
        
        public EnemyGenerator(SimplePath enemyPath)
        {
            this.enemyPath = enemyPath;
            enemyWave1 = new CommonEnemy[10];
            startingPosition = enemyPath.GetPos(0);
            SetEnemyWave1();
        }

        private void SetEnemyWave1()
        {
            for (int i = 0; i < enemyWave1.Length; i++)
            {
                enemyWave1[i] = new CommonEnemy(startingPosition);
            }
        }

        public void UpdateWave1()
        {
            elapsedTime += Globals.DeltaTime;

            for(int i = 0; i < enemyWave1.Length; i++)
            {
                if (elapsedTime >= i * updateInterval)
                {
                    BaseEnemy enemy = enemyWave1[i];
                    enemy.Update(enemyPath);
                }
            }
        }

        public void DrawWave1()
        {
            foreach (BaseEnemy enemy in enemyWave1)
            {
                enemy.Draw();
            }
        }
    }
}
