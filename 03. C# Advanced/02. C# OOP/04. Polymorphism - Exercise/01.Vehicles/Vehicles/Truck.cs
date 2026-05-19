using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Vehicle;

public class Truck : BaseVehicle, IRefuel
{
	private const double DefaultConsumptionIncreaseByAc = 1.6;
	private const double DefaultFuelLoseByPercent = 0.95;

	public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm) { }

	public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + DefaultConsumptionIncreaseByAc;

	public override void Refuel(double liters)
	{
		double literAfterLoss = liters * DefaultFuelLoseByPercent;
		base.Refuel(literAfterLoss);
	}
}
