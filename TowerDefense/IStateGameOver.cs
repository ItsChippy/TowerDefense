using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class IStateGameOver : IStateHandler
    {
        public static bool hasWon;
        private GameOverScreen gameOverScreen;
        
        public IStateGameOver() 
        {
            gameOverScreen = new GameOverScreen();
        }

        public override void Update()
        {
            gameOverScreen.Update();
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Begin();

            gameOverScreen.Draw();

            Globals.SpriteBatch.End();
        }
    }
}
