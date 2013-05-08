using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites.Enemies
{
    public class AirDragon : Enemy
    {
        public AirDragon() : base("AirDragon")
        {
            FrameSize = new Point(95, 78);
            CurrentState = State.Walking;
        }

        public override void Poll()
        {
            Position.X += (FacingLeft ? -5 : 5);
            base.Poll();
        }

        protected override void ChangeFrame()
        {
            if (CurrentState == State.Walking)
            {
                if (CurrentFrame.X == 2)
                {
                    CurrentFrame.X = -1; 
                }
                CurrentFrame.X++;
            }
        }
    }
}
