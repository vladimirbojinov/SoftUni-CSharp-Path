namespace _08._Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int lenghtOfEpisode = int.Parse(Console.ReadLine());
            int lenghtOfBrakeTime = int.Parse(Console.ReadLine());

            double lunchTime = lenghtOfBrakeTime / 8.0;
            double timeForBreak = lenghtOfBrakeTime / 4.0;
            double leftTime = lenghtOfBrakeTime - lunchTime - timeForBreak;

            if (lenghtOfEpisode <= leftTime)
            {
                Console.WriteLine($"You have enough time to watch {filmName} and left with {Math.Ceiling(leftTime - lenghtOfEpisode)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {filmName}, you need {Math.Ceiling(lenghtOfEpisode - leftTime)} more minutes.");
            }
        }
    }
}