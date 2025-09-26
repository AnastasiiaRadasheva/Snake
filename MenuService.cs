using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class MenuService
    {
        public int ShowDifficultyMenu()
        {
            Console.Clear();
            Console.WriteLine("Valige raskusaste:");
            Console.WriteLine("1 - Lihtne");
            Console.WriteLine("2 - Keskmine");
            Console.WriteLine("3 - Raske");
            Console.Write("Sisestage raskusaste: ");
            int difficultyLevel;

            while (true)
            {
                try
                {
                    difficultyLevel = int.Parse(Console.ReadLine());
                    if (difficultyLevel < 1 || difficultyLevel > 3)
                    {
                        throw new Exception("Vali! Sisent 1, 2 or 3.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.Write("Попробуйте снова: ");
                }
            }
            return difficultyLevel;
        }
    }
}