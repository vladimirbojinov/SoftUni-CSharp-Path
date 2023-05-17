namespace _02._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());

            int badGradeCount = 0;
            int gradeCount = 0;
            int problems = 0;
            string lastProblem = "";

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Enough")
                {
                    double average = gradeCount * 1.0 / problems;
                    Console.WriteLine($"Average score: {average:f2}");
                    Console.WriteLine($"Number of problems: {problems}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                lastProblem = command;
                gradeCount += grade;

                if (grade <= 4)
                {
                    badGradeCount++;
                }

                if (badGradeCount == badGrades)
                {
                    Console.WriteLine($"You need a break, {badGradeCount} poor grades.");
                    break;
                }

                problems++;
            }
        }
    }
}