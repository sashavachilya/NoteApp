using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NoteApps;

namespace NoteApp.UnitTests
{
    //Цикломатическая сложность 3
    [TestFixture]
    public class ProjectTest
    {
        private List<Note> _allNotesTest;
        
        //Создаём список тестовых заметок в атрибуте SetUp, чтобы в дальнейшем не дублировать тот же код в функциях
        [SetUp]
        public void InitAllNotes()
        {
            _allNotesTest = new List<Note>();
            _allNotesTest.Add(new Note("Заметка 1", NoteCategory.Work, "Текст 1", DateTime.Today) { TimeLastChange = DateTime.Today });
            _allNotesTest.Add(new Note("Заметка 2", NoteCategory.People, "Текст 2", DateTime.Today) { TimeLastChange = DateTime.Today });
            _allNotesTest.Add(new Note("Заметка 3", NoteCategory.Other, "Текст 3", DateTime.Today) { TimeLastChange = DateTime.Today });
            _allNotesTest.Add(new Note("Заметка 4", NoteCategory.Home, "Текст 4", DateTime.Today) { TimeLastChange = DateTime.Today });

        }

        [Test(Description = "Проверка заполненности заметок (нет ли незаполненных заметок)")] //Тест 1
        public void AllItemsAreNotNull()
        {
            CollectionAssert.AllItemsAreNotNull(_allNotesTest, "Список содержит заметки с незаполненными полями");
        }

        [Test(Description = "Проверка, сортировки заметок по категориям")] //Тест 2
        public void SortCategories()
        {
            Project TestNote = new Project();
            for (int i = 0; i < _allNotesTest.Count; i++)
            {
                TestNote.Glossary.Add(_allNotesTest[i]);
            }
            List<Note> actualNotes = new List<Note>();
            actualNotes.Add(new Note("Заметка 3", NoteCategory.Other, "Текст 3", DateTime.Today) { TimeLastChange = DateTime.Today });

            var category = 6;
            var expectedNotes = TestNote.SortWithSelectionCategory(category);
            for (int i = 0; i < expectedNotes.Count; i++)
            {
                Assert.AreEqual(expectedNotes[i].Category, actualNotes[i].Category, "Список заметок не совпадает");
            }

        }

        [Test(Description = "Проверка сортировки по категории All")] //Тест 3
        public void SortAllCategory()
        {
            Project TestNote = new Project();
            for (int i = 0; i < _allNotesTest.Count; i++)
            {
                TestNote.Glossary.Add(_allNotesTest[i]);
            }

            var category = 0;
            var expectedNotes = TestNote.SortWithSelectionCategory(category);
            for (int i = 0; i < expectedNotes.Count; i++)
            {
                Assert.AreEqual(expectedNotes[i].Category, _allNotesTest[i].Category, "Список заметок не совпадает");
            }

        }
    }
}

