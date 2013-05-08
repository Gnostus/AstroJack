using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Timers;

namespace AstroJack.Sprites.Weapons
{
    public class Weapon : Sprite, IWeapon
    {
        private Timer _timer;
        protected Sprite _parent;
        public Weapon(Sprite parent, string resource)
            : base(resource)
        {
            _parent = parent;
            _timer = new Timer();
            _timer.AutoReset = true;
            _timer.Interval = 350;
            _timer.Elapsed += (s, e) => { CanShoot = true; _timer.Stop(); };
        }

        protected bool CanShoot { get; private set; }

        public virtual void Shoot() { _timer.Start(); CanShoot = false; }
        public virtual void ReLoad(int bulletCount) { }
    }

    public class Rifle : Weapon
    {
        private Queue<IBullet> _magazine;
        private Queue<IBullet> _cache; 
        public Rifle(Sprite parent)
            : base(parent, "rifle")
        {
            _magazine = new Queue<IBullet>();
            _cache = new Queue<IBullet>();
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
          
        public override void Shoot()
        {
            if (!CanShoot)
            {
                base.Shoot();
                return;
            }
            try 
            {
                var bullet = _magazine.Dequeue();
                _cache.Enqueue(bullet);
                bullet.Shoot();
            }
            catch { throw new OutOfAmmoException(); }

            base.Shoot();
        }

        public override void ReLoad(int bulletCount)
        {
            try { Enumerable.Range(0, bulletCount).ForEach(_ => _magazine.Enqueue(_cache.Dequeue())); }
            catch(Exception _) { }
        }
    }
}
