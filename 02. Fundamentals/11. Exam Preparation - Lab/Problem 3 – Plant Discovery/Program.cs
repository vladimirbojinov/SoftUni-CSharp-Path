namespace Problem_3___Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plantInfo = new List<Plant>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split("<->");
                string plantName = arguments[0];
                int plantRarity = int.Parse(arguments[1]);

                Plant isPlantExisting = plantInfo.FirstOrDefault(x => x.Name == plantName);

                if (isPlantExisting == null)
                {
                    Plant plant = new Plant(plantName, plantRarity);
                    plantInfo.Add(plant);
                }
                else
                {
                    isPlantExisting.Rarity = plantRarity;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] arguments = command.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string plantName = arguments[1];
                Plant plantData = plantInfo.FirstOrDefault(x => x.Name == plantName);

                if (plantData != null)
                {
                    switch (arguments[0])
                    {
                        case "Rate": AddRating(plantData, int.Parse(arguments[2])); break;
                        case "Update": UpdateRarity(plantData, int.Parse(arguments[2])); break;
                        case "Reset": ResetRating(plantData); break;
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            
            Console.WriteLine("Plants for the exhibition:");
            Console.WriteLine(string.Join("\n", plantInfo));
        }

        static void AddRating(Plant plantData, int rating)
        {
            plantData.AddRating(rating);
        }
        static void UpdateRarity(Plant plantData, int newRarity)
        {
            plantData.UpdateRarity(newRarity);
        }
        static void ResetRating(Plant plantData)
        {
            plantData.ClearRating();
        }

        public class Plant
        {
            public Plant(string name, int rarity)
            {
                Name = name;
                Rarity = rarity;
                Rating = new List<int>();
            }

            public string Name { get; set; }
            public int Rarity { get; set; }
            public List<int> Rating { get; set; }

            public void AddRating(int rating)
            {
                Rating.Add(rating);
            }
            public void UpdateRarity(int rarity)
            {
                Rarity = rarity;
            }
            public void ClearRating()
            {
                Rating.Clear();
            }

            public override string ToString()
            {
                double average = 0;

                foreach (int rating in Rating)
                {
                    average += rating;
                }

                average /= Rating.Count;
                if (Rating.Count == 0)
                {
                    average = 0;
                }

                return $"- {Name}; Rarity: {Rarity}; Rating: {average:F2}";
            }
        }
    }
}