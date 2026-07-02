namespace _1_7__task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter total bill amount:");
            float bill = float.Parse(Console.ReadLine());
            Console.WriteLine("are you a loyalty member?");
            bool member = bool.Parse(Console.ReadLine());
            if (member == true && bill > 20)
            {
                float discout = bill * (15 / 100);
                float newbill = bill - discout;
                Console.WriteLine("bill amount befor dicount: " + bill);
                Console.WriteLine("dicount amount: " + discout);
                Console.WriteLine("final amount to pay: " + newbill);
            }
            else
            {
                Console.WriteLine("bill amount befor dicount: " + bill);
                Console.WriteLine("dicount amount: 0  ");
                Console.WriteLine("final amount to pay: " + bill);
            }

        }
    }
}
