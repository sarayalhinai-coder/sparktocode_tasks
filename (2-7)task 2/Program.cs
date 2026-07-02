namespace _2_7_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter whole number: ");
            int N = int.Parse(Console.ReadLine());
            int sum=0;
            for (int i = 0; i <= N; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine("sum= "+sum);
    }
}
}
