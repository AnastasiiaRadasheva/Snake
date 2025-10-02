using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Snake
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        List<char> foodSymbols;
        Dictionary<char, int> symbolScores;
        List<Point> obstacles;  

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, Dictionary<char, int> symbolScores)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.symbolScores = symbolScores;
            this.foodSymbols = symbolScores.Keys.ToList();
            this.obstacles = new List<Point>(); 
        }

        public FoodCreator(int mapWidth, int mapHeight, Dictionary<char, int> symbolScores, List<Point> obstacles)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.symbolScores = symbolScores;
            this.foodSymbols = symbolScores.Keys.ToList();
            this.obstacles = obstacles;
        }

        public Point CreateFood()
        {
            int x, y;
            Point p;
            char sym;

            do
            {
                x = random.Next(3, mapWidth - 2);
                y = random.Next(3, mapHeight - 2);
                sym = foodSymbols[random.Next(foodSymbols.Count)];
                p = new Point(x, y, sym);
            } while (obstacles.Any(o => o.x == p.x && o.y == p.y));

            return p;
        }
        public int GetScore(char sym)
        {
            return symbolScores.TryGetValue(sym, out int score) ? score : 0;
        }
    }

}

