using Spline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class CommonEnemy : BaseEnemy
    {
        EnemyHealthBar ehb;
        StaticEmitter emitter;
        ParticleEmitter explosion;
        ParticleEmitterData explosionData;
        public CommonEnemy(Vector2 position)
        {
            texture = Globals.Content.Load<Texture2D>("commonenemy");
            health = 120;
            speed = 1.3f;
            damage = 10;
            dealtDamage = false;
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            isDead = false;
            ehb = new EnemyHealthBar(health, new Vector2(position.X, position.Y - 10));
            slowInterval = slowTimer;
        }

        public override void Update(SimplePath path)
        {
            if (health <= 0 && !isDead) //if enemy is dead
            {
                CreateParticleExplosion();
                ParticleSystem.AddParticleEmitter(explosion);
                Resources.AddGold(30);
                position = new Vector2(1000, 1000);
                isDead = true;
            }
            if (CheckForOutOfBounds() && !dealtDamage && !isDead) //has reached the end of the path
            {
                Resources.healthUpdate(damage);
                position = new Vector2(1000, 1000);
                dealtDamage = true;
            }

            //Gets the next node in the path, calculates the direction and rotates accordingly
            int currentPointIndex = FindNearestPathIndex(path);
            Vector2 nextPoint = path.GetPos(Math.Min(currentPointIndex + 1, path.AntalPunkter - 1));
            Vector2 direction = Vector2.Normalize(nextPoint - position);
            rotationAngle = (float)Math.Atan2(nextPoint.Y - position.Y, nextPoint.X - position.X);
           
            position += direction * speed;
            ehb.Update(health, new Vector2(position.X + texture.Width / 2, position.Y - 20));
            UpdateHitboxPosition();
            SlowMovementSpeed();
        }

        public override void Draw()
        {
            Vector2 drawPosition = new Vector2(position.X - texture.Width / 2, position.Y - texture.Height / 2) + origin;
            ehb.Draw();
            Globals.SpriteBatch.Draw(texture, drawPosition, null,  Color.White, rotationAngle, origin, 1f, SpriteEffects.None, 1f);
        }

        private void CreateParticleExplosion() //creates the explosion present when the enemy dies
        {
            emitter = new(position);

            explosionData = new()
            {
                Interval = 2f,
                EmitCount = 150,
                AngleVariance = 180f,
                LifespanMin = 0f,
                LifespanMax = 0f,
                SpeedMin = 100f,
                SpeedMax = 100f,
                particleData = new()
                {
                    ColorStart = Color.LightBlue,
                    ColorEnd = Color.White,
                    SizeStart = 8,
                    SizeEnd = 48
                }
            };

            explosion = new(emitter, explosionData);
        }
    }
}
