namespace _02._Movie_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int filmigTime = int.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int takenTime = int.Parse(Console.ReadLine());

            double prepTime = filmigTime * 0.15;
            double filmingTimeTaken = (scenes * takenTime) + prepTime;

            if (filmigTime >= filmingTimeTaken)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(filmigTime - filmingTimeTaken)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(filmingTimeTaken - filmigTime)} minutes.");
            }
        }
    }
}