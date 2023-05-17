namespace _02._Bonus_Score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            double bonus = 0.0;

            if (points <= 100)
            {
                bonus = 5;
            }
            else if (points <= 1000)
            {
                bonus = points * 0.2;
            }
            else
            {
                bonus = points * 0.1;
            }

            bool even = points % 2 == 0;

            if (even)
            {
                bonus = bonus + 1;
            }

            bool endFive = points % 10 == 5;

            if (endFive)
            {
                bonus = bonus + 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(points + bonus);
        }
    }
}