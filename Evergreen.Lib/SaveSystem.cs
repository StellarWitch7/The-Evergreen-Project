using Evergreen.Lib.Data;
using System.Text.Json;

namespace Evergreen.Lib
{
    public static class SaveSystem
    {
        private static JsonSerializerOptions Options = new JsonSerializerOptions { WriteIndented = true };

        public static void SaveGame(string filePath, GameData data)
        {
            Directory.CreateDirectory(filePath);
            File.WriteAllText(filePath, JsonSerializer.Serialize(data, Options));
        }

        public static GameData LoadGame(string filePath)
        {
            return JsonSerializer.Deserialize<GameData>(File.ReadAllText(filePath));
        }

        public static void SaveProject(string filePath, ProjectData data)
        {
            Directory.CreateDirectory(filePath);
            File.WriteAllText(filePath, JsonSerializer.Serialize(data, Options));
        }

        public static ProjectData LoadProject(string filePath)
        {
            return JsonSerializer.Deserialize<ProjectData>(File.ReadAllText(filePath));
        }

        public static void ExportProject(string filePath, StoryData data)
        {
            Directory.CreateDirectory(filePath);
            File.WriteAllText(filePath, JsonSerializer.Serialize(data, Options));
        }

        public static StoryData ImportStory(string filePath)
        {
            return JsonSerializer.Deserialize<StoryData>(File.ReadAllText(filePath));
        }
    }
}