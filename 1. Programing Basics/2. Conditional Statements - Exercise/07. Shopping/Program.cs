namespace _07._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int GPU = int.Parse(Console.ReadLine());
            int CPU = int.Parse(Console.ReadLine());
            int RAM = int.Parse(Console.ReadLine());

            double priceOfGPU = GPU * 250.0;
            double priceOfCPU = priceOfGPU * 0.35;

            priceOfCPU = priceOfCPU * CPU;

            double priceOfRAM = priceOfGPU * 0.1;
            priceOfRAM = priceOfRAM * RAM;

            double totalMoney = priceOfGPU + priceOfCPU + priceOfRAM;

            if (GPU > CPU)
            {
                totalMoney = totalMoney * 0.85;
            }

            if (totalMoney <= budged)
            {
                Console.WriteLine($"You have {budged - totalMoney:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalMoney - budged:f2} leva more!");
            }
        }
    }
}