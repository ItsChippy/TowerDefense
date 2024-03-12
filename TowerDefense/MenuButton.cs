using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal class MenuButton
    {
        public bool IsSelected { get; set; }
        
        Texture2D buttonTexture;
        Color buttonColor;
        Vector2 buttonPosition;
        Rectangle buttonRect;
        

        public MenuButton(string buttonFileName)
        {
            buttonTexture = Globals.Content.Load<Texture2D>(buttonFileName);
            buttonColor = Color.LightGray;
            buttonPosition = new Vector2(Globals.GameWindow.ClientBounds.Width / 2 - buttonTexture.Width / 2, Globals.GameWindow.ClientBounds.Height / 2 - buttonTexture.Height / 2); //sets the default position for the button in the center of the game window
            buttonRect = new Rectangle((int)buttonPosition.X, (int)buttonPosition.Y, buttonTexture.Width, buttonTexture.Height);
        }

        public void Update()
        {
            
            if (buttonRect.Contains(MouseInputManager.MousePosition))
            {
                buttonColor = Color.White;
                if (MouseInputManager.HasClicked) //registers that the button has been pressed down
                {
                    IsSelected = true;
                }
            }
            else 
            {
                buttonColor = Color.Gray;
                IsSelected = false;
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(buttonTexture, buttonPosition, buttonColor);
        }

        public void ChangePosition(Vector2 newPosition)
        {
            if (newPosition.X == 0) //only changes the y-coordinate of the button
            {
                buttonPosition = new Vector2(buttonPosition.X, newPosition.Y);
            }
            else if (newPosition.Y == 0) //only changes the x-coordinate of the button
            {
                buttonPosition = new Vector2(newPosition.X, buttonPosition.Y);
            }
            else
            {
                buttonPosition = newPosition;
            }

            buttonRect.X = (int)buttonPosition.X;
            buttonRect.Y = (int)buttonPosition.Y;
        }
    }
}
