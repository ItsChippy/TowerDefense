using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class StartMenuScreen
    {
        Button playButton;

        public StartMenuScreen()
        {
            playButton = new Button("playbutton");
            playButton.ChangePosition(new Vector2(0, 100));
        }

        public void Update()
        {
            playButton.Update();
            if (playButton.IsSelected)
            {
                Game1.Self.Exit();
            }
        }

        public void Draw()
        {
            playButton.Draw();
        }
    }
}
