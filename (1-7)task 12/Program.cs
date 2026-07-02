namespace _1_7_task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter region code('A':local, 'B':national, 'C':international):");
            char region = char.Parse(Console.ReadLine());

            Console.WriteLine("enter package weight(kg):");
            float weight = float.Parse(Console.ReadLine());

            
            float base_cost = 0;
            float w_cost = 0;

            switch (region)
            {
                case 'A':
                    base_cost = 1; 
                    break;
                case 'B':
                    base_cost = 3; 
                    break;
                case 'C':
                    base_cost = 7; 
                    break;
                default:
                    Console.WriteLine("Invalid region");
                    return; 
            }

            
            if (weight > 10)
            {
                w_cost = 5.000f;
            }
            else if (weight > 5)
            {
                w_cost = 2.000f;
            }
            else
            {
                w_cost = 0.000f;
            }

            float final_cost = base_cost + w_cost;

            
            Console.WriteLine("base cost= " + base_cost+ " OMR");
            Console.WriteLine("extra charge= " + w_cost + " OMR");
            Console.WriteLine("total cost= " + final_cost+ " OMR");
        }
    }
}