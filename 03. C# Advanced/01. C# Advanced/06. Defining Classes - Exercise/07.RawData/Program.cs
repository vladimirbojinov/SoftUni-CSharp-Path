namespace DefiningClasses;

public class StartUp
{
	static void Main(string[] args)
	{
		List<Car> carsList = GetCarData();

		Func<Car, bool> filterFragile = x => x.Tiers.Any(x => x.Pressure < 1);
		Func<Car, bool> filterFlammable = x => x.Engine.Power > 250;

		string cargoType = Console.ReadLine();
		switch (cargoType)
		{
			case "fragile": carsList = carsList
					.Where(c => c.Cargo.Type == "fragile")
					.Where(filterFragile)
					.ToList();
			break;
			case "flammable":
				carsList = carsList
					.Where(c => c.Cargo.Type == "flammable")
					.Where(filterFlammable)
					.ToList();
			break;
		}

        Console.WriteLine(string.Join("\n", carsList));
    }

	private static List<Car> GetCarData()
	{
		List<Car> carsList = new List<Car>();
		int count = int.Parse(Console.ReadLine());

		for (int i = 0; i < count; i++)
		{
			string[] carData = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			string model = carData[0];

			int engineSpeed = int.Parse(carData[1]);
			int enginePower = int.Parse(carData[2]);

			int cargoWeight = int.Parse(carData[3]);
			string cargoType = carData[4];

			double tire1Pressure = double.Parse(carData[5]);
			int tire1Age = int.Parse(carData[6]);

			double tire2Pressure = double.Parse(carData[7]);
			int tire2Age = int.Parse(carData[8]);

			double tire3Pressure = double.Parse(carData[9]);
			int tire3Age = int.Parse(carData[10]);

			double tire4Pressure = double.Parse(carData[11]);
			int tire4Age = int.Parse(carData[12]);

			Tire[] tires = new Tire[4]
			{
				new Tire(tire1Pressure, tire1Age),
				new Tire(tire2Pressure, tire2Age),
				new Tire(tire3Pressure, tire3Age),
				new Tire(tire4Pressure, tire4Age)
			};

			Engine engine = new Engine(engineSpeed, enginePower);
			Cargo cargo = new Cargo(cargoType, cargoWeight);

			Car car = new Car(model, engine, cargo, tires);
			carsList.Add(car);
		}

		return carsList;
	}
}
