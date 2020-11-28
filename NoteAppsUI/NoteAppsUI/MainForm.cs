using System;
using System.Collections.Generic;
using System.Windows.Forms;


using NoteAboutUI;
using NoteEditUI;
using NoteApps;

namespace NoteAppsUI
{
    public partial class MainForm : Form
    {
        Project allNotes = new Project();
        List<Note> sortNotes = new List<Note>();

        public MainForm()
        {
            InitializeComponent();
           
            CategoriesComboBox.Items.Add("All");

            foreach (NoteCategory element in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoriesComboBox.Items.Add(element);
            }

            allNotes = ProjectManager.ReadingFromFile(); //загрузка списка заметок
           
            CategoriesComboBox.SelectedIndex = 0; //по умолчанию 1 категория 
            if (allNotes._currentNote != -1 && allNotes._currentNote < TitlesListBox.Items.Count)
            {
                TitlesListBox.SelectedIndex = allNotes._currentNote;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }
      
        private void TitlesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Проверяем и завершаем метод, если элемент не выбран
            if (TitlesListBox.SelectedIndex == -1) return; 
            allNotes._currentNote = allNotes.RealIndexes[TitlesListBox.SelectedIndex];
            ProjectManager.WritingToFile(allNotes);
            NoteTextBox.Clear();
            sortNotes = allNotes.SortWithSelectionCategory(CategoriesComboBox.SelectedIndex);

            //Заполняем данными правую часть окна
            TitleLabel.Text = sortNotes[TitlesListBox.SelectedIndex].NameNote;
            CategoryLabel.Text = "Category: " + sortNotes[TitlesListBox.SelectedIndex].Category;
            CreateDateTimePicker.Value = sortNotes[TitlesListBox.SelectedIndex].TimeCreate;
            ChangeDateTimePicker.Value = sortNotes[TitlesListBox.SelectedIndex].TimeCreate;
            NoteTextBox.Text = sortNotes[TitlesListBox.SelectedIndex].TextNote;
        }
        private void OpenEditForm()
        {
            Form form = new EditForm();
            form.ShowDialog(); // отображаем EditForm для создания заметки
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AboutForm();
            form.Show(); // отображаем AboutForm для показа информации о продукте
        }

        //вывод записей в TitleListBox
        private void FillTitleListBox()
        {
            //проверка на null(если заметок еще нет)
            if (allNotes != null)
            {
                TitlesListBox.Items.Clear();       
                sortNotes = allNotes.SortWithSelectionCategory(CategoriesComboBox.SelectedIndex);
                {
                    for (int i = 0; i < sortNotes.Count; i++)
                    {
                        TitlesListBox.Items.Add(sortNotes[i].NameNote);
                    }
                }
            }
        }
        private void CategoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTitleListBox();
        }

        private void CreateNote()
        {
            //получаем выбранную заметку
            Note newNote = new Note(string.Empty, NoteCategory.Work, string.Empty, DateTime.Now); //сама заметка

            newNote.TimeLastChange = DateTime.Now;

            EditForm inner = new EditForm(); //создаем форму
            inner.Note = newNote; //передаем форме данные
            inner.Text = ("Add Note");
            //если было нажато Cancel завершаем выполнение обработчика
            if (inner.ShowDialog() == DialogResult.OK)
            {
                var updatedNote = inner.Note; //забираем измененные данные

                //добавляем новую заметку в список
                allNotes.Glossary.Add(updatedNote);

                var changeTitle = updatedNote.NameNote;

                FillTitleListBox();

                TitlesListBox.SelectedItem = changeTitle;

                ProjectManager.WritingToFile(allNotes);
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote();
        }

        //изменение заметки
        private void ChangeNote()
        {
            //если заметка не выбрана завершаем выполнение обработчика(ничего не происходит при нажатии на "Изменить")
            if (TitlesListBox.SelectedIndex == -1)
            {
                return;
            }

            //получаем выбранную заметку
            var selectedIndex = TitlesListBox.SelectedIndex; //индекс нашей заметки в списке всех заметок allNotes

            var selectedNote = sortNotes[selectedIndex]; //сама заметка

            EditForm inner = new EditForm(); //создаем форму
            inner.Note = selectedNote; //передаем форме данные
            inner.Text = ("Edit Note");
            //если было нажато Cancel завершаем выполнение обработчика
            if (inner.ShowDialog() == DialogResult.OK)
            {
                var updatedNote = inner.Note; //забираем измененные данные

                //удалить и заменить старые данные
                allNotes.Glossary.RemoveAt(allNotes.RealIndexes[selectedIndex]);

                allNotes.Glossary.Add(updatedNote);

                FillTitleListBox();

                var changeTitle = updatedNote.NameNote;

                TitlesListBox.SelectedItem = changeTitle;

                ProjectManager.WritingToFile(allNotes);
            }
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            ChangeNote();
        }

        //удаление заметки
        private void DeleteNote()
        {
            //если заметка не выбрана завершаем выполнение обработчика(ничего не происходит при нажатии на "Удалить")
            if (TitlesListBox.SelectedIndex == -1)
            {
                return;
            }

            if (MessageBox.Show("Вы уверены что хотите удалить заметку?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //получаем выбранную заметку
                var selectedIndex = TitlesListBox.SelectedIndex; //индекс нашей заметки в списке всех заметок allNotes
                TitlesListBox.Items.RemoveAt(selectedIndex);
                allNotes.Glossary.RemoveAt(allNotes.RealIndexes[selectedIndex]);
                allNotes._currentNote = -1;
                FillTitleListBox();
                NoteTextBox.Clear();

                ProjectManager.WritingToFile(allNotes);
            }
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
