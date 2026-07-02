namespace _2_7__task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("enter first number : ");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("enter second number : ");
                int num2 = int.Parse(Console.ReadLine());

                int result = num1 / num2;
                Console.WriteLine("result= "+result);

            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("error: Cannot divide by zero");

            }
            catch (FormatException)
            {
                Console.WriteLine("error:enter a valid number");
            }
        }
    }
}
