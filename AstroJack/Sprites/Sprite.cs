using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public enum State
    {
        Walking,
        Punch,
        Jump,
        JumpForward,
        JumpBackwards,
        Glide,
        Idle
    }

    public class Sprite : IDrawable
    {
        public int Width { get { return FrameSize.X; } }
        public int Height { get { return FrameSize.Y; } }
        protected bool FacingLeft = false;
        protected Point FrameSize = new Point(128, 122);
        protected int Speed = 5;
        //Which frame we are currently on
        protected Point CurrentFrame = new Point(0, 0);        
        protected State CurrentState = State.Idle;
        protected bool IsAnimating { get; set; }
        protected int CurrentFrameIndex { get; set; }
        protected Vector2 Position = new Vector2(200, WorldData.GamePlane);

        private string _resource;

        public Sprite(string resource)
        {
            _resource = resource;
            IsAnimating = true;
        }

        public void SetSize(int x, int y)
        {
            FrameSize.X = x;
            FrameSize.Y = y;
        }

        public void SetPosition(float x, float y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public void Load(ContentManager Content)
        { 
            sprite = Content.Load<Texture2D>(_resource); 
        }

        private int LeapCount = 0;
        protected int LeapLength = 5; 
        private bool Jumping { get { return CurrentState == State.JumpBackwards || CurrentState == State.JumpForward || CurrentState == State.Jump; } }

        public virtual void Poll() { }
        protected virtual void ChangeFrame() { }
        protected virtual void SubDraw(SpriteEffects effect) { }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAnimating)
            {
                var effect = FacingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                spriteBatch.Draw(sprite, Position, new Rectangle(
                              FrameSize.X * CurrentFrame.X,
                              FrameSize.Y * CurrentFrame.Y,
                              FrameSize.X,
                              FrameSize.Y),
                              Color.White, 0, Vector2.Zero, 1, effect, 0);
                SubDraw(effect);
            }

            if (CurrentState == State.Walking)
            {
                Position.X += (FacingLeft ? -Speed : Speed);
            }
            else if (CurrentState == State.JumpBackwards)
            {
                Position.X += (FacingLeft ? -Speed : Speed);
                Position.Y -= 3;
            }
            else if (CurrentState == State.JumpForward)
            {
                Position.X += (FacingLeft ? -Speed : Speed);
                Position.Y -= 3;
            }
            else if (CurrentState == State.Jump)
            {
                Position.Y -= 3;
            }
            else if (CurrentState == State.Glide)
            {
                Position.Y += 3;
            }

            if (Jumping)
                LeapCount++;
            
            if (!Jumping && Position.Y < WorldData.GamePlane && LeapCount >= LeapLength)
            {
                LeapLength = 0;
                Position.Y += 3;
            }

            ChangeFrame();
        }

        private Texture2D sprite;
    }
}
