using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    public class Obstacles
    {
        private List<Point> obstacles;
        private int count;
        private int mapWidth;
        private int mapHeight;
        private char symbol = 'X';


        public Obstacles(int mapWidth, int mapHeight, int count)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.count = count;
            obstacles = new List<Point>();
            GenerateObstacles();
        }


        private void GenerateObstacles()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Random rnd = new Random();
            obstacles.Clear();

            while (obstacles.Count < count)
            {
                int x = rnd.Next(1, mapWidth - 1 );
                int y = rnd.Next(2, mapHeight - 1);

                Point p = new Point(x, y, symbol);
                if (!obstacles.Contains(p))
                {
                    obstacles.Add(p);
                }
            }
            Console.ResetColor();
        }



        public void Draw()
        {
            foreach (var p in obstacles)
                p.Draw();
        }

        public bool IsHit(Point point)
        {
            return obstacles.Exists(o => o.x == point.x && o.y == point.y);
        }

        public List<Point> GetObstacles()
        {
            return obstacles;
        }

    }
}
