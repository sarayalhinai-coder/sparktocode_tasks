namespace _1_7__task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your age:");
            int age11 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter your income:");
            float income = float.Parse(Console.ReadLine());
            Console.WriteLine("do you have any existing loan (yes/no):");
            string loanInput = Console.ReadLine().ToLower();
            bool loan = (loanInput == "yes");

            if (age11 >= 21 && age11 <= 60 && income >= 400 && !loan)
            {
                Console.WriteLine("you are eligible for loan");
            }
            else
            {
                if (age11 < 21 || age11 > 60)
                {
                    Console.WriteLine("age out of range");
                }
                else if (income < 400)
                {
                    Console.WriteLine("income too low ");
                }
                else if (loan == true)
                {
                    Console.WriteLine("has existing loan");
                }
            }

        }
    }
}
