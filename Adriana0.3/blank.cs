using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Adriana0._3
{
    public partial class blank : Form
    {
        public blank()
        {
            InitializeComponent();
        }
        public String DocName;
        public bool IsSaved = false;
        public int fontSize = 0;
        public System.Drawing.FontStyle fs = FontStyle.Regular;
        private void blank_Load(object sender, EventArgs e)
        {

        }


        private String BufferText;
        private int openDoc;
        
        public void Cut()
        { // Вырезание текста
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        public void Copy()
        { // Копирование текста
            this.BufferText = richTextBox1.SelectedText;
        }
        public void Paste()
        { // Вставка
            richTextBox1.SelectedText = this.BufferText;
        }
        // Выделение всего текста – используем свойство SelectAll элемента
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }
        public void Delete()
        { // Удаление
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }
        public void Open(String OpenFileName)
        {
            if (OpenFileName == null) { return; }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd(); sr.Close();
                DocName = OpenFileName;
            }
        }
        public void Save(String SaveFileName)
        {
            if (SaveFileName == null) { return; }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(richTextBox1.Text); sw.Close(); //Устанавливаем
             //   имя документа DocName = SaveFileName;
            }
        }

        private void blank_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsSaved == true)
                if (MessageBox.Show("Do you want save changes in "
                + this.DocName + "?", "Message", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save(this.DocName);
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            fontSize = Frmmain.fontSize;
            fs = Frmmain.fs;
            if(fontSize!=0)
            richTextBox1.Font = new Font("verdana",fontSize,fs);
            else richTextBox1.Font = new Font("verdana", 6, fs);
        }
    }
}

