namespace _05._Hair_Salon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double targetedMoney = double.Parse(Console.ReadLine());
            double totalMoney = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "closed")
                {
                    Console.WriteLine($"Target not reached! You need {targetedMoney - totalMoney}lv. more.");
                    Console.WriteLine($"Earned money: {totalMoney}lv.");
                    break;
                }

                string servies = command;

                if (servies == "haircut")
                {
                    string hairCutType = Console.ReadLine();

                    switch (hairCutType)
                    {
                        case "mens": totalMoney += 15.00; break;
                        case "ladies": totalMoney += 20.00; break;
                        case "kids": totalMoney += 10.00; break;
                    }
                }
                else
                {
                    string coloringCutType = Console.ReadLine();

                    switch (coloringCutType)
                    {
                        case "touch up": totalMoney += 20.00; break;
                        case "full color": totalMoney += 30.00; break;
                    }
                }

                if (totalMoney >= targetedMoney)
                {
                    Console.WriteLine($"You have reached your target for the day!");
                    Console.WriteLine($"Earned money: {totalMoney}lv.");
                    break;
                }
            }
        }
    }
}