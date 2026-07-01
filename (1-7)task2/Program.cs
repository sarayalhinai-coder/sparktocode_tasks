namespace _1_7_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter length of rectangle: ");
            float length = float.Parse(Console.ReadLine());
            Console.WriteLine("enter length of width: ");
            float width = float.Parse(Console.ReadLine());
            float area = length * width;
            float perimeter = 2 * (length + width);
            Console.WriteLine("area= " + area);
            Console.WriteLine("perimeter= " + perimeter);

        }
    }
}
