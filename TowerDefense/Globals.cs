global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Content;
global using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class Globals
    {
        public static ContentManager Content {  get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GameWindow GameWindow { get; set; }
        public static float DeltaTime { get; set; }

        public static void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
