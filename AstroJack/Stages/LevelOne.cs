using AstroJack.Sprites;
using AstroJack.Sprites.Enemies;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Stages
{
    public class LevelOne : BaseStage
    {         
        protected override void AddSprites()
        {
            var background = new BackGround("JnRLayer01");
            Add(background);
            var trre = new Sprite("Tree Tall");
            trre.SetSize(101, 171);
            trre.SetPosition(250, 250);
            var dragon = new AirDragon();             
            dragon.SetPosition(350, 250);
            Add(dragon);
            Add(trre);
            AddRange(CreateBricks(BrickType.Grass, 20));
        }

        public override void Poll()
        {
            Counter++;
            if (Counter == 25)
                _player.Talk("Sup ya'll?\nTime for\nsome fun.");
            base.Poll();
        }

    }
}
