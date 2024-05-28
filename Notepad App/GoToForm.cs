using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class GoToForm : Form
    {
        public int SelectedLineNumber { get; private set; }

        public GoToForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxLine.Text, out int lineNumber))
                {
                    SelectedLineNumber = lineNumber;
                    DialogResult = DialogResult.OK;
                    Close(); 
                }
                else
                {
                    MessageBox.Show("Please enter a valid number!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
