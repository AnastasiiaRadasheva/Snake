using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakeMain
    {
        static void Main(string[]args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);



            HorisontalLine line = new HorisontalLine(0, 78, 0, '*');
            line.Drow();
            HorisontalLine line0 = new HorisontalLine(0, 78, 24, '*');
            line0.Drow();
            VerticalLine line1 = new VerticalLine(0, 24, 0, '*');
            line1.Drow();
            VerticalLine line2 = new VerticalLine(0, 24, 78, '*');
            line2.Drow();


            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();
            Thread.Sleep(300);
            snake.Move();

            while (true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                        snake.direction = Direction.LEFT;
                    else if (key.Key == ConsoleKey.RightArrow)
                        snake.direction = Direction.RIGHT;
                    else if (key.Key == ConsoleKey.DownArrow)
                        snake.direction = Direction.DOWN;
                    else if (key.Key == ConsoleKey.UpArrow)
                        snake.direction = Direction.UP;
                }
                Thread.Sleep(300);
                snake.Move();
            }









            Console.ReadLine();


            //Point p1 = new Point(1, 3, '*');
            //p1.Draw();
            //Point p2 = new Point();
            //p2.Draw();

            ////p1.x = 1;
            ////p1.y = 3;
            ////p1.sym = '*';
            //p1.Draw();

            ////int x1 = 1;
            ////int y1 = 3;
            ////char sym1 = '*';
            ////Draw(x1, y1, sym1);


            //Point p2 = new Point();
            ////p2.x = 4;
            ////p2.y = 6;
            ////p2.sym = '-';
            //p2.Draw();

            ////int x2 = 4;
            ////int y2 = 5;
            ////char sym2 = '-';
            ////Draw(x2, y2, sym2);
            ////List<int> num = new List<int>();
            ////num.Add(0);
            ////num.Add(1);
            ////num.Add(2);
            ////int x = num[0];
            ////int y = num[1];
            ////int z = num[2];


            //Console.ReadLine();
        }
        //static void Draw(int x, int y, char sym)
        //{
        //    Console.SetCursorPosition(x, y);
        //    Console.WriteLine(sym);
        //}
    }
}
