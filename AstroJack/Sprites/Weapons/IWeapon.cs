using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites.Weapons
{
    public interface IWeapon : IDrawable
    {
        void Shoot();
        void ReLoad(int bulletCount);
    }

    public class OutOfAmmoException : Exception
    {

    }
}
