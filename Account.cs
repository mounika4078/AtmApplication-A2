using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    internal class Account
    {
        // Account  Properties
        public int AccountNumber { get;  set; }
        public decimal Balance { get;  set; }
        public decimal InterestRate { get;  set; } 
        public string AccountHolderName { get;  set; }
        public List<string> Transactions { get;  set; }

       
    }
}

