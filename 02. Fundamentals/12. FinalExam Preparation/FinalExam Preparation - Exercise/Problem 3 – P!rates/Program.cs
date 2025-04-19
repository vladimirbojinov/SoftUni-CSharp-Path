namespace Problem_3___P_rates
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, Town> townDictionary = new Dictionary<string, Town>();
            string command;
            while ((command = Console.ReadLine()) != "Sail")
            {
                string[] townInformation = command.Split("||");
                string townName = townInformation[0];
                int population = int.Parse(townInformation[1]);
                int gold = int.Parse(townInformation[2]);

                if (!townDictionary.ContainsKey(townName))
                {
                    Town townInfo = new Town();
                    townDictionary.Add(townName, townInfo);
                }

                townDictionary[townName].Name = townName;
                townDictionary[townName].Gold += gold;
                townDictionary[townName].Population += population;
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split("=>");

                switch (arguments[0])
                {
                    case "Plunder":
                        string townName = arguments[1];
                        int killedPeople = int.Parse(arguments[2]);
                        int stolenGold = int.Parse(arguments[3]);
                        Plunder(townName, stolenGold, killedPeople, townDictionary); break;
                    case "Prosper":
                        townName = arguments[1];
                        int earnedGold = int.Parse(arguments[2]);
                        Prosper(townName, earnedGold, townDictionary); break;
                }
            }

            if (townDictionary.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {townDictionary.Count} wealthy settlements to go to:");
                foreach (Town town in townDictionary.Values)
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
        }

        static void Prosper(string townName, int earnedGold, Dictionary<string, Town> townDictionary)
        {
            if (earnedGold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                townDictionary[townName].Gold += earnedGold;

                Console.WriteLine($"{earnedGold} gold added to the city treasury. {townName} now has {townDictionary[townName].Gold} gold.");
            }
        }
        static void Plunder(string townName, int stolenGold, int killedPeople, Dictionary<string, Town> townDictionary)
        {
            if (townDictionary.ContainsKey(townName))
            {
                townDictionary[townName].Gold -= stolenGold;
                townDictionary[townName].Population -= killedPeople;

                Console.WriteLine($"{townName} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

                if (townDictionary[townName].Gold <= 0 || townDictionary[townName].Population <= 0)
                {
                    Console.WriteLine($"{townName} has been wiped off the map!");
                    townDictionary.Remove(townName);
                }
            }
        }
    }

    public class Town
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}