using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class SlowTower : BaseTower
    {

        public SlowTower(Vector2 position) 
        {
            texture = Globals.Content.Load<Texture2D>(@"slowtower");
            shoot = Globals.Content.Load<SoundEffect>(@"slowgun");
            SoundEffect.MasterVolume = 0.05f;
            this.position = position;
            attackSpeed = 1.2f;
            ShotCooldown = attackSpeed;
            range = 200;
            shotProjectiles = new List<TowerProjectile>();
            GetHitBox();
        }

        public override void Update(BaseEnemy[] enemies)
        {
            //Collision for the shots/projectiles
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

            foreach(var shot in  shotProjectiles) 
            {
                shot.Update();
            }

            //if no enemies are present on the path
            if (enemies == null || enemies.Length == 0)
            {
                target = null;
                return;
            }

            //if target is out of range or dead
            if (target == null || Vector2.Distance(position, target.position) > range)
            {
                target = GetClosestEnemy(enemies);
            }

            //Rotates after the target and fires
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
                    shotProjectiles.Add(new SlowProjectile(new Vector2(position.X + texture.Width / 2, position.Y + texture.Width / 2), target));
                    shoot.Play();
                }
            }
        }

        public override void Draw()
        {
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

            Globals.SpriteBatch.Draw(texture, position + origin, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0.9f);

            if (target != null && shotProjectiles.Count > 0)
            {
                foreach (var shot in shotProjectiles)
                {
                    shot.Draw();
                }
            }
        }
    }
}
