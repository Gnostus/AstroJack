using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack
{
    public static class IO
    {
        public static bool WalkLeft { get; private set; }
        public static bool JumpLeft { get; private set; }
        public static bool WalkRight { get; private set; }
        public static bool JumpRight { get; private set; }
        public static bool Jump { get; private set; } 
        public static bool Idle { get; private set; }
        public static bool Shoot { get; private set; }
        public static bool Talk { get; private set; }  
         
        public static void Poll(PlayerIndex index = PlayerIndex.One)
        {
            WalkLeft =
            JumpLeft =
            WalkRight =
            JumpRight =
            Jump = 
            Idle =
            Shoot = false;
            var keys = Keyboard.GetState().GetPressedKeys().ToList();
            var padState =  GamePad.GetState(index);
            Idle = keys.Count == 0;
            Talk = keys.Any(k => k == Keys.P) || padState.Buttons.LeftShoulder == ButtonState.Pressed;
            Shoot = keys.Any(k => k == Keys.F) || padState.Buttons.A == ButtonState.Pressed;
            Jump = keys.Any(k => k == Keys.Up || k == Keys.Space) || padState.Buttons.B == ButtonState.Pressed;

            if (keys.Any(k => k == Keys.Left) || padState.Buttons.LeftShoulder == ButtonState.Pressed)
            {
                if (Jump)
                    JumpLeft = true;
                WalkLeft = true; 
            }

            if (keys.Any(k => k == Keys.Right) || padState.Buttons.RightShoulder == ButtonState.Pressed)
            {
                if (Jump)
                    JumpRight = true;
                WalkRight = true;
            }
        }
    }
}
