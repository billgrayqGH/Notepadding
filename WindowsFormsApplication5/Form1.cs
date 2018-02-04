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

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        int stat = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.BackColor = Color.White;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream ms;
            OpenFileDialog op = new OpenFileDialog();
            
            if (op.ShowDialog() == DialogResult.OK)
            {
                if ((ms = op.OpenFile()) != null)
                {
                    string filename = op.FileName;
                    string filetext = File.ReadAllText(filename);
                    richTextBox1.Text = filetext;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|";
            if(sd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                this.Text = sd.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cd.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);

            toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = 0;
            String temp = richTextBox1.Text;

            richTextBox1.Text = "";
            richTextBox1.Text = temp;

            while (index < richTextBox1.Text.LastIndexOf(toolStripTextBox1.Text))
            {
                richTextBox1.Find(toolStripTextBox1.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Orange;
                index = richTextBox1.Text.IndexOf(toolStripTextBox1.Text, index) + 1;

            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int index = 0;
            String temp = richTextBox1.Text;

            richTextBox1.Text = "";
            richTextBox1.Text = temp;

            while (index < richTextBox1.Text.LastIndexOf(toolStripTextBox1.Text))
            {
                richTextBox1.Find(toolStripTextBox1.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectedText = toolStripTextBox2.Text;
                index = richTextBox1.Text.IndexOf(toolStripTextBox1.Text, index);
 


            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
          

        }

        private void richTextBox1_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);

            toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
           
       
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);

            toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);
           
            if (e.KeyData == Keys.Enter)
            {
                toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
            }
            else if (e.KeyData == Keys.Up)
            {
                line--;
                toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
            }
            else if (e.KeyData == Keys.Down)
            {
                line++;
                toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
            }
            else if (e.KeyData == Keys.Left)
            {
                column--;
                toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
            }
            else if (e.KeyData == Keys.Right)
            {
                column++;
                toolStripStatusLabel1.Text = "Line " + line.ToString() + " | Column " + column.ToString();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument1;
            ppd.ShowDialog();
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.SolidBrush bg = new System.Drawing.SolidBrush(richTextBox1.SelectionBackColor);
            System.Drawing.SolidBrush fg = new System.Drawing.SolidBrush(richTextBox1.ForeColor);
            
            e.Graphics.FillRectangle(bg, 0, 0, 850, 1100);
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.SelectionFont, fg, new Point(25, 35));
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void exitToolStripMenuItem_Click_2(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("Notepadding Ver 1.0 \nby \nBill Gray Quitalig\nR'shaune Bailey ");
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (stat % 2 == 0)
            {
                statusStrip1.Visible = false;
            }
            else
            {
                statusStrip1.Visible = true;
            }

            stat++;
        }

        private void backgroundColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cd.Color;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
            }
        }
    }
}
