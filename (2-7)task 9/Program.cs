namespace _2_7_task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool validInput= false;
            do
            {
                try
                {
                    Console.Write("Enter a positive whole number: ");
                    number = int.Parse(Console.ReadLine());
                    if (number <= 0)
                    {
                        Console.WriteLine("error: The number must be greater than zero");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("error: That is not a valid whole number. try again");
                }
            } while (!validInput);
            {
                int sum = 0;
                for (int i = 1; i <= number; i++)
                {
                    sum += i;
                }
                Console.WriteLine("sum= " + sum);

            }
            
        }
    }
}
