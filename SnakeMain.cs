using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakeMain
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);


            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();


            StreamWriter to_file = new StreamWriter("GameResults.txt", true);
            to_file.WriteLine("Game start: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    WriteGameOver();
                    to_file.WriteLine("Game end: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            to_file.WriteLine("Resoult: game the end");
            to_file.Close();


            StreamReader from_file = new StreamReader("GameResults.txt");
            string text = from_file.ReadToEnd();
            Console.Clear();
            Console.WriteLine(text);

            from_file.Close();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 23;
            int yOffset = 10;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("         ADRI LOX          ", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
