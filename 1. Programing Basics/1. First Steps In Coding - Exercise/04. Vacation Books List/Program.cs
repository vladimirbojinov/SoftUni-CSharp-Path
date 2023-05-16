namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int numPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysToRead = int.Parse(Console.ReadLine());
            //calulations
            int timeToRead = numPages / pagesPerHour;
            int requeredHours = timeToRead / daysToRead;
            //output
            Console.WriteLine(requeredHours);
        }
    }
}