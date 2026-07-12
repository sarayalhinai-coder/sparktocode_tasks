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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
