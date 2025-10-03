using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameEngine
    {
        private Snake snake;
        private Walls walls;
        private Obstacles obstacles;
        private FoodCreator foodCreator;

        private GameSounds sounds = new GameSounds();
        private NameService nameService = new NameService();
        private ScoreManager scoreManager = new ScoreManager();
        private MenuService menuService = new MenuService();
        private GameUI ui = new GameUI();

        private Dictionary<char, int> symbolScores = new Dictionary<char, int>
        {
            { '$', 5 },
            { '@', 2 },
            { '#', 3 },
            { '¤', -1 }
        };

        private int currentLevel;
        private int score;
        private int speed;
        private bool isEndlessMode = false;
        private int mapWidth;
        private int mapHeight;

        public void Run()
        {
            currentLevel = menuService.ShowDifficultyMenu();
            InitLevel(currentLevel);

            sounds.PlayBackground();

            while (true)
            {
                if (snake.Eat(foodCreator.CurrentFood))
                {
                    int foodScore = foodCreator.GetScore(foodCreator.CurrentFood.sym);
                    score += foodScore;

                    sounds.PlayEat();
                    ui.DrawScore(score);
                    ui.DrawLevel(currentLevel, mapWidth);

                    foodCreator.CreateFood().Draw();

                    if (!isEndlessMode && score >= 5 * currentLevel && currentLevel < 3)
                    {
                        LevelManager.LevelUp(ref currentLevel, out mapWidth, out mapHeight, out speed);
                        InitLevel(currentLevel);
                    }

                    if (score >= 25 && !isEndlessMode)
                    {
                        HandleVictory();
                        continue;
                    }
                }
                else
                {
                    snake.Move();
                }

                if (walls.IsHit(snake) || snake.IsHitTail() || obstacles.IsHit(snake.GetHead()))
                {
                    HandleGameOver();
                    break;
                }

                Thread.Sleep(speed);
                InputHandler.Handle(snake);
            }

            Console.Clear();
            Console.WriteLine(scoreManager.ReadScores());
            Console.ReadLine();
        }

        private void InitLevel(int level)
        {
            var config = GameConfig.GetLevelConfig(level);
            mapWidth = config.Width;
            mapHeight = config.Height;
            speed = config.Speed;


            Console.Clear(); 
            Console.SetWindowSize(mapWidth, mapHeight);
            Console.SetBufferSize(mapWidth, mapHeight);
            Console.Clear(); 



            walls = new Walls(mapWidth, mapHeight);
            walls.Draw();

            obstacles = new Obstacles(mapWidth, mapHeight, 10);
            obstacles.Draw();

            snake = new Snake(new Point(4, 5, '*'), 4, Direction.RIGHT);
            snake.Draw();

            foodCreator = new FoodCreator(mapWidth, mapHeight, symbolScores, obstacles.GetObstacles());
            foodCreator.CreateFood().Draw();

            ui.DrawScore(score);
            ui.DrawLevel(currentLevel, mapWidth);
        }

        private void HandleVictory()
        {
            Console.Clear();
            ui.ShowVictory();
            Thread.Sleep(2000);
            Console.WriteLine("Kas soovid mängida edasi lõpmatus režiimis? (jah/ei)");
            string answer = Console.ReadLine();

            if (answer.ToLower().StartsWith("j"))
            {
                isEndlessMode = true;
                InitLevel(currentLevel);
            }
            else
            {
                HandleGameOver();
            }
        }

        private void HandleGameOver()
        {
            sounds.PlayGameOver();
            Console.Clear();
            ui.ShowGameOver();

            string name = nameService.AskUserName();
            scoreManager.SaveScore(name, score);
        }
    }
}
