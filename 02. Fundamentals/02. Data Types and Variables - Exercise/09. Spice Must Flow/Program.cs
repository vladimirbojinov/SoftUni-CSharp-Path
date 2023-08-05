namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int extractedYield = 0;
            int days = 0;

            while (yield >= 100)
            {
                days++;
                extractedYield += yield;
                extractedYield -= 26;
                yield -= 10;
            }

            if (extractedYield - 26 >= 0)
            {
                extractedYield -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(extractedYield);
        }
    }
}