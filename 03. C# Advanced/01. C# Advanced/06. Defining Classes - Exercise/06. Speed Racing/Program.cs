namespace DefiningClasses;

internal class StartUp
{
	static void Main(string[] args)
	{
		Dictionary<string, Car> carMap = GetCarData();

		string command;
		while ((command = Console.ReadLine()) != "End")
		{
			string[] operation = command
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			string model = operation[1];
			int distance = int.Parse(operation[2]);

			if (carMap.ContainsKey(model))
			{
				Car car = carMap[model];
				car.Drive(distance);
			}
		}

        Console.WriteLine(string.Join("\n", carMap.Values));
    }

	private static Dictionary<string, Car> GetCarData()
	{
		Dictionary<string, Car> carMap = new Dictionary<string, Car>();
		int count = int.Parse(Console.ReadLine());

		for (int i = 0; i < count; i++)
		{
			string[] carData = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			string model = carData[0];
			double fuelAmount = double.Parse(carData[1]);
			double fuelConsumptionPerKm = double.Parse(carData[2]);

			if (!carMap.ContainsKey(model))
			{
				Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
				carMap[model] = car;
			}
		}

		return carMap;
	}
}
