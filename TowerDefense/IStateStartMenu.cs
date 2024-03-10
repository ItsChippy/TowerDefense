using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class IStateStartMenu : IStateHandler
    {
        
        StartMenuScreen startMenuScreen;

        public IStateStartMenu()
        {
            startMenuScreen = new StartMenuScreen();
        }

        public override void Update()
        {
            startMenuScreen.Update();
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Begin();
            
            startMenuScreen.Draw();
            
            Globals.SpriteBatch.End();

        }
    }
}
