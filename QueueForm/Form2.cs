using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QueueForm
{
    public partial class CashierWindowQueueForm : Form
    {
        private CustomerView customerViewForm;
        public CashierWindowQueueForm(CustomerView customerViewForm)
        {
            InitializeComponent();
            this.customerViewForm = customerViewForm;
        }

        private void CashierWindowQueueForm_Load(object sender, EventArgs e)
        {
            listCashierQueue.View = View.Details;
            listCashierQueue.Columns.Add("Queue", 100);
        }

        public void UpdateListView(IEnumerable<string> data)
        {
            Invoke(new Action(() =>
            {
                listCashierQueue.Items.Clear();
                foreach (string item in data)
                {
                    ListViewItem listViewItem = new ListViewItem(item);
                    listCashierQueue.Items.Add(listViewItem);
                }
            }));
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listCashierQueue.Items.Clear();
            foreach (string obj in CashierClass.CashierQueue)
            {
                ListViewItem item = new ListViewItem(obj);
                listCashierQueue.Items.Add(item);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                string nextNumber = CashierClass.CashierQueue.Dequeue();
                customerViewForm.UpdateNextNumber(nextNumber);
                DisplayCashierQueue(CashierClass.CashierQueue); // Update the ListView
            }
            else
            {
                MessageBox.Show("Queue is empty");
            }
        }

        public void DisplayCashierQueue(IEnumerable<string> cashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (string obj in cashierList)
            {
                ListViewItem item = new ListViewItem(obj);
                listCashierQueue.Items.Add(item);
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
            RemoveCompletedTasks();
        }

        private void RemoveCompletedTasks()
        {
            var completedTasks = new List<string>();

            foreach (string task in CashierClass.CashierQueue)
            {
                if (IsTaskCompleted(task))
                {
                    completedTasks.Add(task);
                }
            }

            foreach (string task in completedTasks)
            {
                CashierClass.CashierQueue.Dequeue();
            }
        }

        private bool IsTaskCompleted(string task)
        {
            return task.StartsWith("P - ");
        }
    }
}