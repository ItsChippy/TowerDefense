using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class PathPanel
    {

        Texture2D texture;
        Vector2 position;
        Vector2 origin;

        public PathPanel(Vector2 position)
        {
            texture = Globals.Content.Load<Texture2D>("path_panel");
            this.position = position;
            this.position = new Vector2(position.X - texture.Width / 2, position.Y - texture.Height / 2); //centers the panel on the path
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Draw(float rotationAngle)
        {
            Globals.SpriteBatch.Draw(texture, position + origin, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
