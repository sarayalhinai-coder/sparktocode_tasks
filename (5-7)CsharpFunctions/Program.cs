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

            //task 2 
            Console.WriteLine("enter a number :");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("the square of "+n+" = "+Math.Pow(n,2));
            Console.WriteLine("the square root of " + n + " = " + Math.Sqrt(n));

            //task 3
            Console.WriteLine("enter your full name :");
            string name=Console.ReadLine();
            Console.WriteLine("name in upper case : "+name.ToUpper());
            Console.WriteLine("name in lower case : " + name.ToLower());
            Console.WriteLine("name length : " + name.Length);


        }
    }
}
