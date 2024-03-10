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
        protected int health;
        protected int damage;
        protected float speed;
        protected float rotationAngle;

        public abstract void Update(SimplePath path);
        public abstract void Draw();
    }
}
