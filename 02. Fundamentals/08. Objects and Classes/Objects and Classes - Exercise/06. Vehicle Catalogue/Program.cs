namespace _06._Vehicle_Catalogue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Vehicle> vehicles = new List<Vehicle>();

			string command;
			while ((command = Console.ReadLine()) != "End")
			{
				string[] argument = command.Split();
				string type = argument[0];
				string model = argument[1];
				string color = argument[2];
				double horsePower = double.Parse(argument[3]);

				Vehicle vehicle = new Vehicle(type, model, color, horsePower);
				vehicles.Add(vehicle);
			}

			while ((command = Console.ReadLine()) != "Close the Catalogue")
			{
				Vehicle vehicle = vehicles.FirstOrDefault(v => v.Model == command);
				if (vehicle != null)
				{
					string capitalizedType = Capitalization(vehicle.Type);
					Console.WriteLine($"Type: {capitalizedType}");
					Console.WriteLine($"Model: {vehicle.Model}");
					Console.WriteLine($"Color: {vehicle.Color}");
					Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
				}
			}

			double averageCarHorsePower = vehicles
				.Where(v => v.Type == "car")
				.Select(v => v.HorsePower)
				.DefaultIfEmpty()
				.Average();
			Console.WriteLine($"Cars have average horsepower of: {averageCarHorsePower:F2}.");

			double averageTruckHorsePower = vehicles
				.Where(v => v.Type == "truck")
				.Select(v => v.HorsePower)
				.DefaultIfEmpty()
				.Average();

			Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsePower:F2}.");
		}

		static string Capitalization(string type)
		{
			string restOfTheString = type[0].ToString().ToUpper();
			for (int i = 1; i < type.Length; i++)
			{
				restOfTheString += type[i].ToString();
			}

			string theWholeString = restOfTheString;
			return theWholeString;
		}
	}

	class Vehicle
	{
		public Vehicle(string type, string model, string color, double horsePower)
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