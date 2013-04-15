using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public interface IDrawable
    {
        void Poll();
        void Draw(SpriteBatch spriteBatch);
        void Load(ContentManager content);
    }
}
