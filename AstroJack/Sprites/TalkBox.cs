using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace AstroJack.Sprites
{
    public class TalkBox : Sprite
    {
        public TalkBox(Sprite parent)
            : base("SpeechBubble")
        {
            _parent = parent;
            IsAnimating = false;
            FrameSize = new Point(101, 171);
            _text = new Text();
            SubSprites.Add(_text);
        }

        private int _duration = 0;
        private readonly List<string> _messages = new List<string>();
        private int _currentMessage = 0;
        private Sprite _parent;
        private Text _text;

        private const int characterPerLine = 11; 
        private const int lineSpace = 15;
        private int lineCount { get { return _messages.Count; } }

        public void Talk(string message)
        {
            IsAnimating = true; 
            _messages.Add(message);
            _text.Update(new Vector2(_parent.PosX + 85, _parent.PosY + 175), _messages[_currentMessage]);
            Update();
        }
         
        private void Update()
        { 
            _duration = _messages[_currentMessage++].Length * 5; 
        }

        public override void Poll()
        {
            _duration--;
            FacingLeft = _parent.FacingLeft;
            Position.X = _parent.FullX - (FacingLeft ? _parent.BufferedWidth : 0);
            Position.Y = _parent.FullY - 210; 
            _text.Update(Position);
            base.Poll();
        }

        protected override void ChangeFrame() 
        {
            if (_duration == 0)
            {
                if (_messages.Count >= _currentMessage)
                {
                    _messages.Clear();
                    _duration = _currentMessage = 0;
                    IsAnimating = false;
                    _text.IsAnimating = false;
                    return;
                }

                Update();
            }
        } 
    }
}
