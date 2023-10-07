using System;
using System.Windows.Forms;

namespace QueueForm
{
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void lblNextNumber_Click(object sender, EventArgs e)
        {

        }
        public void UpdateNextNumber(string nextNumber)
        {
            lblNextNumber.Text = nextNumber;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
