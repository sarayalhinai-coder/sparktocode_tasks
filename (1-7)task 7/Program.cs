namespace _1_7_task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter age:");
            int aget = int.Parse(Console.ReadLine());
            if (aget >= 0 && aget <= 12)
            {
                Console.WriteLine("Children:2 OMR");
            }
            else if (aget >= 13 && aget <= 59)
            {
                Console.WriteLine("Adults:5 OMR");
            }
            else
            {
                Console.WriteLine("Seniors: 3 OMR");
            }


        }
    }
}
