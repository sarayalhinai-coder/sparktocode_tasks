namespace _1_7_task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter a number from 1 to 7: ");
            int day = int.Parse(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("sunday");
                    break;
                case 2:
                    Console.WriteLine("monday");
                    break;
                case 3:
                    Console.WriteLine("tuesday");
                    break;
                case 4:
                    Console.WriteLine("wednesday");
                    break;
                case 5:
                    Console.WriteLine("thursday");
                    break;
                case 6:
                    Console.WriteLine("friday");
                    break;
                case 7:
                    Console.WriteLine("saturday");
                    break;
                default:
                    Console.WriteLine("Invalid day number");
                    break;
            }

        }
    }
}
