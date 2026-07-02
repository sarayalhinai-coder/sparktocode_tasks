namespace _2_7__task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "Spark2026";
            Console.WriteLine("enter the password");
            string user_pass=Console.ReadLine();
            while (user_pass != password)
            {
                Console.WriteLine("Incorrect password, try again");
                Console.WriteLine("enter the password");
                user_pass = Console.ReadLine();
            }
            Console.WriteLine("Access Granted");
        }
    }
}
