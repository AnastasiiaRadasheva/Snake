using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameLevel
    {
        public int Width { get; }
        public int Height { get; }
        public int Speed { get; }

        public GameLevel(int width, int height, int speed)
        {
            Width = width;
            Height = height;
            Speed = speed;
        }
        public static GameLevel GetLevel(int level)
        {
            return level switch
            {
                1 => new GameLevel(60, 20, 150),
                2 => new GameLevel(80, 25, 100),
                3 => new GameLevel(100, 30, 30),
                _ => new GameLevel(80, 25, 100)
            };
        }
    }
}
