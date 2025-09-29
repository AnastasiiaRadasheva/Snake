using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;




//Счетчик очков– Увеличиваем очки при поедании еды и выводим их на экран. ++++++++++++++

//Типы еды – Добавляем разные виды еды (нормальная, вредная, полезная) с разными эффектами (уменьшают очки или +2 к очкам вместо +1). +++++++++

//Уровни сложности – Сложность меняется с уровнем: увеличивается скорость и размер карты. +++++++++++++

//Разные уровни – при большем уровне увеличиваем уровень и ускоряем игру. ++++++++++++

//Звуковые эффекты – Добавляем звуки при поедании пищи или столкновении с препятствием. +++++++++++

//Записывается имя игрока и отдельно счет, так же время начала и конца игры. ++++++++++++++

// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    3 => 70,
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
                DrawLevel(currentLevel);
            }
        }

        static void DrawLevel(int level)
        {
            Console.SetCursorPosition(mapWidth - 12, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Level: " + level);
            Console.ResetColor();
        }

        static void ShowVictoryMessage()
        {
            int xOffset = 23;
            int yOffset = 10;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("          YOU WIN!           ", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            GameSounds sounds = new GameSounds();
            NameService nameService = new NameService();
            ScoreManager scoreManager = new ScoreManager();
            MenuService menuService = new MenuService();

            int startLevel = menuService.ShowDifficultyMenu();
            currentLevel = startLevel;
            Console.Clear();

            (mapWidth, mapHeight) = startLevel switch
            {
                1 => (60, 20),
                2 => (80, 25),
                3 => (100, 30),
                _ => (80, 25)
            };

            speed = startLevel switch
            {
                1 => 120,
                2 => 80,
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
                { '$', 4 },
                { '@', 4 },
                { '#', 4 },
                { '¤', 4 }
            };

            FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight, symbolScores);
            Point food = foodCreator.CreateFood();
            food.Draw();

            int score = 0;

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
                    DrawLevel(currentLevel);

                    food = foodCreator.CreateFood();
                    food.Draw();

                    if (score >= 5 * currentLevel && currentLevel < 3)
                    {
                        LevelUp(ref walls, snake, ref foodCreator, symbolScores, score);
                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                    if (score >= 25)
                    {
                        ShowVictoryMessage();
                        Thread.Sleep(2000); 


                        string userName = nameService.AskUserName();

                        scoreManager.SaveScore(userName, score);

                        break;
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
                    Console.Clear();

                    WriteGameOver();

                    string userName = nameService.AskUserName();

                    scoreManager.SaveScore(userName, score);

                    break;
                }
                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            string gameResults = scoreManager.ReadScores();
            Console.Clear();
            Console.WriteLine(gameResults);
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
            WriteText("          GAME OVER         ", xOffset + 1, yOffset++);
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



//class NameService
//{
//    public string AskUserName()
//    {
//        string name = "";
//        while (true)
//        {
//            Console.Write("Sisesta nimi (vähemalt 3 tähte): ");
//            try
//            {
//                name = Console.ReadLine();
//                if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
//                    throw new Exception("Liiga lühike nimi!");
//                break;
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Viga: " + ex.Message);
//                Console.ResetColor();
//            }
//        }
//        return name;
//    }

//public void SaveName(string name)
//{
//    try
//    {
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Faili viga: " + ex.Message);
//    }


//________ ________   ________  ___  __    _______      
//|\   ____\|\   ___  \|\   __  \|\  \|\  \ |\  ___ \     
//\ \  \___|\ \  \\ \  \ \  \|\  \ \  \/  /|\ \   __/|    
// \ \_____  \ \  \\ \  \ \   __  \ \   ___  \ \  \_|/__  
//  \|____|\  \ \  \\ \  \ \  \ \  \ \  \\ \  \ \  \_|\ \ 
//    ____\_\  \ \__\\ \__\ \__\ \__\ \__\\ \__\ \_______\
//   |\_________\|__| \|__|\|__|\|__|\|__| \|__|\|_______|
//   \|_________|                                         


