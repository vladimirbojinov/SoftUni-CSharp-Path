namespace _02.VehiclesExtension.Vehicles;

internal class Bus : BaseVehicle
{
	protected override double ConsumptionIncreaseByAc => 1.4;
	public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity) { }

}
