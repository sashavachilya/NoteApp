using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApps
{
    /// <summary>
    /// Реализует метод для сохранения "Проект" в файл и метод загрузки проекта из файла путём сериализации
    /// </summary>
    public class ProjectManager
    {
        //Константа, содержащая путь к файлу

        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NoteApp.notes";
       
        public static void WritingToFile(Project project, string file)//Запись в файл
        { 
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamWriter sw = new StreamWriter(file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }
        public static void WritingToFile(Project project)
        {
            WritingToFile(project, _path);
        }

        public static Project ReadingFromFile(string file) //Чтение из файла
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (StreamReader sr = new StreamReader(file))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }
            return project;
        }

        public static Project ReadingFromFile()
        {
            return ReadingFromFile(_path);
        }
        
        public static void CheckFile()
        {
            if (!(File.Exists(_path)))
            {
                File.Create(_path).Close();
            }
                
        }
    }
}

