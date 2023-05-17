namespace _06._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double lenghtInMeter = double.Parse(Console.ReadLine());
            double timeInSecondsForMeter = double.Parse(Console.ReadLine());

            double timeForWholeDistance = lenghtInMeter * timeInSecondsForMeter;
            double slowedTime = Math.Floor(lenghtInMeter / 15);

            timeForWholeDistance += slowedTime * 12.5;

            if (timeForWholeDistance < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeForWholeDistance:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {timeForWholeDistance - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}