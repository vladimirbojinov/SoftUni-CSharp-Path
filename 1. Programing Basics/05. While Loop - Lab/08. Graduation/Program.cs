namespace _08._Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double marks = 0.0;
            int excluded = 0;
            int grades = 1;

            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    excluded++;
                }
                if (excluded == 2)
                {
                    break;
                }

                grades++;
                marks += grade;
            }

            if (excluded == 2)
            {
                Console.WriteLine($"{name} has been excluded at {grades - 1} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {marks / 12:f2}");
            }
        }
    }
}