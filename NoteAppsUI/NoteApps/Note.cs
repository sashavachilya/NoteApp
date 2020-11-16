using System;
using System.Collections.Generic;
using System.Text;


using NoteApps;


namespace NoteApps
{
    /// <summary>
    /// Класс, содержащий поля записей: Название, Категория, Текст, Время создания, Время изменения
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Время создания записи
        /// </summary>
        private DateTime _timeCreate;
        /// <summary>
        /// Время изменения записи
        /// </summary>
        private DateTime _timeChange;
        /// <summary>
        /// Название записи
        /// </summary>
        private string _titleNote;
        /// <summary>
        /// Категория записи
        /// </summary>
        private NoteCategory _noteCategory;
        /// <summary>
        /// Текст записи
        /// </summary>
        private string _textNote;

        /// <summary>
        /// Метод ввода названия записи
        /// </summary>
        public string TitleNote
        {
            get { return _titleNote; }
            set
            {
                if (value.Length > 20) throw new ArgumentException("Название записи должно быть меньше 20 символов");
            }
        }

        /// <summary>
        /// Метод ввода текста записи
        /// </summary>
        public string TextNote
        {
            get { return _textNote; }
            set
            {
                if (value.Length > 50) throw new ArgumentException("Текст записи должен быть меньше 50 символов");
                else if (value.Length == 0) _textNote = "Без названия" ;
                else _textNote = value;
            }
        }
        /// <summary>
        /// Метод фиксирования времени создания записи
        /// </summary>
        public DateTime TimeCreate
        {
            get { return _timeCreate; }
            protected set { _timeCreate = DateTime.Now; }
               
        }
        /// <summary>
        /// Метод фиксирования времени изменения записи
        /// </summary>
        public DateTime TimeChange
        {
            get { return _timeChange; }
            protected set { _timeChange = DateTime.Now; }
        }

    }
}
