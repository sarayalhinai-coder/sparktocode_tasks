namespace _2_7_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter starting number :");
            int start = int.Parse(Console.ReadLine());
            for (int i = start; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("lift off !");
        }
    }
}
