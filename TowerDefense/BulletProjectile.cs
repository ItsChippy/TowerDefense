using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class BulletProjectile : TowerProjectile
    {

        public BulletProjectile(Vector2 position, BaseEnemy target)
        {
            texture = Globals.Content.Load<Texture2D>(@"projectile");
            this.position = position;
            this.target = target;
            damage = 15;
            isSlowShot = false;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public override void Update()
        {
           MoveToTarget();
        }

        public override void Draw()
        {
            Vector2 directionVec = target.position - position;
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            float rotation = (float)Math.Atan2(directionVec.Y, directionVec.X);

            Globals.SpriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 1f);
        }
    }
}
