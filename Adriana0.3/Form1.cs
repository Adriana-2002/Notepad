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
    public partial class Frmmain : Form
    {
        private int openDoc;
        public static int fontSize = 0;
        public static System.Drawing.FontStyle fs = FontStyle.Regular;
        public Frmmain()
        {
            InitializeComponent();
            mnuSave.Enabled = false;
            
            
           
        }
       

        private void Frmmain_Load(object sender, EventArgs e)
        {
           
        }
        
        private void mnuCut_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Cut();
        }
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Copy();
        }
        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.SelectAll();
        }
        private void mnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Paste();
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)(this.ActiveMdiChild);
            frm.Delete();
        }
        
        private void mnuCascade_Click(Object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Документ " + ++openDoc;
            frm.Text = frm.DocName; frm.MdiParent = this;
            frm.Show();
        }
       
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            // задание доступных расширений файлов программно
            mnuSave.Enabled = true;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank(); frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this; //Указываем родительскую форму
                                      //Присваиваем переменной DocName имя открываемого файла
                frm.DocName = openFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                frm.Show();
            }
           
        }
        blank frm;
        private void mnuSave_Click(object sender, EventArgs e)
        {

            frm = (blank)(this.ActiveMdiChild);
            frm.Save(frm.DocName);
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm = (blank)(this.ActiveMdiChild);
                frm.Save(saveFileDialog1.FileName); frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName; frm.Text = frm.DocName;


            }
            frm = (blank)(this.ActiveMdiChild);
            frm.Save(frm.DocName);
            frm.IsSaved = true;
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            frm = (blank)(this.ActiveMdiChild);
            mnuSave.Enabled = true;
            frm.IsSaved = true;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void mnuFont_Click(object sender, EventArgs e)
        {

        }

        private void mnuColor_Click(object sender, EventArgs e)
        {

        }

        private void mnuArrangelcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void FontBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fontSize = int.Parse(FontBox.Text.ToString());
            }
            catch (Exception)
            {

              
            }
            
               
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fontSt_TextChanged(object sender, EventArgs e)
        {
            if(fontSt.Text=="Жирный")
            fs = FontStyle.Bold;
            if (fontSt.Text == "Обычный")
                fs = FontStyle.Regular;
            if (fontSt.Text == "Курсив")
                fs = FontStyle.Italic;
        }
    }
}
