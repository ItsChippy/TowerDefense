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

            var gunTowerButton = new Button()
            {
                Text = "Gun Tower(50)",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightGray,
                IsVisible = true,
                Location = new Vector2(655, 520), //bottom right of the screen
            };

            gunTowerButton.Clicked += OnClickGunTowerButton;
            gunTowerButton.MouseEnter += OnHoverGunTowerButton;

            Controls.Add(gunTowerButton);

            var slowTowerButton = new Button()
            {
                Text = "Slow Tower(30)",
                TextColor = Color.Black,
                Size = new Vector2(100, 50),
                BackgroundColor = Color.LightGray,
                IsVisible = true,
                Location = new Vector2(535, 520),
            };

            slowTowerButton.Clicked += OnClickSlowTowerButton;
            slowTowerButton.MouseEnter += OnHoverSlowTowerButton;
            Controls.Add(slowTowerButton);
        }

        //OnClick events for various buttons in the game, using MonoGame.UI.Forms

        private void OnClickMuteButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (MediaPlayer.IsMuted)
            {
                MediaPlayer.IsMuted = false;
                button.Text = "Mute Music";
            }
            else if (!MediaPlayer.IsMuted)
            {
                MediaPlayer.IsMuted = true;
                button.Text = "Unmute Music";
            }
        }

        private void OnClickGunTowerButton(object sender, EventArgs e)
        {
            if (Game1.CurrentState == GameState.Playing && Resources.GetGold() >= 50)
            {
                TowerPlacer.SelectGunTower();
            }
        }

        private void OnClickSlowTowerButton(object sender, EventArgs e)
        {
            if (Game1.CurrentState == GameState.Playing && Resources.GetGold() >= 30)
            {
                TowerPlacer.SelectSlowTower();
            }
        }

        //OnHover events for hover effects
        private void OnHoverGunTowerButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundColor = Color.White;
            button.MouseLeave += Button_MouseLeave;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundColor = Color.LightGray;
        }

        private void OnHoverSlowTowerButton (object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundColor = Color.White;
            button.MouseLeave += Button_MouseLeave;
        }
    }
}
