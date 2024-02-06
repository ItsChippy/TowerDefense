using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    internal static class MouseInputManager
    {
        private static MouseState lastMouseState;
        public static bool HasClicked { get; private set; }
        public static Vector2 MousePosition { get; private set; }

        public static void Update()
        {
            var mouseState = Mouse.GetState();

            HasClicked = mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Pressed;
            MousePosition = mouseState.Position.ToVector2();

            lastMouseState = mouseState;
        }
    }
}
