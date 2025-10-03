using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameUI
    {
        public void DrawScore(int score)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Score:      ");
            Console.SetCursorPosition(7, 0);
            Console.Write(score);
            Console.ResetColor();
        }

        public void DrawLevel(int level, int mapWidth)
        {
            Console.SetCursorPosition(mapWidth - 12, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Level: " + level);
            Console.ResetColor();
        }

        public void ShowGameOver()
        {
            ShowMessage("GAME OVER", ConsoleColor.Red);
        }

        public void ShowVictory()
        {
            ShowMessage("YOU WIN!", ConsoleColor.Cyan);
        }

        private void ShowMessage(string message, ConsoleColor color)
        {
            int xOffset = 40;
            int yOffset = 12;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine("============================");
            Console.SetCursorPosition(xOffset + 1, yOffset++);
            Console.WriteLine($"         {message}         ");
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine("============================");
            Console.ResetColor();
        }
    }
}
