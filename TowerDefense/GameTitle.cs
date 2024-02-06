using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class GameTitle
    {
        SpriteFont font;
        
        string titleString;
        Vector2 titleTextPos;
        Vector2 textMiddlePoint;

        public GameTitle()
        {
            font = Globals.Content.Load<SpriteFont>("menufont");

            titleString = "SPACE DEFENSE";
            titleTextPos = new Vector2(400, 100);
            textMiddlePoint = font.MeasureString(titleString) / 2;
        }

        public void Draw()
        {
            Globals.SpriteBatch.DrawString(font, titleString, titleTextPos, Color.White, 0f, textMiddlePoint, 1f, SpriteEffects.None, 1f);
        }
    }
}
