using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    public class Enum
    {
        public enum Type : int { Road, Brick, Steel, Bush, Ice, Water };
        public enum Color : int { Yellow, Green, Gray, Red };
    }

    static class Const
    {
        public const int spawnLocation1X = 128;
        public const int spawnLocation1Y = 384;
        public const int spawnLocation2X = 224;
        public const int spawnLocation2Y = 384;
    }
}
