using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{
    class SnakeMain
    {
        static void Main(string[] args)
        {
            GameEngine game = new GameEngine();
            game.Run();
        }
    }
}







//Счетчик очков– Увеличиваем очки при поедании еды и выводим их на экран. ++++++++++++++

//Типы еды – Добавляем разные виды еды (нормальная, вредная, полезная) с разными эффектами (уменьшают очки или +2 к очкам вместо +1). +++++++++

//Уровни сложности – Сложность меняется с уровнем: увеличивается скорость и размер карты. +++++++++++++

//Разные уровни – при большем уровне увеличиваем уровень и ускоряем игру. ++++++++++++

//Звуковые эффекты – Добавляем звуки при поедании пищи или столкновении с препятствием. +++++++++++

//Записывается имя игрока и отдельно счет, в конце игры. ++++++++++++++

// Реализовано красивое менюю. ++++++++++++++++++

// Вывод проигрыша или победы (при достижении 3 уровня и 25 очков).++++++++++++++

// Возможность играть в бесконечном режиме после победы. ++++++++++++++++

// Возможность сохранять и смотреть результаты прошлых игр. ++++++++++++++++






//Punktide loendur – Suurendame punkte toidu söömisel ja kuvame need ekraanil. ++++++++++++++

//Toidu tüübid – Lisame erinevaid toidu tüüpe (normaalne, kahjulik, kasulik) erinevate mõjudega (vähendavad punkte või +2 punkti asemel +1). +++++++++

//Raskusastmed – Raskusaste muutub taseme järgi: kiirus ja kaardi suurus suurenevad. +++++++++++++

//Erinevad tasemed – kõrgemal tasemel suurendame taset ja kiirendame mängu. 

//Heli efektid – Lisame helid toidu söömisel või takistusega kokkupõrkel. +++++++++++

//Salvestatakse mängija nimi ja eraldi punktisumma. ++++++++++++++

// Rakendatud on ilus menüü. ++++++++++++++++++

// Kaotuse või võidu väljatoomine (3. taseme ja 25 punkti saavutamisel).++++++++++++++

// Võimalus mängida pärast võitu lõputus režiimis. ++++++++++++++++

// Võimalus salvestada ja vaadata eelmiste mängude tulemusi. ++++++++++++++++









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


