using Evergreen.App.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Design;

namespace Evergreen.App.Util
{
    public static class SaveSystem
    {
        public static string AppPath = Environment.CurrentDirectory;
        public static string SavePath = AppPath + @"projects\";
        public static string FileExtension = ".qca";

        public static void SaveProject(string fileName, ProjectData data)
        {
            string filePath = SavePath + fileName + FileExtension;
            var options = new JsonSerializerOptions { WriteIndented = true };

            Directory.CreateDirectory(SavePath);
            File.WriteAllText(filePath, JsonSerializer.Serialize(data, options));
        }

        public static ProjectData LoadProject(string fileName)
        {
            string filePath = SavePath + fileName + FileExtension;
            var newProjectData = JsonSerializer.Deserialize<ProjectData>(File.ReadAllText(filePath));

            return newProjectData;
        }

        public static void ExportProject(string fileName, ExportData data)
        {
            throw new NotImplementedException();
        }
    }
}
