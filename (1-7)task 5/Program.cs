namespace _1_7_task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter grade character:");
            Console.WriteLine("1.A");
            Console.WriteLine("2.B");
            Console.WriteLine("3.C");
            Console.WriteLine("4.D");
            Console.WriteLine("5.F");
            int grade = int.Parse(Console.ReadLine());
            switch (grade)
            {
                case 1:
                    Console.WriteLine("Excellent");
                    break;
                case 2:
                    Console.WriteLine("Very Good");
                    break;
                case 3:
                    Console.WriteLine("Good");
                    break;
                case 4:
                    Console.WriteLine("Pass");
                    break;
                case 5:
                    Console.WriteLine("Fail");
                    break;
                default:
                    Console.WriteLine("Invalid grade");
                    break;
            }

        }
    }
}
