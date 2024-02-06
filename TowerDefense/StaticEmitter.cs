using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class StaticEmitter : IEmitter
    {
        public Vector2 EmitPosition { get; }

        public StaticEmitter(Vector2 pos)
        {
            EmitPosition = pos;
        }
    }
}
