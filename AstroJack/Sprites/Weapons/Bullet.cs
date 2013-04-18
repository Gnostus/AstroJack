using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public class Bullet : Sprite
    {
        public Bullet() : base("bullet")
        {
            IsAnimating = false;
            FrameSize = new Point(12, 13);
        }

        protected override void ChangeFrame()
        {
        }

        private Vector2 _startingPoint;
        public void Shoot(Vector2 position)
        {
            Position = position;
            IsAnimating = true;
        }

        public override void Poll()
        {
            if (IsAnimating)
                Position.X += 5;
        }
    }
}
