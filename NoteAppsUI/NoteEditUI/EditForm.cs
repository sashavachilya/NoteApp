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
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = TitleTextBox.Text;
            this.Text = text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            ProjectManager.SaveToFile(project);
            this.Close();
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
                    NoteTextBox.Text = _note.TextNote;
                }
            }
        }

        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {
            _note.TextNote = NoteTextBox.Text;
            _note.TimeCreate = DateTime.Now;
        }
    }
}
