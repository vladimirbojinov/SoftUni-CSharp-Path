using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Vehicle;

public abstract class BaseVehicle : IDrive, IRefuel
{
	public BaseVehicle(double fuelQuantity, double fuelConsumptionPerKm)
	{
		FuelQuantity = fuelQuantity;
		FuelConsumptionPerKm = fuelConsumptionPerKm;
	}

	public double FuelQuantity { get; protected set; }
	public virtual double FuelConsumptionPerKm { get; }

	public void Drive(double distance)
	{
		if (FuelQuantity < 0) throw new ArgumentException($"{GetType().Name} needs refueling");

		double fuelUsed = FuelConsumptionPerKm * distance;
		if (fuelUsed > FuelQuantity) throw new ArgumentException($"{GetType().Name} needs refueling");

		FuelQuantity -= fuelUsed;
		Console.WriteLine($"{GetType().Name} travelled {distance} km");
	}

	public virtual void Refuel(double liters) => FuelQuantity += liters;
}
