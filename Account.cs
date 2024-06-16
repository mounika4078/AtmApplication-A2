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

        // Constructor to initialize the account classs
        public Account(int accountNumber, decimal initialBalance, decimal interestRate, string accountHolderName)
        {
            if (accountNumber < 100 || accountNumber > 1000)
                throw new ArgumentException("Account number must be between 100 and 1000.");
            if (initialBalance < 100)
                throw new ArgumentException("Initial balance must be greater than or equal to 100.");
            if (interestRate < 0 || interestRate > 100)
                throw new ArgumentException("Interest rate must be between 0% and 100%.");

            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolderName = accountHolderName;
            Transactions = new List<string>();
        }

        // Method to deposit the money
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.");

            Balance += amount;
            Transactions.Add($"Deposited successfully: {amount:C}");
        }


        //method to withdraw tthe money
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException(" please enter Withdrawal amount  greater than zero.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds present in the account");

            Balance -= amount;
            Transactions.Add($"Withdrew amount of : {amount:C}");
        }

        //bmethod to calculate the interest
        public void CalculateInterest()
        {
            decimal interest = Balance * (InterestRate / 100);
            Balance += interest;
            Transactions.Add($"Interest added: {interest:C}");
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Holder: {AccountHolderName}, Balance: {Balance:C}, Interest Rate: {InterestRate}%";
        }
    }
}

