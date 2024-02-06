using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class ParticleEmitter
    {
        private ParticleEmitterData data; //all data needed for the particle emitter
        private float intervalLeft;
        private IEmitter emitter;

        public ParticleEmitter(IEmitter emitter, ParticleEmitterData data)
        {
            this.emitter = emitter;
            this.data = data;
            intervalLeft = data.Interval;
        }

        private void Emit(Vector2 pos) //randomizes the speed, lifespan and angle of a particles data and emits it
        {
            ParticleData d = data.particleData;
            d.LifeSpan = Globals.RandomFloat(data.LifespanMin, data.LifespanMax);
            d.Speed = Globals.RandomFloat(data.SpeedMin, data.SpeedMax);
            float r = (float)(Globals.Random.NextDouble() * 2) - 1;
            d.Angle += data.AngleVariance * r;

            Particle p = new(pos, d);
            ParticleSystem.AddParticle(p);
        }

        public void Update() 
        {
            intervalLeft -= Globals.DeltaTimeSeconds;
            while (intervalLeft <= 0) 
            {
                intervalLeft += data.Interval;
                var pos = emitter.EmitPosition;
                for (int i = 0; i < data.EmitCount; i++)
                {
                    Emit(pos);
                }
            }
        }
    }
}
