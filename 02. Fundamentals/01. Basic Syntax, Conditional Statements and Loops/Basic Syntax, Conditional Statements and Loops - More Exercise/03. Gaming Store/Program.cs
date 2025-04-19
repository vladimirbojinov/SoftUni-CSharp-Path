namespace RandomExerxice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double totalSpent = 0;

            string command;
            while ((command = Console.ReadLine()) != "Game Time")
            {
                double gamePrice = 0;

                switch (command)
                {
                    case "OutFall 4": gamePrice = 39.99; break;
                    case "CS: OG": gamePrice = 15.99; break;
                    case "Zplinter Zell": gamePrice = 19.99; break;
                    case "Honored 2": gamePrice = 59.99; break;
                    case "RoverWatch": gamePrice = 29.99; break;
                    case "RoverWatch Origins Edition": gamePrice = 39.99; break;
                    default: Console.WriteLine("Not Found"); break;
                }

                if (budget >= gamePrice && gamePrice != 0)
                {
                    totalSpent += gamePrice;
                    budget -= gamePrice;
                    Console.WriteLine($"Bought {command}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

                if (budget <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }

            if (budget > 0 && totalSpent > 0)
            {
                Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${budget:F2}");
            }
        }
    }
}