namespace _01._PC_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cpuPriceInDollars = double.Parse(Console.ReadLine());
            double gpuPriceInDollars = double.Parse(Console.ReadLine());
            double ramPriceInDollars = double.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double cpuPriceInLeva = (cpuPriceInDollars * 1.57);
            double gpuPriceInLeva = (gpuPriceInDollars * 1.57);
            double ramPriceInLeva = (ramPriceInDollars * 1.57) * ramCount;

            double cpuPriceInLevaDiscount = cpuPriceInLeva - (cpuPriceInLeva * discount);
            double gpuPriceInLevaDiscount = gpuPriceInLeva - (gpuPriceInLeva * discount);
            double totalSum = cpuPriceInLevaDiscount + gpuPriceInLevaDiscount + ramPriceInLeva;


            Console.WriteLine($"Money needed - {totalSum:f2} leva.");
        }
    }
}