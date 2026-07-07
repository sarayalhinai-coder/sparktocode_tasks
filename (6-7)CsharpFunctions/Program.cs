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

        //task 3 function 
        static double CelsiusToFahrenheit(double c)
        {
            double f = (c * 9 / 5) + 32;
            return f;
        }

        //task 4 function 
        static void DisplayMenu()
        {
            Console.WriteLine("3-option menu : ");
            Console.WriteLine("1) Start ");
            Console.WriteLine("2) Help ");
            Console.WriteLine("3) Exit)");
        }

        //task 5 function 
        static bool IsEven(int x) 
        {
            if ( x%2 ==0)
            {
                return true;
            }
            else
            {
                return false;
            }
         }

        //task 6 function 
        static double CalculateArea(double l , double w)
        {
            double area = w * l;
            return area;
        }
        static double CalculatePerimeter(double l, double w)
        {
            double Perimeter = 2*(l+w);
            return Perimeter;
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

            //task 3 main 
            Console.WriteLine("enter temperature in celsius:");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine( c + " in fahrenheit  = " + CelsiusToFahrenheit(c));

            //task 4 main 
            DisplayMenu();
            

            //task 5 main
            Console.WriteLine("enter number : ");
            int n = int.Parse(Console.ReadLine());
            if (IsEven(n))
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
            

            //task 6 main 
            Console.WriteLine("enter rectangle length: ");
            double l = double.Parse(Console.ReadLine());
            Console.WriteLine("enter rectangle width: ");
            double w = double.Parse(Console.ReadLine());

            Console.WriteLine(" rectangle area = "+CalculateArea(l,w));
            Console.WriteLine(" rectangle perimeter = " + CalculatePerimeter(l,w));
        }
    }
}
