using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NoteApps;

namespace NoteApp.UnitTests
{
    //Цикломатическая сложность 13
    [TestFixture]
    public class NoteTest
    {
        //Создаём экзэмпляр заметки 
        private Note _note;

        //Создаём тестовую заметку в атрибуте SetUp, чтобы в дальнейшем не дублировать тот же код в функциях
        [SetUp]
        public void InitNote()
        {
            _note = new Note("Заметка", NoteCategory.Other, "Текст заметки", DateTime.Today) { TimeLastChange = DateTime.Today };
        }

        [TestCase("Заметка", "Геттер NameNote возвращает неправильный заголовок",
            TestName = "Позитивный тест геттера NameNote")]
        [TestCase("Заметка", "Сеттер NameNote записывает неправильный заголовок",
            TestName = "Позитивный тест сеттера NameNote")]
        public void TestNameNoteGetSet_CorrectValue(string expected, string message) //Тест 1,2
        {
            _note.NameNote = expected;
            var actual = _note.NameNote;
            Assert.AreEqual(expected, actual, message);
        }

        [Test(Description = "Негативный тест длины названия заметки (ожидается исключение при 50+ символах)")] 
        public void TestNameNoteSet_Loger50Symbols() //Тест 3
        {
            var wrongTitle = "Заметка-Заметка-Заметка-Заметка-Заметка-Заметка-Заметка"; //55 символов

            Assert.Throws<ArgumentException>(
                () => { _note.NameNote = wrongTitle; },
                "Возникает исключение, если длина Name больше 50 символов");
        }

        [Test(Description = "Проверка присваивания пустому полю значения по умлчанию")] //Тест 4
        public void TestNameNoteSet_CorrectValue()
        {
            var expected = "Без названия";
            _note.NameNote = String.Empty;
            var actual = _note.NameNote;

            Assert.AreEqual(expected, actual, "Если поле пустое, сеттер Name не ставит заголовок Без названия");
        }

        [TestCase(NoteCategory.Other, "Геттер NoteCategory возвращает неправильный заголовок",
            TestName = "Позитивный тест геттера Category")]
        [TestCase(NoteCategory.Other, "Сеттер NoteCategory записывает неправильный заголовок",
            TestName = "Позитивный тест сеттера Category")]
        public void TestNoteCategorySetGet_CorrectValue(NoteCategory expected, string message) //Тест 5,6
        {
            _note.Category = expected;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, message);
        }

        //Так как TimeCreate имеет модификатор сеттера private (указание ТЗ), мы можем проверить только его геттер
        [Test(Description = "Позитивный тест геттера TimeCreation")]
        public void TestTimeCreateGet_CorrectValue() //Тест 7
        {
            var expected = DateTime.Today;
            var actual = _note.TimeCreate;

            Assert.AreEqual(expected, actual, "Геттер TimeCreation возвращает неправильную дату");
        }

        [TestCase("Геттер TimeLastChange возвращает неправильную дату",
           TestName = "Позитивный тест геттера TimeLastChange")]
        [TestCase("Сеттер TimeLastChange записывает неправильную дату",
           TestName = "Позитивный тест сеттера TimeLastChange")]
        public void TestDateChangeGetSet_CorrectValue(string message) //Тест 8,9
        {
            var expected = DateTime.Now;
            _note.TimeLastChange = expected;
            var actual = _note.TimeLastChange;

            Assert.AreEqual(expected, actual, message);
        }

        [TestCase("Текст заметки", "Геттер Name возвращает неправильный заголовок",
            TestName = "Позитивный тест геттера NameNote")]
        [TestCase("Текст заметки", "Сеттер Name записывает неправильный заголовок",
            TestName = "Позитивный тест сеттера NameNote")]
        public void TestTextNoteGetSet_CorrectValue(string expected, string message) //Тест 10,11
        {
            _note.TextNote = expected;
            var actual = _note.TextNote;
            Assert.AreEqual(expected, actual, message);
        }


        [Test(Description = "Тест коструктора класса Note")]
        public void TestNoteConstructor_CorrectValue() //Тест 12
        {
            var expectedNote = new Note("Заметка", NoteCategory.Other, "Текст заметки", DateTime.Today) { TimeLastChange = DateTime.Today };
            var actual = _note;

            Assert.AreEqual(expectedNote.NameNote, actual.NameNote, "Неверное значение поля Title");
            Assert.AreEqual(expectedNote.Category, actual.Category, "Неверное значение поля Category");
            Assert.AreEqual(expectedNote.TextNote, actual.TextNote, "Неверное значение поля Text");
            Assert.AreEqual(expectedNote.TimeCreate, actual.TimeCreate, "Неверное значение поля DateCreate");
            Assert.AreEqual(expectedNote.TimeLastChange, actual.TimeLastChange, "Неверное значение поля DateLastChange");
        }

        [Test(Description = "Тест Clone в классе Note")]
        public void TestClone_CorrectValue() //Тест 13
        {
            var expectedNote = new Note("Заметка", NoteCategory.Other, "Текст заметки", DateTime.Today) { TimeLastChange = DateTime.Today };
            var actual = (Note)_note.Clone();

            Assert.AreEqual(expectedNote.NameNote, actual.NameNote, "Неверное значение поля Title");
            Assert.AreEqual(expectedNote.Category, actual.Category, "Неверное значение поля Category");
            Assert.AreEqual(expectedNote.TextNote, actual.TextNote, "Неверное значение поля Text");
            Assert.AreEqual(expectedNote.TimeCreate, actual.TimeCreate, "Неверное значение поля DateCreate");
            Assert.AreEqual(expectedNote.TimeLastChange, actual.TimeLastChange, "Неверное значение поля DateLastChange");
        }
    }
}
