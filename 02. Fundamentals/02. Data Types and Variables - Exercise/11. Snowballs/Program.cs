namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            decimal bestSnowBallValue = 0m;
            int bestSnowBall = 0;
            int bestTime = 0;
            int bestQuality = 0;

            for (int i = 0; i < loops; i++)
            {
                int snowball = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                double calc = snowball / time;
                decimal snowballValue = (decimal)Math.Pow(calc, quality);

                if (snowballValue > bestSnowBall)
                {
                    bestSnowBallValue = snowballValue;
                    bestSnowBall = snowball;
                    bestTime = time;
                    bestQuality = quality;
                }
            }

            Console.WriteLine($"{bestSnowBall} : {bestTime} = {bestSnowBallValue} ({bestQuality})");
        }
    }
}