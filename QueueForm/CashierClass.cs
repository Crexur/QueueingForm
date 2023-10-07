using System;
using System.Collections.Generic;

namespace QueueForm
{
    public class CashierClass
    {
        private int x;
        public static string getNumberInQueue = "";
        public static Queue<string> CashierQueue;

        public CashierClass()
        {
            x = 10000;
            CashierQueue = new Queue<string>();
        }

        public string CashierGeneratedNumber(string prefix)
        {
            x++;
            string cashierNumber = prefix + x.ToString();
            return cashierNumber;
        }
    }
}