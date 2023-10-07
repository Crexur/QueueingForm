using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and initialize the QueuingForm and CustomerView forms
            CustomerView customerView = new CustomerView();
            QueuingForm queuingForm = new QueuingForm(customerView);
            CashierWindowQueueForm cashierForm = new CashierWindowQueueForm(customerView);


            // Show the QueuingForm and CustomerView forms concurrently
            queuingForm.Show();
            customerView.Show();
            cashierForm.Show();

            // Start the application's main message loop
            Application.Run();
        }
    }
}

