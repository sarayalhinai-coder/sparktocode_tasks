namespace _12_7_OOP1
{

    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string? HolderName { get; set; }
        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            Balance += amount;
            SendEmail();
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("ERROR: withdraw amount exceeds account balance");
                return;
            }
            else
            {
                Balance -= amount;
            }
            SendEmail();
        }

        public double CheckBalance()
        {
            PrintInformation();
            return Balance;
        }
        private void PrintInformation()
        {
            Console.WriteLine("Holder name: " + HolderName);
            Console.WriteLine("Balance: " + Balance);
        }

        private void SendEmail()
        {
            Console.WriteLine(" ");//place holder
        }

    }

    public class Student()
    {
        public int Grade;
        public string? Name;
        public string? Address;
        private string? Email;
        int age;

        public void Register(string email)
        {
            Email = email;
            SendEmail();
        }
        private void SendEmail()
        {
            Console.WriteLine(" ");//place holder
        }
    }

    public class Product()
    {
        public string? ProductName;
        public double Price;
        public int StockQuantity;

        public void Sell(int quantity)
        {
            if (quantity > StockQuantity)
            {
                Console.WriteLine("not enough stock");
                LogTransaction();
                return;
            }
            else
            {
                StockQuantity -= quantity;
                LogTransaction();
            }
        }

        public void Restock(int quantity)
        {
            StockQuantity += quantity;
            LogTransaction();
        }

        public double GetInventoryValue()
        {
            PrintDetails();
            Console.WriteLine("total inventory value: "+ Price * StockQuantity);
            return Price * StockQuantity;
        }

        private void LogTransaction()
        {
            Console.WriteLine("Transaction logged ");
        }

        private void PrintDetails()
        {
            Console.WriteLine("Product name: " + ProductName);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Stock quantity: " + StockQuantity);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.AccountNumber = 1163;
            bankAccount1.HolderName = "Karim";
            bankAccount1.Balance = 120;

            BankAccount bankAccount2 = new BankAccount();
            bankAccount2.AccountNumber = 15203;
            bankAccount2.HolderName = "Ali";
            bankAccount2.Balance = 63;

            Student student1 = new Student();
            student1.Name = "Ali";
            student1.Address = "Muscat";
            student1.Grade = 65;

            Student student2 = new Student();
            student2.Name = "Ahmed";
            student2.Address = "Muscat";
            student2.Grade = 70;

            Product product1 = new Product();
            product1.ProductName = "Wireless Mouse";
            product1.Price = 5.5;
            product1.StockQuantity = 50;

            Product product2 = new Product();
            product2.ProductName = "Mechanical Keyboard";
            product2.Price = 15.75;
            product2.StockQuantity = 20;

            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\nOOP Part 1 - Bank / Student / Product Manager");
                Console.WriteLine("1. View Account Details");
                Console.WriteLine("2. Update Student Address");
                Console.WriteLine("3. Make a Deposit");
                Console.WriteLine("4. Make a Withdrawal");
                Console.WriteLine("5. View Product Details");
                Console.WriteLine("6. Register a Student");
                Console.WriteLine("7. Compare Two Account Balances");
                Console.WriteLine("8. Restock Product & Stock Level Check");
                Console.WriteLine("9. Transfer Between Accounts");
                Console.WriteLine("10. Update Student Grade (Validated)");
                Console.WriteLine("11. Student Report Card");
                Console.WriteLine("12. Account Health Status");
                Console.WriteLine("13. Bulk Sale With Revenue Calculation");
                Console.WriteLine("14. Scholarship Eligibility Check");
                Console.WriteLine("15. Full Balance Top-Up Flow");
                Console.WriteLine("16. Quick Account Opening (Parameterized Constructor)");
                Console.WriteLine("17. Total Students Counter (Static Field & Method)");
                Console.WriteLine("18. Overdrawn Account Check (Read-Only Property)");
                Console.WriteLine("19. Set Student Security PIN (Write-Only Property)");
                Console.WriteLine("20. Exit");
                Console.Write("Choose an option: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine() ?? "0");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
                    continue;
                }
                switch (choice)
                {
                    case 1: 
                        Console.WriteLine("pick one of the two Bank Accounts(1 or 2): ");
                        try
                        {
                            int account_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (account_choice == 1)
                            {
                                bankAccount1.CheckBalance();
                            }
                            else if (account_choice == 2)
                            {
                                bankAccount2.CheckBalance();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Pick one of the two students(1 or 2): ");
                        try
                        {
                            int student_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (student_choice == 1)
                            {
                                Console.WriteLine("Enter new address: ");
                                string new_address = Console.ReadLine()??"";
                                student1.Address= new_address;
                                Console.WriteLine("Adress changed. new addres: "+student1.Address);

                            }else if (student_choice == 2)
                            {
                                Console.WriteLine("Enter new address: ");
                                string new_address = Console.ReadLine() ?? "";
                                student2.Address = new_address;
                                Console.WriteLine("Adress changed. new addres: " + student2.Address);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 3:
                        Console.WriteLine("pick one of the two Bank Accounts(1 or 2): ");
                        try
                        {
                            int account_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (account_choice == 1)
                            {
                                Console.WriteLine("Enter deposit amount: ");
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
                                    continue;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("ERROR: Deposit amount must not be negative");
                                    continue;
                                }
                                bankAccount1.Deposit(amount);
                                bankAccount1.CheckBalance();
                            }
                            else if (account_choice == 2)
                            {
                                Console.WriteLine("Enter deposit amount: ");
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
                                    continue;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("ERROR: Deposit amount must not be negative");
                                    continue;
                                }
                                bankAccount2.Deposit(amount);
                                bankAccount2.CheckBalance();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 4:
                        Console.WriteLine("pick one of the two Bank Accounts(1 or 2): ");
                        try
                        {
                            int account_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (account_choice == 1)
                            {
                                Console.WriteLine("Enter withdrawal amount: ");
                                double amount;
                                try
                                {
                                    amount = double.Parse(Console.ReadLine() ?? "0");
                                    if (amount <= 0)
                                    {
                                        throw new ArgumentOutOfRangeException("ERROR: withdrawal amount must be positive");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("ERROR: That wasn't a valid number");
                                    continue;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("ERROR: Deposit amount must not be negative");
                                    continue;
                                }
                                bankAccount1.Withdraw(amount);
                                bankAccount1.CheckBalance();
                            }
                            else if (account_choice == 2)
                            {
                                Console.WriteLine("Enter withdrawal amount: ");
                                double amount;
                                try
                                {
                                    amount = double.Parse(Console.ReadLine() ?? "0");
                                    if (amount <= 0)
                                    {
                                        throw new ArgumentOutOfRangeException("ERROR: withdrawal amount must be positive");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("ERROR: That wasn't a valid number");
                                    continue;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("ERROR: Deposit amount must not be negative");
                                    continue;
                                }
                                bankAccount2.Withdraw(amount);
                                bankAccount2.CheckBalance();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 5:
                        Console.WriteLine("pick one of the two products (1 or 2): ");
                        try
                        {
                            int product_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (product_choice == 1)
                            {
                                product1.GetInventoryValue();
                            }
                            else if (product_choice == 2)
                            {
                                product2.GetInventoryValue();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 6:
                        Console.WriteLine("Pick one of the two students(1 or 2): ");
                        try
                        {
                            int student_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (student_choice == 1)
                            {
                                Console.WriteLine("Enter email: ");
                                string user_email= Console.ReadLine()??"";
                                student1.Register(user_email);
                                Console.WriteLine("Email added ");

                            }
                            else if (student_choice == 2)
                            {
                                Console.WriteLine("Enter email: ");
                                string user_email = Console.ReadLine()??"";
                                student2.Register(user_email);
                                Console.WriteLine("Email added ");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 7:
                        if (bankAccount1.Balance > bankAccount2.Balance)
                        {
                            Console.WriteLine("Bank account 1 has more money");
                        }
                        else if (bankAccount1.Balance < bankAccount2.Balance)
                        {
                            Console.WriteLine("Bank account 2 has more money");
                        }else if (bankAccount1.Balance == bankAccount2.Balance)
                        {
                            Console.WriteLine("Both accounts have the same amount of money");
                        }
                        break;

                    case 8:
                        Console.WriteLine("pick one of the two products (1 or 2): ");
                        try
                        {
                            int product_choice = int.Parse(Console.ReadLine() ?? "0");
                            if (product_choice == 1)
                            {
                                Console.WriteLine("Enter a quantity to add");
                                int quantity = int.Parse(Console.ReadLine() ?? "0");
                                product1.Restock(quantity);
                                if (product1.StockQuantity <10)
                                {
                                    Console.WriteLine("Stock level low ");
                                }else if (10 <= product1.StockQuantity && 49>=product1.StockQuantity)
                                {
                                    Console.WriteLine("Stock level moderate ");
                                }else if (product1.StockQuantity >= 50)
                                {
                                    Console.WriteLine("Product is well stocked");
                                }
                            }
                            else if (product_choice == 2)
                            {
                                Console.WriteLine("Enter a quantity to add");
                                int quantity = int.Parse(Console.ReadLine() ?? "0");
                                product2.Restock(quantity);
                                if (product2.StockQuantity < 10)
                                {
                                    Console.WriteLine("Stock level low ");
                                }
                                else if (10 <= product2.StockQuantity && 49 >= product2.StockQuantity)
                                {
                                    Console.WriteLine("Stock level moderate ");
                                }
                                else if (product2.StockQuantity >= 50)
                                {
                                    Console.WriteLine("Product is well stocked");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }
                        break;

                    case 9:
                        Console.WriteLine("Select source account (1 or 2): ");
                        try
                        {
                            int srcChoice = int.Parse(Console.ReadLine()??"");
                            BankAccount source;
                            if (srcChoice == 1)
                            {
                                source = bankAccount1;
                            }
                            else
                            {
                                source = bankAccount2;
                            }

                            Console.WriteLine("Select destination account (1 or 2): ");
                            int destChoice = int.Parse(Console.ReadLine()??"0");
                            BankAccount destination;
                            if (destChoice == 1)
                            {
                                destination = bankAccount1;
                            }
                            else
                            {
                                destination= bankAccount2;
                            }

                            Console.WriteLine("Enter amount to transfer: ");
                            double transferAmount = double.Parse(Console.ReadLine()??"0");

                            if (source.Balance >= transferAmount)
                            {
                                source.Withdraw(transferAmount);
                                destination.Deposit(transferAmount);
                                Console.WriteLine("Transfer successful");
                            }
                            else
                            {
                                Console.WriteLine("Transfer failed: insufficient balance in source account");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input");
                        }
                        break;

                    case 10:
                        Console.WriteLine("Select student (1 or 2): ");
                        try
                        {
                            int studentChoice = int.Parse(Console.ReadLine());
                            Student selectedStudent = studentChoice == 1 ? student1 : student2;

                            Console.WriteLine("Enter new grade: ");
                            int newGrade = int.Parse(Console.ReadLine());

                            if (newGrade < 0 || newGrade > 100)
                            {
                                Console.WriteLine("Invalid grade: must be between 0 and 100");
                            }
                            else
                            {
                                selectedStudent.Grade = newGrade;
                                Console.WriteLine("Grade updated successfully");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input: grade must be a number");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 20.");
                        break;
                }
            }

        }
    }
}
