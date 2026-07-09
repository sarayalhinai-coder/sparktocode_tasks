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
                Console.WriteLine("6. <your 1st custom service - choose a name>");
                Console.WriteLine("7. <your 2nd custom service - choose a name>");
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
                Console.WriteLine("ERROR: Acount number already used");
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
                    Console.WriteLine("ERROR: That wasn't a valid number.");
                    return;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("ERROR: Deposit amount must not be negative.");
                    return;
                }
                balances[account_index] = balances[account_index] + amount;
                Console.WriteLine("Updated balance is " + balances[account_index]);
            }
            else
            {
                Console.WriteLine("ERROR: Account number not found.");
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
                    Console.WriteLine("ERROR: That wasn't a valid number.");
                    return;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("ERROR: withdraw amount must not be negative.");
                    return;
                }
                balances[account_index] = balances[account_index] - amount;
                Console.WriteLine("Updated balance is " + balances[account_index]);
            }
            else
            {
                Console.WriteLine("ERROR: Account number not found.");
            }
        }

    }
}
