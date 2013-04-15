using AstroJack.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack
{
    public abstract class BaseStage : List<IDrawable>
    {
        public bool Complete { get; private set; }
        public int Order { get; private set; }
        
        public abstract void Load(ContentManager content);

        public void Poll()
        {
            ForEach(s => s.Poll());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ForEach(s => s.Draw(spriteBatch));
        }
    }
}
