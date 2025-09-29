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
            // Clear console and display title
            Console.Clear();
            Console.SetWindowSize(90, 25); // Adjust window size to fit the ASCII art
            Console.SetBufferSize(90, 25); // Adjust buffer size as well
            Console.CursorVisible = false;


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(10, 3); 
            Console.WriteLine("▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████");
            Console.SetCursorPosition(10, 4);
            Console.WriteLine(" ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine(" ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀ ");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine(" ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄     ");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀     ");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("         ███ ███   ███   ███    ███   ███▐██▄     ███    █▄  ");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("   ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███ ");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine(" ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████ ");
            Console.SetCursorPosition(10, 11);
            Console.WriteLine("                                      ▀                       ");
            Console.ResetColor();

            string[] options = { "Lihtne", "Keskmine", "Raske" };
            int selectedOption = 0; 


            Console.SetCursorPosition(35, 13); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Valige raskusaste:");


            while (true)
            {
              
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(35, 14 + i);
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("► "); 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("  ");  
                    }

                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption == 0) ? options.Length - 1 : selectedOption - 1; 
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption == options.Length - 1) ? 0 : selectedOption + 1; 
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            return selectedOption + 1;
        }
    }
}
