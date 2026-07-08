namespace _7_7_DataCollections
{
    internal class Program
    {

        //task 9 function 
        static double CalculateAverage(List<int> gradesList)
        {
            int sum = 0;
            foreach (int grade in gradesList)
            {
                sum += grade;
            }
            return sum / gradesList.Count;
        }

        static int FindFirstFailing(List<int> gradesList)
        {
            return gradesList.Find(x => x < 60);
        }

        //task 10 function 
        static Queue<string> RemoveJob(Queue<string> oldQueue, string targetJob)
        {
            Queue<string> filteredQueue = new Queue<string>();
            while (oldQueue.Count > 0)
            {
                string currentJob = oldQueue.Dequeue();
                if (currentJob != targetJob)
                {
                    filteredQueue.Enqueue(currentJob);
                }
            }

            return filteredQueue;
        }

        static void PrintQueue(Queue<string> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            foreach (string job in queue)
            {
                Console.WriteLine(job);
            }
        }

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
            

            //task 8 
            Stack<string> actions = new Stack<string>();
            while (true)
            {
                Console.WriteLine("enter action or type 'stop' to exit : ");
                string action = Console.ReadLine();
                if (action == "stop")
                {
                    break;
                }
                actions.Push(action);
            }
            actions.Pop();
            actions.Pop();
            Console.WriteLine("--actions list--");
            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }

            //task 9 
            Console.Write("How many grades do you want to enter? ");
            int count = int.Parse(Console.ReadLine() );

            List<int> gradees = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter grade: ");
                int grade = int.Parse(Console.ReadLine());
                gradees.Add(grade);
            }
            Console.WriteLine("the average grade = "+CalculateAverage(gradees));

            int firstFailing = FindFirstFailing(gradees);
            if (firstFailing == 0)
            {
                Console.WriteLine("First Failing Grade: No failing grades found!");
            }
            else
            {
                Console.WriteLine("First Failing Grade: "+firstFailing);
            }
            
            //task 10 
            Queue<string> jobs = new Queue<string>();
            while (true)
            {
                Console.WriteLine("add job or type 'done' to exit : ");
                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                jobs.Enqueue(input);
            }
            Console.WriteLine("Queue Before Cancellation : ");
            PrintQueue(jobs);

            Console.WriteLine("enter one job to cancel : ");
            string cancel=Console.ReadLine();
            jobs = RemoveJob(jobs, cancel);

            Console.WriteLine("Queue after Cancellation : ");
            PrintQueue(jobs);


        }
    }
}
