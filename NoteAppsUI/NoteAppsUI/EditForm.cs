using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NoteApps;

namespace NoteEditUI
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
            foreach (NoteCategory element in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoriesComboBox.Items.Add(element);
            }
        }

        private Note _note;
        public Note Note
        {
            get { return _note; }
            set
            {
                _note = value;
                if (_note != null)
                {
                    //при отправлении заметки в это окно, автоматом заполнятся компоненты формы
                    TitleTextBox.Text = _note.NameNote;
                    CategoriesComboBox.SelectedItem = _note.Category;
                    DateTimeCreate.Value = _note.TimeCreate;
                    DateTimeChange.Value = _note.TimeLastChange;
                    NoteTextBox.Text = _note.TextNote;
                }
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = TitleTextBox.Text;
            this.Text = text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if ((CategoriesComboBox.SelectedIndex == -1) || (NoteTextBox.Text == string.Empty) || (TitleTextBox.Text == string.Empty))
            {
                MessageBox.Show("Отсутствует текст/название/категория");
            }
            else
            {
                _note.NameNote = TitleTextBox.Text;
                _note.TextNote = NoteTextBox.Text;
                _note.Category = (NoteCategory)CategoriesComboBox.Items[CategoriesComboBox.SelectedIndex];
                _note.TimeLastChange = DateTime.Now;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
