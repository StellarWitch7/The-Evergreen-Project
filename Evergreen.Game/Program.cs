using Evergreen.Lib;

namespace Evergreen.Game
{
    public class Program
    {
        public static string AppPath = Environment.CurrentDirectory;
        public static string SavePath = AppPath + @"\saves";
        public static string StoryPath = AppPath + @"stories";

        static void Main(string[] args)
        {
            bool gameRunning = true;
            var Game = new Game();

            while (gameRunning == true)
            {
                Game.Run();
                gameRunning = QueryQuit();
            }

            SaveSystem.SaveGame(Game.LoadedGamePath, Game.GameData);
        }

        public static bool CheckInput(string input, List<string> acceptableInputs)
        {
            bool checksPassed = false;

            foreach (string value in acceptableInputs)
            {
                if (value == input)
                {
                    checksPassed = true;
                }
            }

            if (String.IsNullOrEmpty(input))
            {
                checksPassed = false;
            }

            return checksPassed;
        }
        
        public static bool QueryQuit()
        {
            Console.WriteLine("Quit? [y/N]");
            string input = Console.ReadLine();

            if (CheckInput(input, new List<string>
                {
                    "y",
                    "Y",
                    "n",
                    "N"
                }))
            {
                if (input == "Y" || input == "y")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return QueryQuit();
            }
        }

        public static void WriteBlock(float waitTime, List<string> text)
        {
            foreach (string value in text)
            {
                foreach (char character in value)
                {
                    Console.Write(character);
                    Thread.Sleep((int)(waitTime * 50));
                }

                Console.WriteLine();
            }
        }
    }
}