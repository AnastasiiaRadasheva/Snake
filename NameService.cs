using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class NameService
    {
        public string AskUserName()
        {
            string name = "";
            while (true)
            {
                Console.Write("Sisesta nimi (vähemalt 3 tähte): ");
                try
                {
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                        throw new Exception("Liiga lühike nimi!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Viga: " + ex.Message);
                    Console.ResetColor();
                }
            }
            return name;
        }

    }
}
