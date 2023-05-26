using Evergreen.Lib;
using Evergreen.Lib.Data;

namespace Evergreen.Game
{
    public class Game
    {
        public GameData GameData;
        public string LoadedGamePath;

        private bool keepRunning = true;

        public void Run()
        {
            Console.WriteLine("Hello, player! Load game[L] or start a new game[N]?");
            string input = Console.ReadLine();

            if (Program.CheckInput(input, new List<string>
            {
                "l",
                "n",
                "L",
                "N"
            }))
            {
                if (input == "l" || input == "L")
                {
                    Console.WriteLine("What is the name of the save file?");
                    string fileName = Console.ReadLine();
                    LoadedGamePath = Program.SavePath + fileName;
                    GameData = SaveSystem.LoadGame(LoadedGamePath);
                }

                if (input == "n" || input == "N")
                {
                    Console.WriteLine("Enter the name of the new save file.");
                    string fileName = Console.ReadLine();
                    Console.WriteLine("Enter the name of your character.");
                    string playerName = Console.ReadLine();
                    GameData = new GameData
                    {
                        PlayerName = playerName,
                    };
                    LoadedGamePath = Program.SavePath + fileName;
                    SaveSystem.SaveGame(LoadedGamePath, GameData);
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }
        }

        public bool ShouldKeepRunning()
        {
            return keepRunning;
        }
    }
}
