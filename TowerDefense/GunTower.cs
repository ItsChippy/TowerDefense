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
            //checks collision and removes bullets that have it
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

            //updates all shots
            foreach(var shot in shotProjectiles)
            {
                shot.Update();
            }

            //if no enemies are present, target becomes null
            if (enemies == null || enemies.Length == 0)
            {
                target = null;
                return;
            }

            //Looks for a new target if there is no current target or the target went out of range
            if (target == null || Vector2.Distance(position, target.position) > range)
            {
                target = GetClosestEnemy(enemies);
            }

            //rotates towards its current target
            if (target != null)
            {
                Vector2 calcVector = position - target.position;
                rotation = (float)Math.Atan2(calcVector.Y, calcVector.X) - (float)Math.PI / 2;
                ShootProjectile();
            }
        }

        //handles the shooting
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

            IndicatePlacement(this);
            Globals.SpriteBatch.Draw(texture, position + origin, null, color, rotation, origin, 1f, SpriteEffects.None, 0.9f);

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
