using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class Resources
    {
        private static int health;
        private static int gold;
        private Texture2D heartTexture;
        private SpriteFont font;
        private Vector2 position;

        internal delegate void TakeDamage(int damage);
        public static TakeDamage healthUpdate;
        public Resources()
        {
            font = Globals.Content.Load<SpriteFont>(@"resourcefont");
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
            Vector2 textMiddlePoint = font.MeasureString(health.ToString());

            Globals.SpriteBatch.Draw(heartTexture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            Globals.SpriteBatch.DrawString(font, health.ToString(), new Vector2(position.X + heartTexture.Width * 3, heartTexture.Height + 5), Color.White, 0f, textMiddlePoint, 1.3f, SpriteEffects.None, 1f);
        }
    }
}
