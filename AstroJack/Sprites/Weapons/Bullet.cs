using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public interface IBullet : IDrawable
    {
        void Shoot();
    }

    public class Bullet : Sprite, IBullet
    {
        private Sprite _gun;
        public Bullet(Sprite gun) : base("bullet")
        {
            _gun = gun;
            IsAnimating = false;
            FrameSize = new Point(12, 13);
        }
         
        protected override void ChangeFrame()
        {
        }
         
        public void Shoot()
        {
            FacingLeft = _gun.FacingLeft;
            Position.X = _gun.PosX - (FacingLeft ? -70 : -50);
            Position.Y = _gun.PosY + 5;
            IsAnimating = true;
        }

        public override void Poll()
        {
            if (IsAnimating)
                Position.X += (FacingLeft ?  -15 : 15);
        }
    }
}
