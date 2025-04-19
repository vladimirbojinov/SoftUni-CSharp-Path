namespace Problem_3___Hearth_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            int cupidIndex = 0;

            string command;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] arguments = command.Split();

                int jumpLength = int.Parse(arguments[1]);
                int landedPlace = jumpLength + cupidIndex;

                if (landedPlace >= neighborhood.Length)
                {
                    cupidIndex = 0;
                    landedPlace = 0;
                }

                if (neighborhood[landedPlace] == 0)
                {
                    Console.WriteLine($"Place {landedPlace} already had Valentine's day.");
                }
                else
                {
                    cupidIndex = landedPlace;
                    neighborhood[landedPlace] -= 2;
                    if (neighborhood[landedPlace] == 0)
                    {
                        Console.WriteLine($"Place {landedPlace} has Valentine's day.");
                    }
                }

            }

            int failedHouses = 0;
            foreach (int house in neighborhood)
            {
                if (house > 0)
                {
                    failedHouses++;
                }
            }

            Console.WriteLine($"Cupid's last position was {cupidIndex}.");
            if (failedHouses == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }
        }
    }
}