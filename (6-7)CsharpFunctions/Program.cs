namespace _6_7_CsharpFunctions
{
    internal class Program
    {
        //task 1 function 
        static void PrintWelcome(string name)
        {
            Console.WriteLine("welcome " + name);
        }
        static void Main(string[] args)
        {
            //task 1 main 
            Console.WriteLine("enter your name ");
            string name=Console.ReadLine();
            PrintWelcome(name);
        }
    }
}
