namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

			double bestSnowBallValue = 0;
            int bestSnowBall = 0;
            int bestSnowBallTime = 0;
            int bestSnowBallQuality = 0;

            for (int i = 0; i < loops; i++)
            {
                int snowball = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

				double snowballValue = Math.Pow(snowball / time, quality);

                if (snowballValue > bestSnowBallValue)
                {
                    bestSnowBallValue = snowballValue;
                    bestSnowBall = snowball;
                    bestSnowBallTime = time;
                    bestSnowBallQuality = quality;
                }
            }

            Console.WriteLine($"{bestSnowBall} : {bestSnowBallTime} = {bestSnowBallValue} ({bestSnowBallQuality})");
        }
    }
}