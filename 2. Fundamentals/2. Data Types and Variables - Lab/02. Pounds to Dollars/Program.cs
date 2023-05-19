namespace _02._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal brittishPound = decimal.Parse(Console.ReadLine());

            decimal converterToUSDollar = brittishPound * 1.31m;

            Console.WriteLine($"{converterToUSDollar:f3}");
        }
    }
}