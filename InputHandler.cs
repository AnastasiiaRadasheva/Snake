using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class InputHandler
    {
        public static void Handle(Snake snake)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                snake.HandleKey(key.Key);
            }
        }
    }
}
