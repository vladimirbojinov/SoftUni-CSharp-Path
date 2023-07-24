namespace _05._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int extrasNumber = int.Parse(Console.ReadLine());
            double priceForOneExtra = double.Parse(Console.ReadLine());

            double moneyNeeded = 0;
            double decorPrice = budged * 0.10;
            double outfitsPrice = extrasNumber * priceForOneExtra;

            if (extrasNumber > 150)
            {
                outfitsPrice *= 0.90;
            }

            moneyNeeded += outfitsPrice + decorPrice;

            if (moneyNeeded >= budged)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded - budged:f2} leva more.");

            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budged - moneyNeeded:f2} leva left.");
            }
        }
    }
}