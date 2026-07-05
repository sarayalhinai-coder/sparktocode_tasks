namespace _5_7_CsharpFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1  
            Console.WriteLine("enter first number :");
            int num1=int.Parse(Console.ReadLine());
            Console.WriteLine("enter second number :");
            int num2 = int.Parse(Console.ReadLine());

            int result = Math.Abs(num1 - num2);
            Console.WriteLine("final positive difference= "+result);


        }
    }
}
