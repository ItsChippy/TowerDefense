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
            var muteButton = new Button()
            {
                Text = "Mute Music",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightBlue,
                Location = new Vector2(0, 550)
            };

            muteButton.Clicked += OnClickMuteButton;

            Controls.Add(muteButton);

            var unMuteButton = new Button()
            {
                Text = "Unmute Music",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightBlue,
                Location = new Vector2(0, 495)
            };

            unMuteButton.Clicked += OnClickUnMuteButton;

            Controls.Add(unMuteButton);


            var gunTowerButton = new Button()
            {
                Text = "Gun Tower(50)",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightGray,
                IsVisible = true,
                Location = new Vector2(675, 520), //bottom right of the screen
            };

            gunTowerButton.Clicked += OnClickGunTowerButton;

            Controls.Add(gunTowerButton);

            var slowTowerButton = new Button()
            {
                Text = "Slow Tower(30)",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightGray,
                IsVisible = true,
                Location = new Vector2(555, 520),
            };

            slowTowerButton.Clicked += OnClickSlowTowerButton;

            Controls.Add(slowTowerButton);
        }

        //OnClick events for various buttons in the game, using MonoGame.UI.Forms
        private void OnClickUnMuteButton(object sender, EventArgs e)
        {
            var unMuteButton = sender as Button;
            MediaPlayer.IsMuted = false;
        }

        private void OnClickMuteButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MediaPlayer.IsMuted = true;
        }

        private void OnClickGunTowerButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (Resources.GetGold() >= 50)
            {
                TowerPlacer.SelectGunTower();
            }
        }

        private void OnClickSlowTowerButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (Resources.GetGold() >= 30)
            {
                TowerPlacer.SelectSlowTower();
            }
        }
    }
}
