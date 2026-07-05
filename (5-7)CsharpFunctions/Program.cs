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

            //task 4 
            Console.WriteLine("enter the number of days of a free trial : ");
            int days_free = int.Parse(Console.ReadLine());
            DateTime today = DateTime.Today;
            DateTime endoftrial = today.AddDays(days_free);
            string finaldate= endoftrial.ToString("yyyy-MM-dd");
            Console.WriteLine("free trial ends on : "+finaldate);

            //task 5 
            Console.WriteLine("enter exam score:");
            float score = float.Parse(Console.ReadLine());
            double rounded= Math.Round(score);
            Console.WriteLine("rounded score = "+rounded);
            if ( rounded>=0 &&  rounded < 60)
            {
                Console.WriteLine("you failed");
            }
            else if ( rounded>= 60 && rounded<=100)
            {
                Console.WriteLine("you passed ! ");
            }
            else
            {
                Console.WriteLine("input invalid");
            }

            //task 6 
            Console.WriteLine("enter a password : ");
            string password= Console.ReadLine();
            if (password.Length < 8 || (password.ToLower()).Contains("password"))
            {
                Console.WriteLine("password weak");
            }
            else
            {
                Console.WriteLine("password strong");
            }

            //task 7
            Console.WriteLine("enter name: ");
            string name1 = Console.ReadLine().Trim();
            Console.WriteLine("enter the same name : ");
            string name2 = Console.ReadLine().Trim();
            name1 = name1.ToLower();
            name2 = name2.ToLower();
            if (name1 == name2)
            {
                Console.WriteLine("match");
            }
            else
            {
                Console.WriteLine("no match");
            }
    }
}
}
