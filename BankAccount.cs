using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BasicBanking
{
    internal class BankAccount
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        private List<decimal> Transactions = new List<decimal>();

        public BankAccount(string name, int accountNum, decimal balance)
        {
            Name = name;
            AccountNumber = accountNum;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount input");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Transactions.Add(amount * -1);
            }
            else
            {
                Console.WriteLine("Invalid amount input");
            }
        }

        public void GetBalance()
        {
            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine("Transactions:");
            foreach (var transaction in Transactions)
            {
                if (transaction > 0)
                {
                    Console.WriteLine($"Deposit {transaction}");
                }
                else
                {
                    Console.WriteLine($"Withdrawal {transaction * -1}");
                }
            }
        }
    }
}
