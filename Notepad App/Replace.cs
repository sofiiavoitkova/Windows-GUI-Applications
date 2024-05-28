using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Replace : Form
    {
        private Form1 form;

        public Replace(Form1 Form)
        {
            InitializeComponent();
            this.form = Form;
        }

        private void button1_Click(object sender, EventArgs e) // Find Next
        {
            string searchText = TextBoxFind.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                form.FindTextString = searchText;
                form.FindTextIndex(form.FindLastIndex + 1, false);
                form.FindTheText();
            }
        }

        private void button4_Click(object sender, EventArgs e) // Cancel
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) // Replace
        {
            string searchText = TextBoxFind.Text;
            string replaceText = TextBoxReplace.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                TextBox textBox = (form.TabControl.SelectedTab as Tab).TabTextBox;

                if (textBox.SelectedText.Equals(searchText))
                {
                    textBox.SelectedText = replaceText;
                }

                form.FindTextString = searchText;
                form.FindTextIndex(textBox.SelectionStart + textBox.SelectionLength, false);
                form.FindTheText();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Replace All
        {
            string searchText = TextBoxFind.Text;
            string replaceText = TextBoxReplace.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                TextBox textBox = (form.TabControl.SelectedTab as Tab).TabTextBox;
                int startIndex = 0;

                form.FindTextString = searchText;
                form.FindTextIndex(startIndex, false);

                while (form.FindLastIndex != -1)
                {
                    textBox.Select(form.FindLastIndex, searchText.Length);
                    textBox.SelectedText = replaceText;

                    startIndex = form.FindLastIndex + replaceText.Length;
                    form.FindTextIndex(startIndex, false);
                }
            }
        }
    }
}
