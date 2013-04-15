using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack
{
    public static class WorldData
    {
        public static float SeaLevel = 0;
        public static float GamePlane { get { return WorldData.SeaLevel - 36; } }

    }
}
