using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class GunTower : BaseTower
    {

        public GunTower(Vector2 position)
        {
            texture = Globals.Content.Load<Texture2D>(@"guntower");
            shoot = Globals.Content.Load<SoundEffect>(@"lasergun");
            SoundEffect.MasterVolume = 0.05f;
            this.position = position;
            range = 150;
            attackSpeed = 0.8f;
            ShotCooldown = attackSpeed;
            shotProjectiles = new List<TowerProjectile>();
            GetHitBox();
        }

        public override void Update(BaseEnemy[]enemies)
        {
            for (int i = 0; i < shotProjectiles.Count; i++)
            {
                if (shotProjectiles[i] != null)
                {
                    if (shotProjectiles[i].HasCollidedWithTarget())
                    {
                        shotProjectiles.RemoveAt(i);
                    }
                }
            }

            foreach(var shot in shotProjectiles)
            {
                shot.Update();
            }

            if (enemies == null || enemies.Length == 0)
            {
                target = null;
                return;
            }

            if (target == null || Vector2.Distance(position, target.position) > range)
            {
                target = GetClosestEnemy(enemies);
            }

            if (target != null)
            {
                Vector2 calcVector = position - target.position;
                rotation = (float)Math.Atan2(calcVector.Y, calcVector.X) - (float)Math.PI / 2;
                ShootProjectile();
            }
        }

        private void ShootProjectile()
        {
            attackSpeed -= Globals.DeltaTimeSeconds;

            if (attackSpeed < 0)
            {
                attackSpeed = ShotCooldown;

                if (target != null)
                {
                    shotProjectiles.Add(new BulletProjectile(new Vector2(position.X + texture.Width / 2, position.Y + texture.Width / 2), target));
                    shoot.Play();
                }
            }
        }

        public override void Draw()
        {
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

            Globals.SpriteBatch.Draw(texture, position + origin, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0.9f);

            if (shotProjectiles.Count > 0 ) 
            {
                foreach(var shot in shotProjectiles) 
                {
                    shot.Draw();
                }
            }
        }
    }
}
