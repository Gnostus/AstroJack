using System;
using System.Collections.Generic; 
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AstroJack.Sprites;
using AstroJack.Stages;

namespace AstroJack
{ 
    public class AstroJack : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private readonly List<BaseStage> _stages = new List<BaseStage>();
        private int _currentStage = 0;
        public AstroJack()
        {
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 100);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";  
        }
         
        protected override void Initialize()
        {
            _stages.Add(new LevelOne());
            base.Initialize();            
        }
          
        protected override void LoadContent()
        {
            WorldData.SeaLevel = GraphicsDevice.PresentationParameters.Bounds.Height - 55;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _stages[_currentStage].Load(Content);
        }
         
        protected override void UnloadContent()
        {

        } 

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            if (Keyboard.GetState().GetPressedKeys().Any(k => k == Keys.Escape))
                Exit();

            _stages[_currentStage].Poll();

            if (_stages[_currentStage].Complete)
                _currentStage++;

            base.Update(gameTime);
        }
         
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            _stages[_currentStage].Draw(spriteBatch); 
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
