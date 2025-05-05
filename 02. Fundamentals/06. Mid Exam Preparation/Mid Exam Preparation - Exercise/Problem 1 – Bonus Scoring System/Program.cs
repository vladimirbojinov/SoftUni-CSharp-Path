namespace Problem_1___Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int bestAttendance = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int studentAttendance = int.Parse(Console.ReadLine());

                double totalBonus = Math.Ceiling((double)studentAttendance / lecturesCount * (5 + bonus));

                if (maxBonus < totalBonus)
                {
                    maxBonus = totalBonus;
                    bestAttendance = studentAttendance;
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {bestAttendance} lectures.");
        }
    }
}