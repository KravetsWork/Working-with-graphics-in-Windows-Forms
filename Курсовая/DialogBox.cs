using System;
using System.Windows.Forms;

namespace Coursework
{
    public partial class DialogBox : Form
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {    
            Close();
        }
    }
}
