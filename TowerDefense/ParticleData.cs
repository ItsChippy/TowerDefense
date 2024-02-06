using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    //handles the data for each individual particle
    internal struct ParticleData
    {
        private static Texture2D defaultTexture;        
        public Texture2D texture = defaultTexture = Globals.Content.Load<Texture2D>("particle");
        public float LifeSpan = 2f; //how long the particle is on screen
        public Color ColorStart = Color.Orange; //starting color for transitioning
        public Color ColorEnd = Color.White; //finishing color for transitioning
        public float OpacityStart = 1f;
        public float OpacityEnd = 0f;
        public float SizeStart = 32f;
        public float SizeEnd = 4f;
        public float Speed = 100f; //speed of particle (example in explosions)
        public float Angle = 0f; //angle of which the particle will fly towards from its original position
        public ParticleData()
        {

        }
    }
}
