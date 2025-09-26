using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ScoreManager
    {
        private readonly string filePath = "GameResults.txt";
        public void SaveScore(string playerName, int score)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Mäng lõppes: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine("Nimi: " + playerName);
                    writer.WriteLine("Tulemus: " + score);
                    writer.WriteLine("-------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error while saving score: {ex.Message}");
                Console.ResetColor();
            }
        }
        public string ReadScores()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
                else
                {
                    return "No game results found.";
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error while reading scores: {ex.Message}");
                Console.ResetColor();
                return string.Empty;
            }
        }
    }
}
