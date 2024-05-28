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
using System.Diagnostics;

namespace Notepad
{
    public partial class Form1 : Form
    {
        string filePath = "";
        public int FindLastIndex { get; set; } = 0;
        public string FindTextString { get; set; } = "";

        public Form1()
        {
            InitializeComponent();
        }

        public TabControl TabControl
        {
            get { return tabControl1; }
        }

        public void UpdateStatusBarText(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newTab();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newNotepad = new Form1();
            newNotepad.Show();
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

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PrinterSettings.DefaultPageSettings;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString((tabControl1.SelectedTab as Tab).TabTextBox.Text, (tabControl1.SelectedTab as Tab).TabTextBox.Font, System.Drawing.Brushes.Black, 10, 10);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
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
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                (tabControl1.SelectedTab as Tab).TabTextBox.Font = fontDialog1.Font;
            }
        } 

        private void newTab()
        {
            TabPage tab = new Tab("new *", this);
            TextBox t = new TextBox();
            t.Multiline = true;
            t.Dock = DockStyle.Fill;
            tab.Controls.Add(t);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
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
            string selectedText = (tabControl1.SelectedTab as Tab).TabTextBox.SelectedText;
            if (!string.IsNullOrEmpty(selectedText))
            {
                Process.Start("https://www.bing.com/search?q=" + selectedText);
            }
            else
            {
                Process.Start("https://www.bing.com");
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab as Tab).TabTextBox.SelectAll();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Replace replaceForm = new Replace(this);
                replaceForm.ShowDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToForm goToForm = new GoToForm();
            if (goToForm.ShowDialog() == DialogResult.OK)
            {
                int lineNumber = goToForm.SelectedLineNumber;
                TextBox textBox = (tabControl1.SelectedTab as Tab).TabTextBox;

                if (lineNumber <= textBox.Lines.Length)
                {
                    textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(lineNumber - 1);
                    textBox.SelectionLength = 0;
                    textBox.ScrollToCaret();
                }
                else
                {
                    MessageBox.Show("The line number is beyond the total number of lines", "Go to line");
                }
            }
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox selectedTextBox = (tabControl1.SelectedTab as Tab).TabTextBox;
            int selectionStart = selectedTextBox.SelectionStart;
            selectedTextBox.Text = selectedTextBox.Text.Insert(selectionStart, DateTime.Now.ToString());
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font currentFont = (tabControl1.SelectedTab as Tab).TabTextBox.Font;
            float newSize = currentFont.Size + 2;
            (tabControl1.SelectedTab as Tab).TabTextBox.Font = new Font(currentFont.FontFamily, newSize, currentFont.Style);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font currentFont = (tabControl1.SelectedTab as Tab).TabTextBox.Font;
            float newSize = Math.Max(currentFont.Size - 2, 6);
            (tabControl1.SelectedTab as Tab).TabTextBox.Font = new Font(currentFont.FontFamily, newSize, currentFont.Style);
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font currentFont = (tabControl1.SelectedTab as Tab).TabTextBox.Font;
            (tabControl1.SelectedTab as Tab).TabTextBox.Font = new Font(currentFont.FontFamily, 8.25f, currentFont.Style);
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpUrl = "https://www.bing.com/search?q=uzyskiwanie+pomocy+dotycz%c4%85cej+notatnika+w%c2%a0systemie+windows&filters=guid:%224466414-pl-dia%22%20lang:%22pl%22&form=T00032&ocid=HelpPane-BingIA";
            Process.Start(helpUrl);
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string feedbackHubProtocol = "feedback-hub:";
            Process.Start(feedbackHubProtocol);
        }

        private void aboutNotepadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string aboutMessage = "Notepad\n\nThis is a simple Notepad.";
            MessageBox.Show(aboutMessage, "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void FindTextIndex(int FindFromIndex, Boolean FindPreviousIndex)
        {
            string Text = (tabControl1.SelectedTab as Tab).TabTextBox.Text;

            if (FindFromIndex < 0 || FindFromIndex > FindTextString.Length)
            {
                FindFromIndex = 0;
            }

            if (FindPreviousIndex == false)
            {
                FindLastIndex = Text.IndexOf(FindTextString, FindFromIndex);
                if (FindLastIndex == -1)
                {
                    FindLastIndex = Text.IndexOf(FindTextString, 0);
                }
            }
            else
            {
                FindLastIndex = Text.LastIndexOf(FindTextString, FindFromIndex);
                if (FindLastIndex == -1)
                {
                    FindLastIndex = Text.LastIndexOf(FindTextString, Text.Length - 1);
                }
            }
        }

        public void FindTheText()
        {
            if (FindLastIndex != -1)
            {
                TextBox textBox = (tabControl1.SelectedTab as Tab).TabTextBox;
                int startIndex = textBox.SelectionStart + textBox.SelectionLength;
                int index = textBox.Text.IndexOf(FindTextString, startIndex);

                textBox.SelectionStart = FindLastIndex;
                textBox.SelectionLength = FindTextString.Length;

                textBox.ScrollToCaret();

                int lineNumber = textBox.GetLineFromCharIndex(index) + 1;
                int columnNumber = index - textBox.GetFirstCharIndexFromLine(lineNumber - 1) + 1;

                UpdateStatusBarText($"Found at line {lineNumber}, column {columnNumber}");
            }
            else
            {
                MessageBox.Show("Text not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBarText("Text not found");
            }
        }

        private void findToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FindDialog findDialog = new FindDialog(this);
            findDialog.Show();

            FindTextIndex((tabControl1.SelectedTab as Tab).TabTextBox.SelectionStart, false);
            FindTheText();
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindTextString))
            {
                int startIndex = (tabControl1.SelectedTab as Tab).TabTextBox.SelectionStart + 1;
                FindTextIndex(startIndex, false);
                FindTheText();
            }
            else
            {
                MessageBox.Show("Please specify the text to find.", "Find Next", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindTextString))
            {
                int startIndex = (tabControl1.SelectedTab as Tab).TabTextBox.SelectionStart - 1;
                FindTextIndex(startIndex, true);
                FindTheText();
            }
            else
            {
                MessageBox.Show("Please specify the text to find.", "Find Previous", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem.Enabled = (tabControl1.SelectedTab as Tab).TabTextBox.SelectedText.Length > 0;
            copyToolStripMenuItem.Enabled = (tabControl1.SelectedTab as Tab).TabTextBox.SelectedText.Length > 0;
            deleteToolStripMenuItem.Enabled = (tabControl1.SelectedTab as Tab).TabTextBox.SelectedText.Length > 0;
            searchWithBingToolStripMenuItem.Enabled = (tabControl1.SelectedTab as Tab).TabTextBox.SelectedText.Length > 0;
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText(TextDataFormat.Text);
        }

    }
}
