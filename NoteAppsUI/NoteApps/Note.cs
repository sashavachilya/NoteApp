using System;
using System.Collections.Generic;
using System.Text;


using NoteApps;


namespace NoteApps
{
    /// <summary>
    /// Класс, содержащий поля заметок
    /// </summary>
    public class Note
    {
        private DateTime _timeCreate;
        private DateTime _timeLastChange;
        private string _titleNote;
        private NoteCategory _noteCategory;
        private string _textNote;

        /// <summary>
        /// Метод ввода названия заметки
        /// </summary>
        public string TitleNote
        {
            get { return _titleNote; }
            set
            {
                if (value.Length > 50) throw new ArgumentException("Название записи должно быть меньше 50 символов");
                else if (value.Length == 0) _titleNote = "Без названия";
                else _titleNote = value;
            }
        }

        /// <summary>
        /// Метод ввода категорию заметки
        /// </summary>
        public NoteCategory Category
        {
            get { return _noteCategory; }
            set { _noteCategory = value; }
        }

        /// <summary>
        /// Метод ввода текста заметки
        /// </summary>
        public string TextNote
        {
            get { return _textNote; }
            set { _textNote = value; }
        }

        /// <summary>
        /// Метод фиксирования времени создания записи
        /// </summary>
        public DateTime TimeCreate { get; private set; }



        /// <summary>
        /// Метод фиксирования времени изменения записи
        /// </summary>
        public DateTime TimeLastChange
        {
            get { return _timeLastChange; }
            set { _timeLastChange = value; }
        }

        /// <summary>
        /// Конструктор заметки
        /// </summary>
        public Note(string title, NoteCategory category, string text, DateTime timecreate)
        {
            TitleNote = title;
            Category = category;
            TextNote = text;
            TimeCreate = timecreate;
        }

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            return new Note(this.TitleNote, this.Category, this.TextNote, this.TimeCreate)
            {
                TimeLastChange = this.TimeLastChange
            };

        }
    }
}
