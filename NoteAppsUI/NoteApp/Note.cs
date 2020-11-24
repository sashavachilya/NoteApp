using System;

namespace NoteApps
{
    /// <summary>
    /// Класс, содержащий поля заметок
    /// </summary>
    public class Note : ICloneable
    {
        private DateTime _timeCreate;
        private DateTime _timeLastChange;
        private string _nameNote;
        private NoteCategory _categoryNote;
        private string _textNote;

        /// <summary>
        /// Метод ввода и получения названия заметки
        /// </summary>
        public string NameNote
        {
            get { return _nameNote; }
            set
            {
                _nameNote = value;
                if (_nameNote.Length > 50) throw new ArgumentException("Длина названия заметки не должна превышать 50 символов");
                if (_nameNote.Length == 0) _nameNote = "Без названия";
            }
        }

        /// <summary>
        /// Метод ввода и получения категорию заметки
        /// </summary>
        public NoteCategory Category
        {
            get { return _categoryNote; }
            set { _categoryNote = value; }
        }

        /// <summary>
        /// Метод ввода и получения текста заметки
        /// </summary>
        public string TextNote
        {
            get { return _textNote; }
            set { _textNote = value; }
        }

        /// <summary>
        /// Метод фиксирования и получения времени создания записи
        /// </summary>
        public DateTime TimeCreate
        {
            get { return _timeCreate; }
            private set { _timeCreate = value; }
        }



        /// <summary>
        /// Метод фиксирования и получения времени изменения записи
        /// </summary>
        public DateTime TimeLastChange
        {
            get { return _timeLastChange; }
            set { _timeLastChange = value; }
        }

        /// <summary>
        /// Конструктор заметки
        /// </summary>
        public Note(string name, NoteCategory category, string text, DateTime timecreate)
        {
            NameNote = name;
            Category = category;
            TextNote = text;
            TimeCreate = timecreate;
        }

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            return new Note(this.NameNote, this.Category, this.TextNote, this.TimeCreate)
            {
                TimeLastChange = this.TimeLastChange
            };

        }
    }

}