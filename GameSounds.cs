using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Snake
{
    class GameSounds
    {
        private SoundPlayer background;
        private readonly string eatPath;
        private readonly string gameOverPath;

        public GameSounds()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string mediaPath = Path.Combine(basePath, "Media");

            background = CreatePlayer(Path.Combine(mediaPath, "background.wav"));
            eatPath = Path.Combine(mediaPath, "eat.wav");
            gameOverPath = Path.Combine(mediaPath, "gameover.wav");
        }

        private SoundPlayer CreatePlayer(string path)
        {
            if (!File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл не найден: {path}");
                Console.ResetColor();
                return new SoundPlayer();
            }
            return new SoundPlayer(path);
        }

        public void PlayBackground()
        {
            try { background.PlayLooping(); } catch { }
        }

        public void StopBackground()
        {
            try { background.Stop(); } catch { }
        }

        public void PlayEat()
        {
            try
            {
                SoundPlayer eat = new SoundPlayer(eatPath);
                eat.Play();
            }
            catch { }
        }

        public void PlayGameOver()
        {
            try
            {
                SoundPlayer over = new SoundPlayer(gameOverPath);
                over.Play();
            }
            catch { }
        }
    }
}
