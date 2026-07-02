namespace _1_7__task_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter program type ('S' for Science, 'A' for Arts): ");
            char programType = char.Parse(Console.ReadLine());
            Console.Write("Enter your GPA (out of 4.0): ");
            float gpa = float.Parse(Console.ReadLine());
            Console.Write("Enter entrance exam score (out of 100): ");
            int examScore = int.Parse(Console.ReadLine());
            Console.Write("Do you have an extracurricular achievement?: ");
            bool achievement = bool.Parse(Console.ReadLine());

            double minGpa = 0;
            int minScore = 0;
            string programName = "";

            switch (programType)
            {
                case 'S':
                    minGpa = 3.0;
                    minScore = 75;
                    programName = "Science";
                    break;
                case 'A':
                    minGpa = 2.5;
                    minScore = 60;
                    programName = "Arts";
                    break;
                default:
                    Console.WriteLine("Invalid program type");
                    return;
            }
            if (gpa >= minGpa && examScore >= minScore)
            {
                Console.WriteLine("admitted");
            }
            else if (achievement == true)
            {
                Console.WriteLine("Conditionally Admitted");
            }
            else
            {
                Console.WriteLine("not admitted ");
            }

        }
    }
}
