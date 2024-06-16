using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    internal class AtmApplication
    {
        //initializing private bank variable from bank class    
        private Bank bank;

        public AtmApplication()
        {
            bank = new Bank();
        }

        //Starting the customer transactions
        public void Start()
        {
            //setting customerExit default to false at first interaction
            bool customerExit = false;

            while (!customerExit)
            {
                //displating the atm menu to the customer
                DisplayATMMainMenu();
                string customerChoice = Console.ReadLine();

                switch (customerChoice)
                {
                    case "1":
                        CreateBankAccount();
                        break;
                    case "2":
                        SelectAccount();
                        break;
                    case "3":
                        customerExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid customerChoice. Please select again.");
                        break;
                }
            }
        }


        //helper method to display the atm main menu
        private void DisplayATMMainMenu()
        {
            Console.WriteLine("=====WELCOME TO THE ATM APPLICATION=======");
            Console.WriteLine("choose the following options by the number associated with the option");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your Choice to start with bank operations ");
        }

        //helper method to create bank account
        private void CreateBankAccount()
        {
            Console.Write("=====WELCOME CREATE ACCOUNT MENU========= ");
            Console.Write("Enter Account Number between integers 100 - 1000 ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Initial Balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Interest Rate  ");
            decimal interestRate = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Account Holder's Name: ");
            string accountHolderName = Console.ReadLine();

            //handling the exception if account number doesnt match with the requirements
            try
            {
                var account = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
                bank.AddAccount(account);
                Console.WriteLine("Account created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message is : {ex.Message}");
            }
        }

        private void SelectAccount()
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            var account = bank.RetrieveAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Sorry Account not found please check with correct account number");
                return;
            }

            bool exitAccountMenu = false;
            while (!exitAccountMenu)
            {
                Console.Write($"Welcome : {account.AccountHolderName}");
                Console.Write("please choose the following options");

                DisplayAccountMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Current Balance: {account.Balance:C}");
                        break;
                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        try
                        {
                            account.Deposit(depositAmount);
                            Console.WriteLine(" Amount Deposited successful. Done !");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        Console.Write("Enter the  amount to withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        try
                        {
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine("Withdrawal successful. Done!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Transaction History:");
                        //for each loop to display the list of transactions
                        foreach (var transaction in account.Transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        break;
                    case "5":
                        exitAccountMenu = ConfirmExitAccountMenu();
                        if (exitAccountMenu)
                        {
                            Console.WriteLine("Thanks for using the ATM application!");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid customerChoice. Please select again.");
                        break;
                }
            }
        }

        private void DisplayAccountMenu()
        {
            Console.WriteLine("\nAccount Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Display Transactions");
            Console.WriteLine("5. Exit Account");
            Console.Write("Enter your customerChoice: ");
        }

        private bool ConfirmExitAccountMenu()
        {
            Console.Write("Are you sure you want to exit? (y/n): ");
            string response = Console.ReadLine().ToLower();

            if (response == "y" || response == "yes")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Continuing in the application.");
                return false;
            }
        }
    }
}
