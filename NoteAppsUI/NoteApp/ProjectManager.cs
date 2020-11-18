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
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\NoteApp.notes";
        public static void WritingToFile(Project project, string fileName) //Запись в файл
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        public static Project ReadingFromFile(string fileName) //Чтение из файла
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (StreamReader sr = new StreamReader(fileName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }

            return project;
        }


        public static Project LoadFromFile() //Сохранение
        {
            return ReadingFromFile(_path);
        }
        public static void SaveToFile(Project fileName) //Загрузка
        {
            WritingToFile(fileName, _path);
        }

    }
}

