using Spline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class CommonEnemy : BaseEnemy
    {
        float count;
        bool isAtEnd;

        public CommonEnemy(Vector2 position)
        {
            texture = Globals.Content.Load<Texture2D>("commonenemy");
            health = 100;
            speed = 5f;
            this.position = position;
        }

        public override void Update(SimplePath path)
        {
            if (count == path.endT)
            {
                isAtEnd = true;
                return;
            }
            position = path.GetPos(count);
            count++;
        }

        public override void Draw()
        {
            if (isAtEnd)
            {
                return;
            }
            Globals.SpriteBatch.Draw(texture, new Vector2(position.X - texture.Width / 2, position.Y - texture.Height / 2), null,  Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
