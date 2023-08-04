namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();

            int carAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carAmount; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string carModel = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionPerKm = double.Parse(carData[2]);
                Car car = new Car(carModel, fuelAmount, fuelConsumptionPerKm);
                carList.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
                Car chosenCar = carList.FirstOrDefault(x => x.Model == arguments[1]);

                double distanceToTravel = double.Parse(arguments[2]);
                double fuelConsumed = chosenCar.FuelConsumptionPerKm * distanceToTravel;
                if (fuelConsumed > chosenCar.FuelAmount)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                else
                {
                    chosenCar.FuelAmount -= fuelConsumed;
                    chosenCar.TraveledDistance += distanceToTravel;
                }
            }

            Console.WriteLine(string.Join("\n", carList));
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