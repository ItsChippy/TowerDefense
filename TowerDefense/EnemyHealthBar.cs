using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class EnemyHealthBar
    {
        int maxHealth;
        Vector2 position;
        int currentHealth;
        SpriteFont font;
        string healthString;
        
        public EnemyHealthBar(int health, Vector2 position) 
        {
            this.position = position;
            maxHealth = health;
            currentHealth = health;
            font = Globals.Content.Load<SpriteFont>("defaultFont");
        }

        public void Update(int health, Vector2 position)
        {
            currentHealth = health;
            this.position = position;
        }

        public void Draw()
        {
            healthString = $"{currentHealth} / {maxHealth}";
            Vector2 textMiddlePoint = font.MeasureString(healthString);
            Globals.SpriteBatch.DrawString(font, healthString, position, Color.White, 0f, textMiddlePoint, 0.6f, SpriteEffects.None, 1f);
        }
    }
}
