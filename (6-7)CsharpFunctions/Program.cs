namespace _6_7_CsharpFunctions
{
    internal class Program
    {
        //task 1 function 
        static void PrintWelcome(string name)
        {
            Console.WriteLine("welcome " + name);
        }

        //task 2 function
        static int Square(int x) 
        {
            int sq = x*x ;
            return sq;
        }
        static void Main(string[] args)
        {
            //task 1 main 
            Console.WriteLine("enter your name ");
            string name=Console.ReadLine();
            PrintWelcome(name);

            //task 2 main 
            Console.WriteLine("enter number:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("the square of "+ x + " = "+Square(x));
        }
    }
}
