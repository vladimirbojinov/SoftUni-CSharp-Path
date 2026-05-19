using _02.VehiclesExtension.Interfaces;

namespace _02.VehiclesExtension.Vehicles;

public abstract class BaseVehicle : IDrive, IRefuel
{
	protected abstract double ConsumptionIncreaseByAc { get; }
	protected BaseVehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
	{
		FuelConsumptionPerKm = fuelConsumptionPerKm;
		TankCapacity = tankCapacity;

		if (tankCapacity < fuelQuantity) FuelQuantity = 0;
		else FuelQuantity = fuelQuantity;
	}

	public double FuelQuantity { get; protected set; }
	public virtual double FuelConsumptionPerKm { get; protected set; }
	public double TankCapacity { get; }

	public void Drive(double distance, bool isAcOn)
	{
		if (FuelQuantity < 0) throw new ArgumentException($"{GetType().Name} needs refueling");

		double totalFuelConsumption = FuelConsumptionPerKm;
		if (isAcOn) totalFuelConsumption += ConsumptionIncreaseByAc;

		double fuelUsed = totalFuelConsumption * distance;
		if (fuelUsed > FuelQuantity) throw new ArgumentException($"{GetType().Name} needs refueling");

		FuelQuantity -= fuelUsed;
		Console.WriteLine($"{GetType().Name} travelled {distance} km");
	}

	public virtual void Refuel(double liters)
	{
		if (liters <= 0) throw new ArgumentException($"Fuel must be a positive number");

		double totalLiters = liters + FuelQuantity;
		if (TankCapacity < totalLiters) throw new ArgumentException($"Cannot fit {liters} fuel in the tank");

		FuelQuantity += liters;
	}
}
