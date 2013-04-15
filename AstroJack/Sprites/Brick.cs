using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack.Sprites
{ 
    public enum BrickType {
        Grass,
        Ground,
        Sand,
        Sky,
        Dirt,
        DirtRock
    }

    public class Brick : Sprite
    {
        private class BrickResource
        {
            private List<String> _resources;
            private int _position;

            public BrickResource(List<String> resources)
            {
                _resources = resources;
                _position = 0;
            }

            public string GetResource()
            {
                if (_position >= _resources.Count)
                    _position = 0;
                return _resources[_position++];
            }
        }

        private static BrickResource Grass = new BrickResource(new List<string>() { "Grass", "Grass2", "GrassNGrass", "GrassNGrass2" });
        private static BrickResource Ground = new BrickResource(new List<string>() { "Ground", "Ground2" });
        private static BrickResource Sand = new BrickResource(new List<string>() { "Sand", "Sand2" });
        private static BrickResource Sky = new BrickResource(new List<string>() { "Sky", "Sky2", "Sky3", "Sky4" });
        private static BrickResource Dirt = new BrickResource(new List<string>() { "Dirt", "Dirt2" });
        private static BrickResource DirtRock = new BrickResource(new List<string>() { "DirtRock", "DirtRock2" });

        private static Dictionary<BrickType, BrickResource> ResourceDictionary = new Dictionary<BrickType, BrickResource>()
        {
            {BrickType.Grass, Grass},
            {BrickType.Ground, Ground},
            {BrickType.Sand, Sand},
            {BrickType.Sky, Sky},
            {BrickType.Dirt, Dirt},
            {BrickType.DirtRock, DirtRock},
        };

        public static Brick Create(BrickType type)
        { 
            return new Brick( ResourceDictionary[type].GetResource());
        }

        private Brick(string type) : base(type)
        {
            IsAnimating = true;
        }
    }
}
 