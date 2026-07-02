namespace _1_7_task_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of side A: ");
            double sideA = double.Parse(Console.ReadLine());

            Console.Write("Enter the length of side B: ");
            double sideB = double.Parse(Console.ReadLine());

            Console.Write("Enter the length of side C: ");
            double sideC = double.Parse(Console.ReadLine());
            if ((sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideB + sideC > sideA))
            {
                if (sideA == sideB && sideB == sideC)
                {
                    Console.WriteLine("The triangle is Equilateral");
                }
                else if (sideA == sideB || sideA == sideC || sideB == sideC)
                {
                    Console.WriteLine("The triangle is Isosceles ");
                }
                else
                {
                    Console.WriteLine("The triangle is Scalene");
                }
            }
            else
            {
                Console.WriteLine("Error: These side lengths do not form a valid triangle.");
            }

        }
    }
}
