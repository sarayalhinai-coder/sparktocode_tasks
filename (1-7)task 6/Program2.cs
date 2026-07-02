namespace _1_7_task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a temperature in Celsius:");
            float ctep = float.Parse(Console.ReadLine());
            float ftemp = (ctep * 9 / 5) + 32;
            Console.WriteLine("temperature in fahrenheit= " + ftemp);
            if (ctep < 10)
            {
                Console.WriteLine("cold");
            }
            else if (ctep > 10 && ctep < 30)
            {
                Console.WriteLine("mid");
            }
            else if (ctep < 30)
            {
                Console.WriteLine("hot");
            }

        }
    }
}
