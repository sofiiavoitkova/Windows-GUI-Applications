using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Tab : TabPage
    {
        private Form1 parentForm;

        public Tab(string name, Form1 parentForm)
        {
            InitializeComponent();
            Text = name;
            this.parentForm = parentForm;
            TabTextBox.TextChanged += TabTextBox_TextChanged;
        }

        private void TabTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        public TextBox TabTextBox
        {
            get { return textBoxText; }
        }

        private void UpdateStatusBar()
        {
            int currentLine = TabTextBox.GetLineFromCharIndex(TabTextBox.SelectionStart) + 1;
            int currentColumn = TabTextBox.SelectionStart - TabTextBox.GetFirstCharIndexOfCurrentLine() + 1;
            parentForm.UpdateStatusBarText($"Ln: {currentLine}, Col: {currentColumn}");
        }
    }
}
