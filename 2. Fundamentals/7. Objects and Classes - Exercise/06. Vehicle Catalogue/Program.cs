namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicles> vehiclesList = new List<Vehicles>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] argument = command.Split();
                string type = argument[0];
                string model = argument[1];
                string color = argument[2];
                double horsePower = double.Parse(argument[3]);

                Vehicles vehicle = new Vehicles(type, model, color, horsePower);
                vehiclesList.Add(vehicle);
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicles findCar = vehiclesList.FirstOrDefault(x => x.Model == command);
                if (findCar != null)
                {
                    string capitalizedType = Capitalization(findCar.Type);
                    Console.WriteLine($"Type: {capitalizedType}");
                    Console.WriteLine($"Model: {findCar.Model}");
                    Console.WriteLine($"Color: {findCar.Color}");
                    Console.WriteLine($"Horsepower: {findCar.HorsePower}");
                }
            }

            double averageCarHorsePower = vehiclesList
                .Where(x => x.Type == "car")
                .Select(x => x.HorsePower)
                .DefaultIfEmpty()
                .Average();
            Console.WriteLine($"Cars have average horsepower of: {averageCarHorsePower:F2}.");

            double averageTruckHorsePower = vehiclesList
                .Where(x => x.Type == "truck")
                .Select(x => x.HorsePower)
                .DefaultIfEmpty()
                .Average();

            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsePower:F2}.");
        }

        static string Capitalization(string type)
        {
            string firstLetter = string.Empty;
            for (int i = 0; i < 1; i++)
            {
                firstLetter = type[0].ToString().ToUpper();
            }

            string restOfTheString = string.Empty;
            for (int i = 1; i < type.Length; i++)
            {
                restOfTheString += type[i].ToString();
            }

            string theWholeString = firstLetter + restOfTheString;
            return theWholeString;
        }
    }

    class Vehicles
    {
        public Vehicles(string type, string model, string color, double horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }
}