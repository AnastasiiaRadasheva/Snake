using System;

namespace Snake
{
    public class MenuService
    {
        public int ShowDifficultyMenu()
        {
            Console.Clear();
            Console.SetWindowSize(90, 25);

            Console.CursorVisible = false;


            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(28, 7);
            Console.WriteLine("▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████▄");
            Console.SetCursorPosition(28, 8);
            Console.WriteLine(" ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███");
            Console.SetCursorPosition(28, 9);
            Console.WriteLine(" ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀ ");
            Console.SetCursorPosition(28, 10);
            Console.WriteLine(" ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄     ");
            Console.SetCursorPosition(28, 11);
            Console.WriteLine("▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀     ");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine("         ███ ███   ███   ███    ███   ███▐██▄     ███    █▄  ");
            Console.SetCursorPosition(28, 13);
            Console.WriteLine("   ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███ ");
            Console.SetCursorPosition(28, 14);
            Console.WriteLine(" ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████ ");
            Console.SetCursorPosition(28, 15);
            Console.WriteLine("                                      ▀                       ");
            Console.ResetColor();


            string[] options = { "Lihtne", "Keskmine", "Raske" };
            int selectedOption = 1;


            Console.SetCursorPosition(50, 16);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Valige raskusaste:");

            while (true)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(50, 17 + i);


                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("►  ");
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
