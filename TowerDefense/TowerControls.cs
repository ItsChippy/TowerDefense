using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.UI.Forms;

namespace TowerDefense
{
    internal class TowerControls : ControlManager
    {
        public TowerControls(Game game) : base(game)
        {
        }

        public override void InitializeComponent()
        {
            var gunTowerButton = new Button()
            {
                Text = "Gun Tower(50)",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightGray,
                Location = new Vector2(700, 550), //bottom right of the screen
            };

            gunTowerButton.Clicked += OnClickGunTowerButton;

            Controls.Add(gunTowerButton);

            var slowTowerButton = new Button()
            {
                Text = "Slow Tower(30)",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightGray,
                Location = new Vector2(580, 550),
            };

            slowTowerButton.Clicked += OnClickSlowTowerButton;

            Controls.Add(slowTowerButton);
        }

        private void OnClickGunTowerButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TowerPlacer.SelectGunTower();
        }

        private void OnClickSlowTowerButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TowerPlacer.SelectSlowTower();
        }
    }
}
