using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    internal class Bank
    {
        // Properties
        private List<Account> Accounts { get; set; }

        // Constructor
        public Bank()
        {
            Accounts = new List<Account>();

            // Creating  10 default accounts when initializing the constructor   
            Accounts.Add(new Account(100, 100, 3, "Mounika"));
            Accounts.Add(new Account(101, 100, 3, "Rachana"));
            Accounts.Add(new Account(102, 100, 3, "Rushitha"));
            Accounts.Add(new Account(103, 100, 3, "Reshma"));
            Accounts.Add(new Account(104, 100, 3, "sirisha"));
            Accounts.Add(new Account(105, 100, 3, "yashwnath"));
            Accounts.Add(new Account(106, 100, 3, "Rohan"));
            Accounts.Add(new Account(107, 100, 3, "John"));
            Accounts.Add(new Account(108, 100, 3, "David"));
            Accounts.Add(new Account(109, 100, 3, "Dameon"));
        }

        // Methods to add the bank account
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }


        //method to retrieve the account details
        public Account RetrieveAccount(int accountNumber)
        {
            return Accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
        }


        //method to display all accounts
        public void DisplayAllAccounts()
        {
            foreach (var account in Accounts)
            {
                Console.WriteLine(account);
            }
        }
    }
}
