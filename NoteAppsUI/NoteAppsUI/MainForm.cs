using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

using NoteApps;

namespace NoteAppsUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
           InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Project project = new Project();
            Note[] note = new Note[2];
            for (int i = 0; i < 2; i++)
            {
                note[i] = new Note("Тестовая заметка " + (i + 1), NoteCategory.Other, " *** Тест ***", DateTime.Now);
                Console.WriteLine(note[i].NameNote + "  " + note[i].Category + "  " + note[i].TextNote + "  " + note[i].TimeCreate);
                project.Glossary.Add(note[i]);
            }
            ProjectManager.SaveToFile(project);
        }

      
    }
}