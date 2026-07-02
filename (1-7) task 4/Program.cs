namespace _1_7__task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("do you have a valid national ID: ");
            bool ID = bool.Parse(Console.ReadLine());
            if (ID == true && age > 18)
            {
                Console.WriteLine("you are eligible to vote");
            }
            else
            {
                Console.WriteLine("you are NOT eligible to vote");
            }


        }
    }
}
