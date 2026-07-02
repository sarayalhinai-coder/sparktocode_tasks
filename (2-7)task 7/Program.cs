namespace _2_7_task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("THE MENU:");
                Console.WriteLine("1) Say Hello");
                Console.WriteLine("2) Show Current Time-of-day Greeting");
                Console.WriteLine("3) Exit");

                try 
                {
                    Console.WriteLine("chose action: ");
                    int action = int.Parse(Console.ReadLine());
                    if (action == 1)
                    {
                        Console.WriteLine(" Hello");
                    }
                    else if (action == 2)
                    {
                        Console.WriteLine("good afternoon");
                    }
                    else if (action == 3)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("error:enter a valid number");
                }


            }
        }
    }
}
