using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites.Weapons
{
    public interface IWeapon : IDrawable
    {
        void Shoot(Vector2 position);
        void Load(int bulletCount);
    }
}
