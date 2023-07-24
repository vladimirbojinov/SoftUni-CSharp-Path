namespace Problem_1
{

    /*
12
6
4430
9.8
5.5
620.3
840.2
960.1
220
340
674
365
345.5
212
412.12
258
496
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());

            double totalWater = days * players * waterPerPerson;
            double totalFood = days * players * foodPerPerson;

            int currentDay = 0;

            for (int i = 0; i < days; i++)
            {

                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;

                if (energy <= 0)
                {
                    break;
                }

                currentDay++;

                if (currentDay % 2 == 0)
                {
                    energy *= 1.05;
                    totalWater *= 0.70;
                }

                if (currentDay % 3 == 0)
                {
                    energy *= 1.10;
                    totalFood /= players;
                }
            }

            if (energy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
            }
        }
    }
}