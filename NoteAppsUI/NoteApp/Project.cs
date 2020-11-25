using System.Collections.Generic;

namespace NoteApps
{
    /// <summary>
    /// Содержит список(или словарь) всех Созданных заметок
    /// </summary>
    public class Project
    {
        public List<Note> Glossary = new List<Note>();
        /// <summary>
        /// Индекс текущей заметки
        /// </summary>
        public int _currentNote = -1;

        //Сортировка категорий
        public List<int> RealIndexes = new List<int>();
        public List<Note> SortWithSelectionCategory(int category)
        {
            var sortNotes = new List<Note>();

            //если выбрана категория All
            if (category == 0)
            {
                RealIndexes.Clear();

                for (int i = 0; i < Glossary.Count; i++)
                {
                    sortNotes.Add(Glossary[i]);
                    RealIndexes.Add(i);
                }
            }
            //если другая категория
            else
            {
                RealIndexes.Clear();

                for (int i = 0; i < Glossary.Count; i++)
                {
                    if ((int)Glossary[i].Category == category - 1)
                    {
                        sortNotes.Add(Glossary[i]);
                        RealIndexes.Add(i);
                    }
                }
            }
            return sortNotes;
        }
    }
}
