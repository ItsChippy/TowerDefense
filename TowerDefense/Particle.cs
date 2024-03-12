using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class Particle
    {
        private ParticleData data;
        private Vector2 pos;
        private float lifespanLeft;
        private float lifespanAmount;
        private Color color;
        private float opacity;
        public bool IsFinished = false;
        public float Scale;
        private Vector2 origin;
        private Vector2 direction;
        public Particle(Vector2 pos, ParticleData data)
        {
            this.data = data;
            this.pos = pos;
            lifespanLeft = data.LifeSpan;
            lifespanAmount = 1f;
            color = data.ColorStart;
            opacity = data.OpacityStart;
            origin = new(data.texture.Width / 2, data.texture.Height / 2);

            if (data.Speed != 0)
            {
                data.Angle = MathHelper.ToRadians(data.Angle);
                direction = new Vector2((float)Math.Sin(data.Angle), -(float)Math.Cos(data.Angle));
            }
        }

        public void Update()
        {
            lifespanLeft -= Globals.DeltaTimeSeconds;
            if (lifespanLeft <= 0f ) 
            {
                IsFinished = true;
                return;
            }

            //smooth transitions for the particle
            lifespanAmount = MathHelper.Clamp(lifespanLeft / data.LifeSpan, 0f, 1f);
            color = Color.Lerp(data.ColorEnd, data.ColorStart, lifespanAmount);
            opacity = MathHelper.Clamp(MathHelper.Lerp(data.OpacityEnd, data.OpacityStart, lifespanAmount), 0f, 1f);
            Scale = MathHelper.Lerp(data.SizeEnd, data.SizeStart, lifespanAmount) / data.texture.Width;
            pos += direction * data.Speed * Globals.DeltaTimeSeconds;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(data.texture, pos, null, color * opacity, 0f, origin, Scale, SpriteEffects.None, 0.5f);
        }
    }
}
