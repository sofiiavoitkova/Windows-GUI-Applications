using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FindDialog : Form
    {
        public string FindText { get; private set; }
        private Form1 form;

        public FindDialog(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        public TextBox TextBox
        {
            get { return txtFind; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFindNext_Click_1(object sender, EventArgs e)
        {
            FindText = txtFind.Text;
            string searchText = form.TabControl.SelectedTab.Controls[0].Text;
            int startIndex = form.FindLastIndex + 1;
            if (startIndex >= searchText.Length)
            {
                startIndex = 0;
            }

            int index = searchText.IndexOf(FindText, startIndex);
            if (index != -1)
            {
                form.FindLastIndex = index;
                form.FindTextString = FindText;
                form.FindTheText();
            }
            else
            {
                MessageBox.Show("Cannot find '" + FindText + "'", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.FindLastIndex = -1;
            }
        }
    }
}
