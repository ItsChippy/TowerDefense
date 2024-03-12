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
            this.position = position;
            GetHitBox();
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.9f);
        }
    }
}
