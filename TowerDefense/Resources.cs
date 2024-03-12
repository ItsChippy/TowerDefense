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
        private Texture2D heartTexture, goldTexture;
        private SpriteFont font;
        private Vector2 position;

        internal delegate void TakeDamage(int damage);
        public static TakeDamage healthUpdate;
        public Resources()
        {
            font = Globals.Content.Load<SpriteFont>(@"resourcefont");
            health = 100;
            gold = 200;
            heartTexture = Globals.Content.Load<Texture2D>(@"heart");
            goldTexture = Globals.Content.Load<Texture2D>(@"goldcoin");
            healthUpdate = TakeDamageDelegate;
        }

        private static void TakeDamageDelegate(int damage)
        {
            health -= damage;
        }

        public static void RemoveGold(int cost)
        {
            gold -= cost;
        }

        public static void AddGold(int cost)
        {
            gold += cost;
        }

        public static int GetHealth()
        {
            return health;
        }

        public static int GetGold()
        {
            return gold;
        }

        public void Draw()
        {
            Vector2 textMiddlePoint = font.MeasureString(health.ToString());

            Globals.SpriteBatch.Draw(heartTexture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            Globals.SpriteBatch.DrawString(font, health.ToString(), new Vector2(position.X + heartTexture.Width * 3, heartTexture.Height + 5), Color.White, 0f, textMiddlePoint, 1.3f, SpriteEffects.None, 1f);

            Vector2 goldTextMiddlePoint = font.MeasureString(gold.ToString());
            
            Globals.SpriteBatch.Draw(goldTexture, new Vector2(0, 30), null, Color.White, 0f, Vector2.Zero, 1.3f, SpriteEffects.None, 1f);
            Globals.SpriteBatch.DrawString(font, gold.ToString(), new Vector2(position.X + goldTexture.Width * 3, 55), Color.White, 0f, goldTextMiddlePoint, 1.3f, SpriteEffects.None, 1f);

        }
    }
}
