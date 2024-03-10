using Spline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TowerDefense.Content;

namespace TowerDefense
{
    internal class CommonEnemy : BaseEnemy
    {
        bool isAtEnd;
        public CommonEnemy(Vector2 position)
        {
            texture = Globals.Content.Load<Texture2D>("commonenemy");
            health = 100;
            speed = 2f;
            damage = 10;
            this.position = position;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public override void Update(SimplePath path)
        {
            if (isAtEnd)
            {
                Resources.healthUpdate(damage);
                position = new Vector2(1000, 1000);
                Debug.WriteLine($"Got to the end {position}");
            }
            if (position == path.GetPos(path.endT))
            {
                isAtEnd = true;
            }
            
            int currentPointIndex = FindNearestPathIndex(path);
            Vector2 nextPoint = path.GetPos(Math.Min(currentPointIndex + 1, path.AntalPunkter - 1));
            Vector2 direction = Vector2.Normalize(nextPoint - position);
            rotationAngle = (float)Math.Atan2(nextPoint.Y - position.Y, nextPoint.X - position.X);
           
            position += direction * speed;
        }

        private int FindNearestPathIndex(SimplePath path)
        {
            float minDistance = float.MaxValue;
            int nearestIndex = 0;

            for (int i = 0; i < path.AntalPunkter; i++)
            {
                float distance = Vector2.DistanceSquared(position, path.GetPos(i));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestIndex = i;
                }
            }
            return nearestIndex;
        }

        public override void Draw()
        {
            if (isAtEnd)
            {
                return;
            }
            Vector2 drawPosition = new Vector2(position.X - texture.Width / 2, position.Y - texture.Height / 2) + origin;
            Globals.SpriteBatch.Draw(texture, drawPosition, null,  Color.White, rotationAngle, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
