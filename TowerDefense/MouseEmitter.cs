using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class MouseEmitter : IEmitter    
    {
        public Vector2 EmitPosition => MouseInputManager.MousePosition;
    }
}
