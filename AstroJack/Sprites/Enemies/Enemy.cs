using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites.Enemies
{
    public class Enemy : Sprite
    {
        protected bool Aggravated;

        public Enemy(string resource) : base(resource)
        {

        }

        public override void Poll()
        {
            if (PosX <= 0)
            {
                FacingLeft = false; 
            }
            if (PosX >= WorldData.RightBound)
                FacingLeft = true;
            base.Poll();
        }
    }
}
