namespace _1_7__task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("enter an operator : ");
            char op = char.Parse(Console.ReadLine());
            switch (op)
            {
                case '+':
                    Console.WriteLine("result: " + (num1 + num2));
                    break;
                case '-':
                    Console.WriteLine("result: " + (num1 - num2));
                    break;
                case '*':
                    Console.WriteLine("result: " + (num1 * num2));
                    break;
                case '/':
                    if (num2 == 0)
                        Console.WriteLine("Cannot divide by zero");
                    else
                        Console.WriteLine("result: " + (num1 / num2));
                    break;
                case '%':
                    if (num2 == 0)
                        Console.WriteLine("Cannot divide by zero");
                    else
                        Console.WriteLine("result: " + (num1 % num2));
                    break;
                default:
                    Console.WriteLine("invalid operator");
                    break;
            }

        }
    }
}
