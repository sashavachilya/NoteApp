using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApps
{
    /// <summary>
    /// Реализует метод для сохранения объекта «Проект» в файл и метод загрузки проекта из файла путём сериализации
    /// </summary>
    public class ProjectManager
    {
        //Константа, содержащая путь 
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\NoteApp.notes";
        public static void WritingToFile(Project project, string nameFile)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamWriter sw = new StreamWriter(nameFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        public static Project ReadingFromFile(string nameFile)
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (StreamReader sr = new StreamReader(nameFile))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }

            return project;
        }


        public static Project LoadFromFile()
        {
            return ReadingFromFile(_path);
        }
        public static void SaveToFile(Project fileName)
        {
            WritingToFile(fileName, _path);
        }

    }
}


