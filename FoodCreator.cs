using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        int mapWidht;
        int mapHeight;
        List<char> foodSymbols;
        Dictionary<char, int> symbolScores;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, Dictionary<char, int> symbolScores)
        {
            this.mapWidht = mapWidth;
            this.mapHeight = mapHeight;
            this.symbolScores = symbolScores;
            this.foodSymbols = symbolScores.Keys.ToList();
        }

        public Point CreateFood()
        {
            int x = random.Next(3, mapWidht - 2);
            int y = random.Next(3, mapHeight - 2);
            char sym = foodSymbols[random.Next(foodSymbols.Count)];
            return new Point(x, y, sym);
        }

        public int GetScore(char sym)
        {
            return symbolScores.TryGetValue(sym, out int score) ? score : 0;
        }
    }
}

