using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal static class ParticleSystem
    {
        private static List<Particle> particles = new();
        private static List<ParticleEmitter> particleEmitters = new();

        public static void AddParticle(Particle particle) 
        {
            particles.Add(particle);
        }

        public static void AddParticleEmitter(ParticleEmitter e)
        {
            particleEmitters.Add(e);
        }

        public static void UpdateParticles()
        {
            foreach (var particle in particles) 
            {
                particle.Update();
            }

            particles.RemoveAll(p => p.IsFinished);
        }

        public static void UpdateEmitters()
        {
            foreach(var emitter in particleEmitters)
            {
                emitter.Update();
            }
        }

        public static void Update()
        {
            UpdateParticles();
            UpdateEmitters();
        }

        public static void Draw()
        {
            foreach (var particle in particles) 
            {
                particle.Draw();
            }
        }
    }
}
