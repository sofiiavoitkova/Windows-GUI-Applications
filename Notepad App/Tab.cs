using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Tab : TabPage /*UserControl*/
    {
        public Tab(string name)
        {
            InitializeComponent();
            Text = name;
        }

        public TextBox TabTextBox
        {
            get { return textBoxText; }
        }
    }
}
