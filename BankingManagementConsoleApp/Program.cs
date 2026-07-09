using System.Xml.Linq;

namespace BankingManagementConsoleApp
{
    internal class Program
    {
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();
        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. List all accounts");
                Console.WriteLine("7. Close ");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine() ?? "0");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; 
                }
                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        ShowAll();
                        break;
                    case 7:
                        CloseAccount();
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;


                }

            }
        }

        static void AddAccount()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine() ??"";

            Console.Write("Enter new account number: ");
            string accountnum = Console.ReadLine() ??"";
            if (accountNumbers.Contains(accountnum))
            {
                Console.WriteLine("ERROR: Account number already used");
                return;
            }
            
            Console.Write("Enter initial deposit amount (must not be negative) : ");
            double initial_deposit ;
            try
            {
                initial_deposit = double.Parse(Console.ReadLine() ?? "0");
                if (initial_deposit < 0)
                {
                    throw new ArgumentOutOfRangeException("Deposit amount must be positive");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: That wasn't a valid number.");
                return; 
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR: Deposit amount must not be negative.");
                return; 
            }
            customerNames.Add(name);
            accountNumbers.Add(accountnum);
            balances.Add(initial_deposit);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Account added successfully ");
            Console.WriteLine("Customer name : "+name);
            Console.WriteLine("Account number : " + accountnum);
            Console.WriteLine("Account balance : " + initial_deposit);
        }

        static void DepositMoney()
        {
            Console.Write("Enter account number:");
            string user_accountnum= Console.ReadLine() ??"";
            if (accountNumbers.Contains((user_accountnum))) 
            {
                int account_index = accountNumbers.IndexOf(user_accountnum);
                Console.Write("Enter deposit amount:");
                double amount;
                try
                {
                    amount = double.Parse(Console.ReadLine() ?? "0");
                    if (amount <= 0)
                    {
                        throw new ArgumentOutOfRangeException("ERROR: Deposit amount must be positive");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: That wasn't a valid number");
                    return;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("ERROR: Deposit amount must not be negative");
                    return;
                }
                balances[account_index] = balances[account_index] + amount;
                Console.WriteLine("Updated balance is " + balances[account_index]);
            }
            else
            {
                Console.WriteLine("ERROR: Account number not found");
            }
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter account number:");
            string user_accountnum = Console.ReadLine() ?? "";
            if (accountNumbers.Contains(user_accountnum)) 
            {
                int account_index = accountNumbers.IndexOf(user_accountnum);
                Console.Write("Enter withdraw amount:");
                double amount;
                try
                {
                    amount = double.Parse(Console.ReadLine() ?? "0");
                    if (amount <= 0)
                    {
                        throw new ArgumentOutOfRangeException("ERROR:withdraw amount must be positive");
                    }
                    if (amount > balances[account_index])
                    {
                        Console.WriteLine("ERROR: withdraw amount exceeds account balance");
                        return;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: That wasn't a valid number");
                    return;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("ERROR: Withdraw amount must be positive");
                    return;
                }
                balances[account_index] = balances[account_index] - amount;
                Console.WriteLine("Updated balance is " + balances[account_index]);
            }
            else
            {
                Console.WriteLine("ERROR: Account number not found");
            }
        }

        static void ShowBalance()
        {
            Console.Write("Enter account number:");
            string user_accountnum = Console.ReadLine() ?? "";
            if (accountNumbers.Contains(user_accountnum))
            {
                int account_index = accountNumbers.IndexOf(user_accountnum);
                Console.WriteLine("---Account details---");
                Console.WriteLine("Customer's name: "+customerNames[account_index]);
                Console.WriteLine("Account number: " + accountNumbers[account_index]);
                Console.WriteLine("Current balance: " + balances[account_index]);
            }
            else
            {
                Console.WriteLine("ERROR: Account number not found.");
            }
        }

        static void TransferAmount()
        {
            Console.Write("Enter sender's account number:");
            string sender_accountnum = Console.ReadLine() ?? "";
            Console.Write("Enter receiver's account number:");
            string receiver_accountnum = Console.ReadLine() ?? "";
            if (accountNumbers.Contains(sender_accountnum) && accountNumbers.Contains(receiver_accountnum))
            {
                int sender_index= accountNumbers.IndexOf(sender_accountnum);
                int receiver_index= accountNumbers.IndexOf(receiver_accountnum);

                Console.Write("Enter transfer amount :");
                double amount;
                try
                {
                    amount = double.Parse(Console.ReadLine() ?? "0");
                    if (amount <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Transfer amount must be positive");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: That wasn't a valid number.");
                    return;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("ERROR: Transfer amount must be positive.");
                    return;
                }
                if (amount > balances[sender_index])
                {
                    Console.WriteLine("ERROR: Transfer amount exceeds sender's balance.");
                }
                else
                {
                    balances[sender_index] = balances[sender_index] - amount;
                    balances[receiver_index] = balances[receiver_index] + amount;

                    Console.WriteLine("Transfer completed successfully");
                    Console.WriteLine("sender's balance: " + balances[sender_index]);
                    Console.WriteLine("receiver's balance: " + balances[receiver_index]);
                }
            }
            else
            {
                if (!accountNumbers.Contains(sender_accountnum))
                {
                    Console.WriteLine("ERROR: sender account number not found ");
                }
                if (!accountNumbers.Contains(receiver_accountnum))
                {
                    Console.WriteLine("ERROR: receiver account number not found ");
                }
            }
        }

        static void ShowAll()
        {
            Console.WriteLine("--- List of all accounts ---");
            for (int i=0; i < accountNumbers.Count; i++)
            {
                Console.WriteLine("Account number: "+ accountNumbers[i]);
                Console.WriteLine("Customer's name: " + customerNames[i]);
                Console.WriteLine("Current balance: " + balances[i]);
                Console.WriteLine("--------------------------------" );
            }
        }

        static void CloseAccount()
        {
            Console.Write("Enter account number:");
            string user_accountnum = Console.ReadLine() ?? "";
            if (accountNumbers.Contains(user_accountnum)) 
            {
                int account_index = accountNumbers.IndexOf(user_accountnum);
                string name = customerNames[account_index];
                double balance = balances[account_index];

                balances.RemoveAt(account_index);
                customerNames.RemoveAt(account_index);
                accountNumbers.RemoveAt(account_index);
                Console.WriteLine("Account closed successfully.");
                Console.WriteLine("Customer name: " + name);
                Console.WriteLine("Account number: " + user_accountnum);
                Console.WriteLine("Final balance: " + balance);
            }
            else
            {
                Console.WriteLine("ERROR: Account number not found.");
            }
        }
    }
}
