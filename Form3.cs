using System;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class Form3 : Form
    {
        public Form3(string reminder)
        {
            InitializeComponent();
            textBox1.Text = reminder;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
