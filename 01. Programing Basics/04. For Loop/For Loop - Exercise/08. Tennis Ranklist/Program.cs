namespace _08._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int participated = int.Parse(Console.ReadLine());
            double startingPoints = double.Parse(Console.ReadLine());

            double earnedPoints = 0;
            int wins = 0;

            for (int i = 0; i < participated; i++)
            {
                string result = Console.ReadLine();

                if (result == "W")
                {
                    wins++;
                }
                switch (result)
                {
                    case "W": earnedPoints += 2000; break;
                    case "F": earnedPoints += 1200; break;
                    case "SF": earnedPoints += 720; break;
                }
            }

            startingPoints += earnedPoints;

            Console.WriteLine($"Final points: {startingPoints}");
            Console.WriteLine($"Average points: {Math.Floor(earnedPoints * 1.0 / participated)}");
            Console.WriteLine($"{wins * 1.0 / participated * 100:f2}%");
        }
    }
}