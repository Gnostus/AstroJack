using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{
    public class Text : Drawable
    {
        private string _message;
        private SpriteFont CourierNew;
        private Vector2 _position;

        public void Update(Vector2 position, string message = null)
        {

            _message = message ?? _message;
            _position = position;
             _position.X = position.X + 55;
             _position.Y = position.Y + 95;
            IsAnimating = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        { 
            Vector2 FontOrigin = CourierNew.MeasureString(_message) / 2;
            spriteBatch.DrawString(CourierNew, _message, _position, Color.LightGreen, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
        }

        public override void Load(ContentManager content)
        { 
             CourierNew = content.Load<SpriteFont>( "Courier" );
        }
    }
}
