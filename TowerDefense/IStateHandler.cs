using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal abstract class IStateHandler
    {

        public abstract void Update();

        public abstract void Draw();
    }
}
