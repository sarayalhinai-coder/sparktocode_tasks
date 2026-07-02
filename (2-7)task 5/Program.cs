namespace _2_7_task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 42;
            int counter = 0;
            int guess;
            do
            {
                Console.WriteLine("enter guess:");
                guess = int.Parse(Console.ReadLine());
                counter = counter + 1;
                if (x > guess)
                {
                    Console.WriteLine("too low");
                }
                else if (x < guess)
                {
                    Console.WriteLine("too high");
                }
            } while (x != guess);

            Console.WriteLine("correct , it took "+ counter+" attempts");
        }
    }
}
