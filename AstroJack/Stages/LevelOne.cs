using AstroJack.Sprites;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Stages
{
    public class LevelOne : BaseStage
    {
        public override void Load(ContentManager content)
        {
            var character = new Astronaut();
            var background = new BackGround("JnRLayer01");
            this.Add(background);
            Add(character);
            var trre = new Sprite("Tree Tall");
            trre.SetSize(101, 171);
            trre.SetPosition(250, 250);
            Add(trre);
            AddRange(CreateBricks());
            ForEach(d => d.Load(content));
        }

        private IEnumerable<IDrawable> CreateBricks()
        {
            return Enumerable.Range(0, 50).Select(i =>
            {
                var brick = Brick.Create(BrickType.Grass);
                brick.SetPosition(i * brick.Width, WorldData.SeaLevel);
                return brick;
            });   
        }
    }
}
