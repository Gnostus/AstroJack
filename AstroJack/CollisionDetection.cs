using AstroJack.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack
{
    public static class CollisionDetection
    {
        private static List<Sprite> Sprites = new List<Sprite>();
        public static void RegisterSprites(IEnumerable<Sprite> sprites)
        {
            Sprites.AddRange(sprites);
        }

        public static Sprite Colliding(Sprite sprite)
        {
            return Sprites.FirstOrDefault(s => s.Collided(sprite));
        }
    }
}
