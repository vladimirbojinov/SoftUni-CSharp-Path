namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int extractedSpices = int.Parse(Console.ReadLine());

            int currentSpices = 0;
            int days = 0;

            while (extractedSpices >= 100)
            {
                days++;
                currentSpices += extractedSpices;
                currentSpices -= 26;
                extractedSpices -= 10;
            }

            if (extractedSpices != 0 && extractedSpices - 26 > 0)
            {
                currentSpices -= 26; 
                Console.WriteLine(days);
                Console.WriteLine(currentSpices);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(currentSpices);
            }
        }
    }
}