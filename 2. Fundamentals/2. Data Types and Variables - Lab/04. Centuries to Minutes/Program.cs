namespace _04._Centuries_to_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal centry = decimal.Parse(Console.ReadLine());

            decimal year = centry * 100;
            decimal days = year * 365.2422m;
            long hours = (long)days * 24;
            long min = (long)hours * 60;
            Console.WriteLine($"{centry} centuries = {year} years = {(long)days} days = {(long)hours} hours = {(long)min} minutes");
        }
    }
}