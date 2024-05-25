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

namespace Notepad
{
    public partial class Form1 : Form
    {
        string filePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
            (sender as ToolStripMenuItem).Checked = statusStrip1.Visible;
        }

        private void worldWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.WordWrap = !(tabControl1.SelectedTab as Tab).TabTextBox.WordWrap;
            (sender as ToolStripMenuItem).Checked = (tabControl1.SelectedTab as Tab).TabTextBox.WordWrap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newTab();
            worldWrapToolStripMenuItem.Checked = (tabControl1.SelectedTab as Tab).TabTextBox.WordWrap;
            worldWrapToolStripMenuItem.Checked = statusStrip1.Visible;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = (tabControl1.SelectedTab as Tab).TabTextBox.Font;
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                (tabControl1.SelectedTab as Tab).TabTextBox.Font = fontDialog1.Font;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            { 
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.WriteLine((tabControl1.SelectedTab as Tab).TabTextBox.Text);
                    sw.Close();

                    (tabControl1.SelectedTab as Tab).Text = Path.GetFileName(saveFileDialog1.FileName);
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine((tabControl1.SelectedTab as Tab).TabTextBox.Text);
                sw.Close();

                (tabControl1.SelectedTab as Tab).Text = Path.GetFileName(saveFileDialog1.FileName);
            }


        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine((tabControl1.SelectedTab as Tab).TabTextBox.Text);
                sw.Close();

                (tabControl1.SelectedTab as Tab).Text = Path.GetFileName(saveFileDialog1.FileName);

            }


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string line = sr.ReadLine();
                while (line != null)
                {
                    (tabControl1.SelectedTab.Controls[0] as TextBox).Text += line + "\r\n";
                    line = sr.ReadLine();
                }
                sr.Close();
                (tabControl1.SelectedTab as Tab).Text = Path.GetFileName(openFileDialog1.FileName);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString((tabControl1.SelectedTab as Tab).TabTextBox.Text, (tabControl1.SelectedTab as Tab).TabTextBox.Font, System.Drawing.Brushes.Black, 10, 10);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void newTab()
        {
            TabPage tab = new Tab("new *");
            TextBox t = new TextBox();
            t.Multiline = true;
            t.Dock = DockStyle.Fill;
            tab.Controls.Add(t);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newTab();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newNotepad = new Form1(); // Create a new instance of Form1
            newNotepad.Show();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PrinterSettings.DefaultPageSettings;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.SelectedText = "";
        }

        private void searchWithBingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.SelectAll();
        }
    }
}
