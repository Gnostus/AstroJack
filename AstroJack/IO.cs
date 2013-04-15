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
        public static bool Glide { get; private set; }
        public static bool Idle { get; private set; }
        public static bool Shoot { get; private set; }
         
        public static void Poll(PlayerIndex index = PlayerIndex.One)
        {
            WalkLeft =
            JumpLeft =
            WalkRight =
            JumpRight =
            Jump =
            Glide =
            Idle =
            Shoot = false;
            var keys = Keyboard.GetState().GetPressedKeys().ToList();

            Idle = keys.Count == 0;

            Jump = keys.Any(k => k == Keys.Up || k == Keys.Space);
            Glide = keys.Any(k => k == Keys.Down);

            if (keys.Any(k => k == Keys.Left))
            {
                if (Jump)
                    JumpLeft = true;
                WalkLeft = true; 
            }

            if (keys.Any(k => k == Keys.Right))
            {
                if (Jump)
                    JumpRight = true;
                WalkRight = true;
            } 
        }
    }
}
