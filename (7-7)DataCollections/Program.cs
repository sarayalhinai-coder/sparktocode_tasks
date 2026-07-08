namespace _7_7_DataCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1 
            int[] grades=new int[5];
            for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine("enter grade : ");
                grades[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("--the grades--");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }

            //task 2 
            List<string> tasks=new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("enter task : ");
                string task = Console.ReadLine();
                tasks.Add(task);
            }
            Console.WriteLine("-- tasks list ---");
            foreach(string a in tasks)
            {
                Console.WriteLine(a);
            }

        }
    }
}
