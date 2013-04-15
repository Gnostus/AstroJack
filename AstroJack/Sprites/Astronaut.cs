using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public class Astronaut : Sprite
    { 
        public Astronaut() : base("astronaut3_0")
        { 
            IsAnimating = true;
            FrameSize = new Point(30, 37); 
        }

        private int MomentsSpeaking = 0;
        private int MomentsToSpeak = 0;
        private string Message = string.Empty;

        public void Talk(string message)
        {
            Message = message;
            MomentsToSpeak = Message.Length * 5;
        }

        protected override void SubDraw(SpriteEffects effect) 
        { 

        }

        protected override void ChangeFrame()
        {
            if (CurrentState == State.Walking)
            {
                if (CurrentFrame.X == 2)
                {
                    CurrentFrame.X = -1;
                    if (CurrentFrame.Y == 0)
                        CurrentFrame.Y = -1;
                    CurrentFrame.Y++;
                }
                CurrentFrame.X++;
            }
        }

        public override void Poll()
        {
            IO.Poll();

            if (IO.WalkRight)
            {
                CurrentState = State.Walking;
                FacingLeft = false;
            }
            if (IO.WalkLeft)
            {
                CurrentState = State.Walking;
                FacingLeft = true;
            }
            if (IO.Idle)
            {
                CurrentFrame = new Microsoft.Xna.Framework.Point(0, 0);
                CurrentState = State.Idle;
            }
            if (IO.Jump) CurrentState = State.Jump;
            if (IO.JumpLeft)
            {
                CurrentState = State.JumpBackwards;
                FacingLeft = true;
            }
            if (IO.JumpRight)
            {
                CurrentState = State.JumpForward;
                FacingLeft = false;
            }
            if (IO.Glide) CurrentState = State.Glide; 
        }     
    }
}
