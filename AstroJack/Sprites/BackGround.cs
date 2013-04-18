using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public class BackGround : Drawable
    {
        Texture2D _texture;
        string _resource;        
        public BackGround(string resource)
        {
            _resource = resource;
        }
         
        public override void Draw(SpriteBatch spriteBatch)
        {
            var y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            var x = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            spriteBatch.Draw(_texture, new Microsoft.Xna.Framework.Rectangle(0,0, x, y), Color.White);
        }

        public override void Load(ContentManager content)
        {
 	       _texture = content.Load<Texture2D>(_resource); 
        }
    }   
}
