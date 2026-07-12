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
            Console.Write("current Balance: ");
            return Balance;
        }
        private void PrintInformation()
        {
            Console.WriteLine("Holder name: "+HolderName);
            Console.WriteLine("Balance: "+Balance);
        }

        private void SendEmail()
        {
            Console.WriteLine("Email has been sent");
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
            Console.WriteLine("Email has been sent");
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
            return Price * StockQuantity;
        }

        private void LogTransaction()
        {
            Console.WriteLine("Transaction logged ");
        }

        private void PrintDetails()
        {
            Console.WriteLine("Product name: "+ProductName);
            Console.WriteLine("Price: "+Price);
            Console.WriteLine("Stock quantity: "+StockQuantity);
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
            product2.StockQuantity = 20 ;
        }
    }
}
