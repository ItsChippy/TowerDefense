using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class TowerProjectile
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected BaseEnemy target;
        protected const float SPEED = 20f;
        protected int damage;
        protected Rectangle hitbox;
        protected bool isSlowShot;

        protected void MoveToTarget()
        {
            Vector2 direction = target.position - position;
            direction.Normalize();

            position.X += direction.X * SPEED;
            position.Y += direction.Y * SPEED;
            MoveHitBox();
        }

        public bool HasCollidedWithTarget()
        {
            if (target.hitbox.Intersects(hitbox))
            {
                target.TakeDamage(damage);

                if(isSlowShot)
                {
                    target.isSlow = true;
                }
                return true;
            }
            return false;
        }

        protected void MoveHitBox()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public abstract void Update();
        public abstract void Draw();
    }

}
