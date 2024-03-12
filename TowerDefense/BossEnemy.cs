using Spline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class BossEnemy : BaseEnemy
    {
        bool dealtDamage;
        EnemyHealthBar ehb;
        SoundEffect spawnSound;
        bool playedSound;
        public BossEnemy(Vector2 position)
        {
            texture = Globals.Content.Load<Texture2D>(@"bossenemy");
            spawnSound = Globals.Content.Load<SoundEffect>(@"bossound");
            health = 1500;
            speed = 0.75f;
            damage = 100;
            dealtDamage = false;
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            isDead = false;
            playedSound = false;
            ehb = new EnemyHealthBar(health, new Vector2(position.X, position.Y - 20));
        }

        public override void Update(SimplePath path)
        {
            var instance = spawnSound.CreateInstance();
            if(!playedSound)
            {
                instance.Volume = 1f;
                instance.Play();
                playedSound = true;
            }
            if(health < 0)
            {
                instance.Play();
                Resources.AddGold(2000);
                position = new Vector2(1000, 1000);
                isDead = true;
            }
            if (CheckForOutOfBounds() && !dealtDamage)
            {
                Resources.healthUpdate(damage);
                position = new Vector2(1000, 1000);
                dealtDamage = true;
            }
            int currentPointIndex = FindNearestPathIndex(path);
            Vector2 nextPoint = path.GetPos(Math.Min(currentPointIndex + 1, path.AntalPunkter - 1));
            Vector2 direction = Vector2.Normalize(nextPoint - position);
            rotationAngle = (float)Math.Atan2(nextPoint.Y - position.Y, nextPoint.X - position.X);

            position += direction * speed;
            ehb.Update(health, new Vector2(position.X + texture.Width / 2, position.Y - 20));
            UpdateHitboxPosition();
        }

        public override void Draw()
        {
            Vector2 drawPosition = new Vector2(position.X - texture.Width / 2, position.Y - texture.Height / 2) + origin;
            ehb.Draw();
            Globals.SpriteBatch.Draw(texture, drawPosition, null, Color.White, rotationAngle, origin, 1f, SpriteEffects.None, 1f);
        }
    }
}
