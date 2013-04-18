using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public class Drawable : IDrawable
    {
        public List<IDrawable> SubSprites { get; protected set; }
        public virtual void Poll() { SubSprites.Where(d=> d.IsAnimating).ForEach(d => d.Poll()); }
        public virtual void Draw(SpriteBatch spriteBatch) { SubSprites.Where(d => d.IsAnimating).ForEach(d => d.Draw(spriteBatch)); }
        public virtual void Load(ContentManager content) { SubSprites.ForEach(d => d.Load(content)); }
        public bool IsAnimating { get; set; }

        public Drawable()
        {
            SubSprites = new List<IDrawable>();
        }

    }
    public interface IDrawable
    { 
        void Poll();
        void Draw(SpriteBatch spriteBatch);
        void Load(ContentManager content);
        List<IDrawable> SubSprites { get; }
        bool IsAnimating { get; }
    }
}
