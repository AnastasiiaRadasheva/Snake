using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameConfig
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }

        public static GameConfig GetLevelConfig(int level)
        {
            return level switch
            {
                1 => new GameConfig { Width = 60, Height = 20, Speed = 150 },
                2 => new GameConfig { Width = 80, Height = 25, Speed = 100 },
                3 => new GameConfig { Width = 100, Height = 30, Speed = 70 },
                _ => new GameConfig { Width = 80, Height = 25, Speed = 100 }
            };
        }
    }
}
