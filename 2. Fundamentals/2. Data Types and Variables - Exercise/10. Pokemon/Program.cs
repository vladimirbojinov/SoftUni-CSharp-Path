namespace _10._Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionY = int.Parse(Console.ReadLine());

            double halfPower = pokePowerN / 2;
            int poked = 0;

            while (pokePowerN >= distanceM)
            {
                pokePowerN -= distanceM;
                poked++;

                if (exhaustionY != 0 && pokePowerN == halfPower)
                {
                    pokePowerN /= exhaustionY;
                }
            }

            Console.WriteLine(pokePowerN);
            Console.WriteLine(poked);
        }
    }
}