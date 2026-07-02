namespace _2_7_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number : ");
            int x = int.Parse(Console.ReadLine());
            for (int i = 1; i <=10; i++)
            {
                Console.WriteLine(x + "x"+i+" = " + x*i);
            }
            
    }
}
}
