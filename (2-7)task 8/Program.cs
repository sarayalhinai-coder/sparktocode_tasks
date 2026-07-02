namespace _2_7_task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a positive whole number:");
            int N = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                if (i % 2 == 0)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine("sum= "+sum);
    }
}
}
