using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class LevelManager
    {
        public static void LevelUp(ref int level, out int width, out int height, out int speed)
        {
            level++;
            var config = GameConfig.GetLevelConfig(level);
            width = config.Width;
            height = config.Height;
            speed = config.Speed;

            Console.Clear();
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }
    }
}
