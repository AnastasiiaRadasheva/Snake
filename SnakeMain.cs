using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//Счетчик очков– Увеличиваем очки при поедании еды и выводим их на экран. ++++++++++++++

//Типы еды – Добавляем разные виды еды (нормальная, вредная, полезная) с разными эффектами (уменьшают очки или увеличивают скорость). +++++++++

//Уровни сложности – Сложность меняется с уровнем: увеличивается скорость и размер карты. +++++++++++++

//Разные уровни – при большем уровне увеличиваем уровень и ускоряем игру. ++++++++++++

//Звуковые эффекты – Добавляем звуки при поедании пищи или столкновении с препятствием. +++++++++++

//Записывается имя игрока и отдельно счет ++++++++++++++

namespace Snake
{
    class SnakeMain
    {

        static int currentLevel = 1;
        static int mapWidth;
        static int mapHeight;
        static int speed;

        static void LevelUp(ref Walls walls, Snake snake,
                            ref FoodCreator foodCreator,
                            Dictionary<char, int> symbolScores,
                            int score)
        {
            if (currentLevel < 3)
            {
                currentLevel++;

                (mapWidth, mapHeight) = currentLevel switch
                {
                    1 => (60, 20),
                    2 => (80, 25),
                    3 => (100, 30),
                    _ => (80, 25)
                };

                speed = currentLevel switch
                {
                    1 => 150,
                    2 => 100,
                    3 => 30,
                    _ => 100
                };

                Console.SetWindowSize(mapWidth, mapHeight);
                Console.SetBufferSize(mapWidth, mapHeight);
                Console.Clear();

                walls = new Walls(mapWidth, mapHeight);
                walls.Draw();
                snake.Draw();
                foodCreator = new FoodCreator(mapWidth, mapHeight, symbolScores);

                DrawScore(score);
            }
        }

        static void Main(string[] args)
        {

            GameSounds sounds = new GameSounds();
            NameService nameService = new NameService();

            Console.WriteLine("Valige raskusaste:");
            Console.WriteLine("1 - Lihtne");
            Console.WriteLine("2 - Keskmine");
            Console.WriteLine("3 - Raske");
            Console.Write("Sisestage raskusaste: ");
            int startLevel = int.Parse(Console.ReadLine());
            currentLevel = startLevel;

            (mapWidth, mapHeight) = startLevel switch
            {
                1 => (60, 20),
                2 => (80, 25),
                3 => (100, 30),
                _ => (80, 25)
            };

            speed = startLevel switch
            {
                1 => 150,
                2 => 100,
                3 => 30,
                _ => 100
            };

            Console.SetWindowSize(mapWidth, mapHeight);
            Console.SetBufferSize(mapWidth, mapHeight);
            Console.Clear();

            Walls walls = new Walls(mapWidth, mapHeight);
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

            FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight, symbolScores);
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


            sounds.PlayBackground();

            while (true)
            {

                if (snake.Eat(food))
                {
                    int foodScore = foodCreator.GetScore(food.sym);
                    score += foodScore;

                    sounds.PlayEat();
                    Console.Beep(1000, 150);
                    DrawScore(score);

                    food = foodCreator.CreateFood();
                    food.Draw();

                    if (score >= 5 * currentLevel && currentLevel < 3)
                    {
                        LevelUp(ref walls, snake, ref foodCreator, symbolScores, score);

                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                }
                else
                {
                    snake.Move();
                }
                if (walls.IsHit(snake) || snake.IsHitTail())
                {

                    sounds.PlayGameOver();

                    Console.Beep(400, 500);
                    WriteGameOver();
                    to_file?.WriteLine("Mäng lõppes: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    string userName = nameService.AskUserName();
                    nameService.SaveName(userName);

                    break;
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
