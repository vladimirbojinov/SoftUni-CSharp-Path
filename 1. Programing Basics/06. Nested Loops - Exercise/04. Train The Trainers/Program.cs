namespace _04._Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());

            int presentationGrade = 0;
            double average = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Finish")
                {
                    break;
                }

                string PresentationName = command;
                double gradeSum = 0;

                for (int i = 1; i <= judges; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                    presentationGrade++;
                    average += grade;
                }

                double presAverage = gradeSum / judges;
                Console.WriteLine($"{PresentationName} - {presAverage:f2}.");
            }

            Console.WriteLine($"Student's final assessment is {average / presentationGrade:f2}.");
        }
    }
}