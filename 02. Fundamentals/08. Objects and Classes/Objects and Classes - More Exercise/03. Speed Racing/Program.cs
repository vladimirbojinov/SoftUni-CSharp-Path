namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionPerKm = double.Parse(carData[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
				string carFilter = arguments[1];
				Car car = cars.FirstOrDefault(c => c.Model == carFilter);

                double distanceToTravel = double.Parse(arguments[2]);
                double fuelConsumed = car.FuelConsumptionPerKm * distanceToTravel;
                if (fuelConsumed > car.FuelAmount)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                else
                {
                    car.FuelAmount -= fuelConsumed;
                    car.TraveledDistance += distanceToTravel;
                }
            }

            Console.WriteLine(string.Join("\n", cars));
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TraveledDistance { get; set; }
        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TraveledDistance}";
        }
    }
}