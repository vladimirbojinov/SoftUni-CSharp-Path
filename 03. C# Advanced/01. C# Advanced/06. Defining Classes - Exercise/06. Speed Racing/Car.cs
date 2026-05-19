namespace DefiningClasses;

public class Car
{
	private string model;
	private double fuelAmount;
	private double fuelConsumptionPerKilometer;
	private double travelledDistance;

	public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
	{
		Model = model;
		FuelAmount = fuelAmount;
		FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
	}

	public string Model { get; set; }
	public double FuelAmount { get; set; }
	public double FuelConsumptionPerKilometer { get; set; }
	public double TravelledDistance { get; set; }

	public void Drive(int distance)
	{
		double fuelUsed = FuelConsumptionPerKilometer * distance;

		if (FuelAmount < fuelUsed)
		{
            Console.WriteLine("Insufficient fuel for the drive");
			return;
        }

		FuelAmount -= fuelUsed;
		TravelledDistance += distance;
	}

	public override string ToString()
	{
		return $"{Model} {FuelAmount:F2} {TravelledDistance}";
	}
}
