using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//Счетчик очков– Увеличиваем очки при поедании еды и выводим их на экран.

//Типы еды – Добавляем разные виды еды (нормальная, вредная, полезная) с разными эффектами (уменьшают очки или увеличивают скорость). +++++++++

//Уровни сложности – Сложность меняется с уровнем: увеличивается скорость и размер карты.

//Разные уровни – при большем уровне увеличиваем уровень и ускоряем игру. ++++++++++++

//Звуковые эффекты – Добавляем звуки при поедании пищи или столкновении с препятствием.



namespace Snake
{
    class SnakeMain
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.WriteLine("Valige raskusaste:");
            Console.WriteLine("1 - Lihtne");
            Console.WriteLine("2 - Keskmine");
            Console.WriteLine("3 - Raske");
            Console.Write("Sisestage raskusaste: ");
            int level = int.Parse(Console.ReadLine());

            int speed = level switch
            {
                1 => 150,
                2 => 100,
                3 => 30,
                _ => 100
            };
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            var symbolScores = new Dictionary<char, int>
            {
                { '$', 1 },
                { '@', 2 },
                { '¤', 0 }
            };

            FoodCreator foodCreator = new FoodCreator(80, 25, symbolScores);
            Point food = foodCreator.CreateFood();
            food.Draw();

            int score = 0;

            StreamWriter to_file = null;
            try
            {
                to_file = new StreamWriter("GameResults.txt", true);
                to_file.WriteLine("Mäng algas: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(0, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
                Console.ResetColor();
            }

            DrawScore(score);

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    WriteGameOver();
                    to_file.WriteLine("Mäng lõppes: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                }

                if (snake.Eat(food))
                {
                    int foodScore = foodCreator.GetScore(food.sym);
                    score += foodScore;

                    DrawScore(score);

                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            try
            {
                if (to_file != null)
                {
                    to_file.WriteLine($"Tulemus: {score}"); 
                    to_file.WriteLine("Mäng lõppes: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    to_file.Flush();
                    to_file.Close();
                }
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(0, 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            StreamReader from_file = new StreamReader("GameResults.txt");
            string text = from_file.ReadToEnd();
            Console.Clear();
            Console.WriteLine(text);
            from_file.Close();

            Console.ReadLine();
        }

        static void DrawScore(int score)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Score:      ");
            Console.SetCursorPosition(7, 0);
            Console.Write(score);
            Console.ResetColor();
        }

        static void WriteGameOver()
        {
            int xOffset = 23;
            int yOffset = 10;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("         MÄNG LÕPPES        ", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            Console.ResetColor();
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}