using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    //trying out interface for my particle emitters
    internal interface IEmitter
    {
        Vector2 EmitPosition { get; } //gets the starting position of the emitter
    }
}
