using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using NoteApps;
using Newtonsoft.Json;
using System.Reflection;

namespace NoteApp.UnitTests
{
    //Циколматическая сложность 2
    [TestFixture]
    public class ProjectManagerTest
    {
        private Project _noteSave;
        private Project _noteLoad;
        private List<Note> _actualList;
        private static string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\NoteAppTest.json";
        //private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\NoteAppTest.notes";

        [SetUp]
        public void InitNote()
        {
            _noteSave = new Project();
            _noteLoad = new Project();
            _actualList = new List<Note>();

            _actualList.Add(new Note("Заметка 1", NoteCategory.Work, "Текст 1", DateTime.Today) { TimeLastChange = DateTime.Today });
            _actualList.Add(new Note("Заметка 2", NoteCategory.People, "Текст 2", DateTime.Today) { TimeLastChange = DateTime.Today });
            _actualList.Add(new Note("Заметка 3", NoteCategory.Other, "Текст 3", DateTime.Today) { TimeLastChange = DateTime.Today });
            _actualList.Add(new Note("Заметка 4", NoteCategory.Home, "Текст 4", DateTime.Today) { TimeLastChange = DateTime.Today });
        }

        [Test(Description = "Тест сериализации заметок")] //Тест 1
        public void TestSerialize()
        {
            var path = _path;
            var expected = _noteSave;
            var actualList = _actualList;
            var actual = _noteLoad;

            ProjectManager.WritingToFile(expected, path);
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
            
            //В качестве полеченного результата actual используем ранее написанные десирелизванные заметки
            actual = (Project)serializer.Deserialize<Project>(reader);

            for (int i = 0; i < actual.Glossary.Count; i++)
            {
                actualList.Add(actual.Glossary[i]);
            }
            for (int i = 0; i < expected.Glossary.Count; i++)
            {
                Assert.AreEqual(expected.Glossary[i].NameNote, actualList[i].NameNote);
                Assert.AreEqual(expected.Glossary[i].Category, actualList[i].Category);
                Assert.AreEqual(expected.Glossary[i].TextNote, actualList[i].TextNote);
                Assert.AreEqual(expected.Glossary[i].TimeCreate, actualList[i].TimeCreate);
                Assert.AreEqual(expected.Glossary[i].TimeLastChange, actualList[i].TimeLastChange);
            }
        }

        [Test(Description = "Тест десериализации заметок")] //Тест 2
        public void TestDeserialize()
        {
            var path = _path;
            var expected = _noteSave;
            var actualList = _actualList;

            var actual = ProjectManager.ReadingFromFile(path);

            for (int i = 0; i < actual.Glossary.Count; i++)
            {
                actualList.Add(actual.Glossary[i]);
            }
            for (int i = 0; i < expected.Glossary.Count; i++)
            {
                Assert.AreEqual(expected.Glossary[i].NameNote, actualList[i].NameNote);
                Assert.AreEqual(expected.Glossary[i].Category, actualList[i].Category);
                Assert.AreEqual(expected.Glossary[i].TextNote, actualList[i].TextNote);
                Assert.AreEqual(expected.Glossary[i].TimeCreate, actualList[i].TimeCreate);
                Assert.AreEqual(expected.Glossary[i].TimeLastChange, actualList[i].TimeLastChange);
            }
        }
    }
}
