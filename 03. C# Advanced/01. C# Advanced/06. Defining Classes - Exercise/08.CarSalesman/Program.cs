namespace DefiningClasses;

internal class StartUp
{
	static void Main(string[] args)
	{
		List<Engine> engineList = GetEngineData();
		List<Car> carList = GetCarData(engineList);

        Console.WriteLine(string.Join("\n", carList));
    }

	private static List<Car> GetCarData(List<Engine> engineList)
	{
		List<Car> carList = new List<Car>();

		int carCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < carCount; i++)
		{
			string[] carData = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			string model = carData[0];
			string engineModel = carData[1];
			int? weight = null;
			string? color = null;

			Engine engine = engineList.FirstOrDefault(x => x.Model == engineModel);
			if (carData.Length == 3)
			{
				if (int.TryParse(carData[2], out int value)) weight = value;
				else color = carData[2];
			}
			else if (carData.Length == 4)
			{
				weight = int.Parse(carData[2]);
				color = carData[3];
			}

			Car car = new Car(model, engine, weight, color);
			carList.Add(car);
		}

		return carList;
	}

	private static List<Engine> GetEngineData()
	{
		List<Engine> engineList = new List<Engine>();

		int engineCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < engineCount; i++)
		{
			string[] engineData = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			string model = engineData[0];
			int power = int.Parse(engineData[1]);
			int? displacement = null;
			string? efficiency = null;

			if (engineData.Length == 3)
			{
				if (int.TryParse(engineData[2], out int value)) displacement = value;
				else efficiency = engineData[2];
			}
			else if (engineData.Length == 4)
			{
				displacement = int.Parse(engineData[2]);
				efficiency = engineData[3];
			}

			Engine engine = new Engine(model, power, displacement, efficiency);
			engineList.Add(engine);
		}

		return engineList;
	}
}
