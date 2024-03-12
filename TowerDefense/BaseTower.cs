﻿using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class BaseTower
    {
        protected Texture2D texture;
        protected SoundEffect shoot;
        protected Vector2 position;
        protected int range;
        protected float attackSpeed;
        protected float ShotCooldown;
        protected Rectangle hitbox;
        protected float rotation;
        protected List<TowerProjectile> shotProjectiles;
        protected BaseEnemy target;

        protected void GetHitBox()
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void UpdatePosition(Vector2 position)
        {
            this.position = position;
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public static bool CanPlace(BaseTower tower)
        {
            Color[] pixels = new Color[tower.texture.Width * tower.texture.Height];
            Color[] pixels2 = new Color[tower.texture.Width * tower.texture.Height];
            tower.texture.GetData(pixels2);
            if (Globals.GameWindow.ClientBounds.Contains(tower.hitbox))
            {
                Globals.GraphicsDevice.SetRenderTarget(Game1.RenderTarget);
                Game1.RenderTarget.GetData(0, tower.hitbox, pixels, 0, pixels.Length);
                Globals.GraphicsDevice.SetRenderTarget(null);
            }
            for (int i = 0; i < pixels.Length; i++)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                {
                    return false;
                }
            }

            return true;
        }

        protected BaseEnemy GetClosestEnemy(BaseEnemy[] enemies)
        {
            BaseEnemy closestEnemy = null;

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    Vector2 newVector = enemies[i].position - position;
                    float distanceToTarget = (float)Math.Sqrt(Math.Pow(newVector.X, 2) + Math.Pow(newVector.Y, 2));

                    if (distanceToTarget <= range)
                    {
                        closestEnemy = enemies[i];
                        break;
                    }
                    else
                    {
                        closestEnemy = null;
                    }
                }
            }
            return closestEnemy;
        }

        public abstract void Update(BaseEnemy[] enemies);

        public abstract void Draw();
    }
}
