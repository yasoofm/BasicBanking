namespace BasicBanking
{
    using Spectre.Console;
    using System.Runtime.CompilerServices;
    using System.Transactions;
    using static System.Console;
    internal class Program
    {
        static void Main(string[] args)
        {
            string name, accountInput, balanceInput;
            int accountNum;
            decimal amount;
            decimal balance;
            int choice;

            List<decimal> transactions = new List<decimal>();

            

            do
            {
                name = AnsiConsole.Ask<string>("Enter your name: ");

                Write("Enter your account number: ");
                accountInput = ReadLine();

                Write("Enter initial balance: ");
                balanceInput = ReadLine();
            } while (!(int.TryParse(accountInput, out accountNum) && decimal.TryParse(balanceInput, out balance)));
            
            BankAccount account = new BankAccount(name: name, accountNum: accountNum, balance: balance);
            WriteLine();

            do
            {
                WriteLine("Enter the number of the selected option");
                WriteLine("1 - Deposit");
                WriteLine("2 - Withdraw");
                WriteLine("3 - View Balance");
                WriteLine("4 - Exit");
                Write("Enter choice: ");
                int.TryParse(ReadLine(), out choice);
                WriteLine();

                switch (choice)
                {
                    case 1:
                        WriteLine("Deposit");
                        Write("Enter deposit amount: ");
                        decimal.TryParse(ReadLine(), out amount);
                        account.Deposit(amount);
                        WriteLine();
                        break;
                    case 2:
                        WriteLine("Withdraw");
                        Write("Enter withdrawal amount: ");
                        decimal.TryParse(ReadLine(), out amount);
                        account.Withdraw(amount);
                        WriteLine();
                        break;
                    case 3:
                        WriteLine("View Balance");
                        account.GetBalance();
                        WriteLine();
                        break;
                    case 4:
                        WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Invalid choice\n");
                        WriteLine();
                        break;
                }
            } while (true);
            /*
            void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                    transactions.Add(amount);
                }
                else
                {
                    WriteLine("Invalid amount input");
                }
            }

            void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= balance)
                {
                    balance -= amount;
                    transactions.Add(amount * -1);
                }
                else
                {
                    WriteLine("Invalid amount input");
                }
            }

            void GetBalance()
            {
                WriteLine($"Balance: {balance}");
                WriteLine("Transactions:");
                foreach (var transaction in transactions)
                {
                    if (transaction > 0)
                    {
                        WriteLine($"Deposit {transaction}");
                    }
                    else
                    {
                        WriteLine($"Withdrawal {transaction * -1}");
                    }
                }
            }
            */
        }
    }
}
