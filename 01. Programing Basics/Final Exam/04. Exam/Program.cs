namespace _04._Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentAtend = int.Parse(Console.ReadLine());

            double group1 = 0;
            double group2 = 0;
            double group3 = 0;
            double group4 = 0;

            double avg = 0;

            for (int i = 0; i < studentAtend; i++)
            {
                double studentGrade = double.Parse(Console.ReadLine());

                if (studentGrade >= 5.00)
                {
                    group1++;
                }
                else if (studentGrade >= 4.00)
                {
                    group2++;
                }
                else if (studentGrade >= 3.00)
                {
                    group3++;
                }
                else
                {
                    group4++;
                }

                avg += studentGrade;
            }
            double group1Percent = (group1 / studentAtend) * 100;
            double group2Percent = (group2 / studentAtend) * 100;
            double group3Percent = (group3 / studentAtend) * 100;
            double group4Percent = (group4 / studentAtend) * 100;

            Console.WriteLine($"Top students: {group1Percent:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {group2Percent:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {group3Percent:f2}%");
            Console.WriteLine($"Fail: {group4Percent:f2}%");
            Console.WriteLine($"Average: {avg / studentAtend:f2}");
        }
    }
}