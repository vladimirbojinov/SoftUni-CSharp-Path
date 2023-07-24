namespace _05._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string place = "";
            double moneySpentPercentage = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    place = "Camp";
                    moneySpentPercentage = 0.3;
                }
                else
                {
                    place = "Hotel";
                    moneySpentPercentage = 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    place = "Camp";
                    moneySpentPercentage = 0.4;
                }
                else
                {
                    place = "Hotel";
                    moneySpentPercentage = 0.8;
                }
            }
            else
            {
                destination = "Europe";
                place = "Hotel";
                moneySpentPercentage = 0.9;
            }

            double moneySpent = budget * moneySpentPercentage;

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {moneySpent:f2}");
        }
    }
}