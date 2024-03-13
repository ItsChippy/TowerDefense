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
        private bool soundPlayed;
        private SoundEffect winSound;
        private GameOverScreen gameOverScreen;
        
        public IStateGameOver() 
        {
            gameOverScreen = new GameOverScreen();
            winSound = Globals.Content.Load<SoundEffect>(@"winsound");
            soundPlayed = false;
        }

        public override void Update()
        {
            if(hasWon && !soundPlayed) 
            {
                var instance = winSound.CreateInstance();
                instance.Volume = 1.0f;
                MediaPlayer.Pause();
                instance.Play();
                soundPlayed = true;
            }
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
