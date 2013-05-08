using AstroJack.Sprites.Weapons;
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
        private TalkBox _talkBox;
        private IWeapon _weapon;
        public Astronaut() : base("astronaut3_0")
        { 
            IsAnimating = true;
            FrameSize = new Point(30, 37);
            _talkBox = new TalkBox(this);
            _weapon = new Rifle(this);
            SubSprites.Add(_weapon);
            SubSprites.Add(_talkBox);
            _weapon.ReLoad(5);
        }
                
        public void Talk(string message)
        {
            _talkBox.Talk(message);
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

            if (IO.Talk)
                Talk("Wuchu Want?");
            if (IO.Shoot)
            {
                try
                {
                    _weapon.Shoot();
                }
                catch (OutOfAmmoException _) { Talk("  Shit,\n  out of ammo..."); };
            }
            if (IO.WalkRight)
            {
                CurrentState = State.Walking;
                FaceLeft(false);
            }
            if (IO.WalkLeft)
            {
                CurrentState = State.Walking;
                FaceLeft(true);
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
                FaceLeft(true);
            }
            if (IO.JumpRight)
            {
                CurrentState = State.JumpForward;
                FaceLeft(false);
            }
            if (IO.Reload)
            {
                _weapon.ReLoad(5);
            }
            base.Poll();
        }

        private void FaceLeft(bool left)
        {
            FacingLeft = left;
            SubSprites.OfType<Sprite>().ForEach(s => s.FacingLeft = left); 
        }
    }
}
