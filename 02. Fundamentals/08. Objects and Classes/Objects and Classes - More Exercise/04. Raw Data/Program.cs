namespace _04._Raw_Data
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Car> cars = GetCars();

			string carFilter = Console.ReadLine();

			if (carFilter == "fragile")
			{
				List<Car> filteredCars = cars
					.Where(c => c.Cargo.Type == carFilter && c.Cargo.Weight < 1000)
					.ToList();
				Console.WriteLine(string.Join("\n", filteredCars));

			}
			else if (carFilter == "flamable")
			{
				List<Car> filteredCars = cars
					.Where(c => c.Cargo.Type == carFilter && c.Engine.Power > 250)
					.ToList();
				Console.WriteLine(string.Join("\n", filteredCars));
			}
		}

		private static List<Car> GetCars()
		{
			List<Car> cars = new List<Car>();

			int carCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < carCount; i++)
			{
				string[] data = Console.ReadLine().Split();

				string model = data[0];
				int engineSpeed = int.Parse(data[1]);
				int enginePower = int.Parse(data[2]);
				int cargoWeight = int.Parse(data[3]);
				string cargoType = data[4];

				Engine engine = new Engine(engineSpeed, enginePower);
				Cargo cargo = new Cargo(cargoWeight, cargoType);
				Car car = new Car(model, engine, cargo);

				cars.Add(car);
			}

			return cars;
		}
	}

	public class Car
	{
		public Car(string model, Engine engine, Cargo cargo)
		{
			Model = model;
			Engine = engine;
			Cargo = cargo;
		}

		public string Model { get; set; }
		public Engine Engine { get; set; }
		public Cargo Cargo { get; set; }

		public override string ToString()
		{
			return Model;
		}
	}

	public class Engine
	{
		public Engine(int speed, int power)
		{
			Speed = speed;
			Power = power;
		}

		public int Speed { get; set; }
		public int Power { get; set; }
	}

	public class Cargo
	{
		public Cargo(int weight, string type)
		{
			Weight = weight;
			Type = type;
		}

		public int Weight { get; set; }
		public string Type { get; set; }
	}
}
