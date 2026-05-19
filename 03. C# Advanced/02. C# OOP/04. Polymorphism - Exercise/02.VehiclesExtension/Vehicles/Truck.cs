namespace _02.VehiclesExtension.Vehicles;

public class Truck : BaseVehicle
{
	protected override double ConsumptionIncreaseByAc => 1.6;
	private const double DefaultFuelLoseByPercent = 0.95;

	public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity) { }

	public override void Refuel(double liters)
	{
		double literAfterLoss = liters * DefaultFuelLoseByPercent;

		if (TankCapacity < liters) base.Refuel(liters);
		else base.Refuel(literAfterLoss);
	}
}
