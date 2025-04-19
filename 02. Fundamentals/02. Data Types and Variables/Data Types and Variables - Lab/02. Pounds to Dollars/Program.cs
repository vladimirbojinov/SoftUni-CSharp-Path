namespace _02._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal britishPound = decimal.Parse(Console.ReadLine());

            decimal usDollars = britishPound * 1.31m;

            Console.WriteLine($"{usDollars:F3}");
        }
    }
}