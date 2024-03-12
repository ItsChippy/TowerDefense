using Spline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class BaseEnemy
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 origin;
        protected Rectangle hitbox;
        protected int health;
        protected int damage;
        protected float speed;
        protected float rotationAngle;

        public abstract void Update(SimplePath path);
        public abstract void Draw();

        protected void UpdateHitboxPosition()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        protected bool CheckForOutOfBounds()
        {
            if(position.Y > 610) //game window height is default set to 600
            {
                return true;
            }
            return false;
        }
    }
}
