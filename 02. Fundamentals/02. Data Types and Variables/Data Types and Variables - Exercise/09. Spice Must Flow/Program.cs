namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int spiceYield = int.Parse(Console.ReadLine());
            int extractedSpice = 0;
            int days = 0;

            while (spiceYield >= 100)
            {
                days++;
                extractedSpice += spiceYield;
                extractedSpice -= 26;
                spiceYield -= 10;
            }

			extractedSpice = Math.Max(0, extractedSpice - 26);
			Console.WriteLine(days);
			Console.WriteLine(extractedSpice);
        }
    }
}