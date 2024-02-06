using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    //handles the data for generation of particles in the particle system
    //some values are for managing random properties of each particle for more "dynamic" particle emissions
    internal struct ParticleEmitterData
    {
        public ParticleData particleData = new(); //data of the particles that should be firing 
        public float Angle = 0f;
        public float AngleVariance = 45f; //random angle generation of the particles firing
        public float LifespanMin = 0.1f; //random lifespan generation
        public float LifespanMax = 2f;
        public float SpeedMin = 10f;
        public float SpeedMax = 100f;
        public float Interval = 1f; //how often the emitter generates a new particle
        public int EmitCount = 1; //how many particles fires per time

        public ParticleEmitterData()
        {
        }
    }
}
