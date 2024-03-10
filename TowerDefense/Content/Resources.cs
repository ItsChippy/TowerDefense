using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Content
{
    internal class Resources
    {
        private static int health;
        private static int gold;
        private Texture2D heartTexture;
        private SpriteFont spriteFont;
        private Vector2 position;

        internal delegate void TakeDamage(int damage);
        public static TakeDamage healthUpdate;
        public Resources ()
        {
            health = 100;
            gold = 0;
            heartTexture = Globals.Content.Load<Texture2D>(@"heart");
            healthUpdate = TakeDamageDelegate;
        }

        private static void TakeDamageDelegate(int damage)
        {
            health -= damage;
        }

        public void Draw()
        {
            
        }
    }
}
