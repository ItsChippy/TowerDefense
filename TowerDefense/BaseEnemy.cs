using SharpDX.DirectWrite;
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
        public Vector2 position { get; protected set; }
        protected Vector2 origin;
        public Rectangle hitbox;
        protected int health;
        protected int damage;
        protected float speed;
        protected float rotationAngle;
        protected float slowTimer = 2f;
        protected float slowInterval;

        public bool isSlow;
        public bool dealtDamage { get; protected set; }
        public bool isDead;

        public abstract void Update(SimplePath path);
        public abstract void Draw();

        protected void UpdateHitboxPosition()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public bool CheckForOutOfBounds()
        {
            if(position.Y > 610) //game window height is default set to 600
            {
                return true;
            }
            return false;
        }

        protected int FindNearestPathIndex(SimplePath path)
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

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void SlowMovementSpeed()
        {
            if (this is BossEnemy)
            {
                return;
            }

            if (isSlow)
            {
                speed = 0.7f;
                slowTimer -= Globals.DeltaTimeSeconds;

                if (slowTimer <= 0)
                {
                    slowTimer = slowInterval;
                    speed = 1.3f;
                    isSlow = false;
                }
            }
        }
    }
}
