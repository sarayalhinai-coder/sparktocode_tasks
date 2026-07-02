namespace _1_7_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number:");
            float x = float.Parse(Console.ReadLine());
            if (x % 2 == 0)
            {
                Console.WriteLine("number is even");
            }
            else
            {
                Console.WriteLine("number is odd");
            }


        }
    }
}
