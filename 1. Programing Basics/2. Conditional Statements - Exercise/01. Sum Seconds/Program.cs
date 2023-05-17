namespace _01._Sum_Seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int extrasNumber = int.Parse(Console.ReadLine());
            double PriceForOneExtra = double.Parse(Console.ReadLine());

            double MoneyNeeded = budged * 0.1;
            double OutfitsPrice = extrasNumber * PriceForOneExtra;

            if (extrasNumber > 150)
            {
                OutfitsPrice = OutfitsPrice * 0.9;
            }

            MoneyNeeded += OutfitsPrice;

            if (MoneyNeeded >= budged)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {MoneyNeeded - budged:f2} leva more.");

            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budged - MoneyNeeded:f2} leva left.");
            }
        }
    }
}