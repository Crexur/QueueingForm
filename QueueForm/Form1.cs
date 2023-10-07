using System;
using System.Windows.Forms;

namespace QueueForm
{
    public partial class QueuingForm : Form
    {
        private CustomerView customerView;
        private CashierClass cashier;

        public QueuingForm(CustomerView customerView)
        {
            InitializeComponent();
            cashier = new CashierClass();
            this.customerView = customerView;
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            string generatedNumber = cashier.CashierGeneratedNumber("P - ");
            CashierClass.getNumberInQueue = generatedNumber;
            CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);
            lblQueue.Text = generatedNumber;
        }

        private void QueuingForm_Load(object sender, EventArgs e)
        {
        }

    }
}