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

            //task 3 
            Stack<string> history =new Stack<string>();
            for (int i = 0;i < 3; i++)
            {
                Console.WriteLine("enter website URL : ");
                string URL = Console.ReadLine();
                history.Push(URL);
            }
            Console.WriteLine("-- user history ---");
            for (int i = 0; i < 3; i++)
            {
                var removedItem = history.Pop();
                Console.WriteLine($"\nvisited URl : {removedItem}");
            }

            //task 4
            Queue<string> line = new Queue<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("enter customer name: ");
                string customer = Console.ReadLine();
                line.Enqueue(customer);
            }
            Console.WriteLine("-- serve customer ---");
            for (int i = 0; i < 3; i++)
            {
                var removedItem = line.Dequeue();
                Console.WriteLine($"\ncostomer: {removedItem}");
            }
            
            //task 5 
            int[] Grades = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("enter grade : ");
                Grades[i] = int.Parse(Console.ReadLine());
            }
            Grades.Sort();
            Console.WriteLine(" lowest grade = " + Grades[0]);
            Console.WriteLine(" highest grade = " + Grades[4]);
            float sum = 0;
            foreach (int i in Grades) 
            { 
                sum=sum+i;
            }
            Console.WriteLine(" the average ="+ sum/5);

            //task 6
            List<string> shopping= new List<string>();
            while (true)
            {
                Console.WriteLine("add item to cart or type 'done' to exit : ");
                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                shopping.Add(input);
            }
            Console.WriteLine("enter item to remove: ");
            string itemremove= Console.ReadLine();
            shopping.Remove(itemremove);

            Console.WriteLine("-- final list --");
            foreach (string item in shopping)
            {
                Console.WriteLine(item);
            }
            
            //task 7 
            List<int> scores = new List<int>();
            for (int i = 0;i < 5; i++)
            {
                Console.WriteLine("enter game score: ");
                scores.Add(int.Parse(Console.ReadLine()));
            }
            scores.Sort();
            scores.Reverse();
            Console.WriteLine("1st place: " + scores[0]);
            Console.WriteLine("2nd place: " + scores[1]);
            Console.WriteLine("3rd place: " + scores[2]);
        }
    }
}
