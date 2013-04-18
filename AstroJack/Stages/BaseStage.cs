using AstroJack.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack
{
    public abstract class BaseStage : List<Drawable>
    {
        protected Astronaut _player;
        protected BackGround _backGround;
        protected readonly List<Drawable> _bricks = new List<Drawable>();
        protected int Counter { get; set; }

        public bool Complete { get; protected set; }
        public int Order { get; protected set; }

        public void Load(ContentManager content)
        {
            AddSprites();
            _player = new Astronaut();
            Add(_player);
            ForEach(d =>
            {
                d.Load(content);
            });
        }
         
        protected abstract void AddSprites();

        protected IEnumerable<Drawable> CreateBricks(BrickType type, int amount)
        {
            return Enumerable.Range(0, amount).Select(i =>
            {
                return CreateBrick(i, type);
            });
        }

        protected Brick CreateBrick(int i, BrickType type)
        {
            var brick = Brick.Create(type);
            brick.SetPosition(i * brick.Width, WorldData.SeaLevel);
            return brick;
        }

        public virtual void Poll() { ForEach(s => s.Poll()); }
        public void Draw(SpriteBatch spriteBatch) { ForEach(s => s.Draw(spriteBatch)); }
    }
}
