namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> raceTrack = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> leftRacer = new List<int>();
            List<int> rightRacer = new List<int>();

            for (int i = 0; i < raceTrack.Count / 2; i++)
            {
                leftRacer.Add(raceTrack[i]);
            }

            for (int j = raceTrack.Count - 1; j > raceTrack.Count / 2; j--)
            {
                rightRacer.Add(raceTrack[j]);
            }

            RaceWinner(leftRacer, rightRacer);
        }

        static void RaceWinner(List<int> leftRacer, List<int> rightRacer)
        {
            decimal leftRacerTime = 0;
            decimal rightRacerTime = 0;

            for (int i = 0; i < leftRacer.Count; i++)
            {
                if (leftRacer[i] == 0)
                {
                    leftRacerTime *= 0.8m;
                }
                else
                {
                    leftRacerTime += leftRacer[i];
                }
            }

            for (int j = 0; j < rightRacer.Count; j++)
            {
                if (rightRacer[j] == 0)
                {
                    rightRacerTime *= 0.8m;
                }
                else
                {
                    rightRacerTime += rightRacer[j];
                }
            }

            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacerTime}");
            }
        }
    }
}