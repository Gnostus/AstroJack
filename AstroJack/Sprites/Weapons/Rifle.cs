using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites.Weapons
{
    public class Rifle : Sprite, IWeapon
    {
        private Sprite _parent;
        public Rifle(Sprite parent)
            : base("rifle")
        {
            _parent = parent;
            _bullet = new Bullet();
            SubSprites.Add(_bullet);
        }

        public override void Poll()
        {
            Position.X = _parent.FullX - 20;
            Position.Y = _parent.FullY - 35;
            base.Poll();
        }
        private int _bulletCount = 0;
        private Bullet _bullet;
        
        public void Shoot(Vector2 position)
        {
            if (_bulletCount > 0)
                _bullet.Shoot(position);
        }


        public void Load(int bulletCount)
        {
            _bulletCount = bulletCount;
        }
    }
}
