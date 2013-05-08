using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace AstroJack.Sprites.Weapons
{
    public class Rifle : Sprite, IWeapon
    {
        private Queue<IBullet> _magazine;
        private Queue<IBullet> _cache;
        private Sprite _parent;
        public Rifle(Sprite parent)
            : base("rifle")
        {
            _magazine = new Queue<IBullet>();
            _cache = new Queue<IBullet>();
            _parent = parent;
            Enumerable.Range(0, 20).ForEach(_ => _cache.Enqueue(new Bullet(this)));
            SubSprites.AddRange(_cache.ToList());
        }

        public override void Poll()
        {          
            FacingLeft = _parent.FacingLeft;
            Position.X = _parent.FullX - (FacingLeft ? _parent.BufferedWidth : 20);
            Position.Y = _parent.FullY - 35;
            base.Poll();
        
        }
          
        public void Shoot()
        {
            try 
            {
                var bullet = _magazine.Dequeue();
                _cache.Enqueue(bullet);
                bullet.Shoot();
            }
            catch { throw new OutOfAmmoException(); } 
        }
         
        public void ReLoad(int bulletCount)
        {
            try { Enumerable.Range(0, bulletCount).ForEach(_ => _magazine.Enqueue(_cache.Dequeue())); }
            catch(Exception _) { }
        }
    }
}
