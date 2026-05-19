namespace _02.VehiclesExtension.Vehicles;

public class Car : BaseVehicle
{
	protected override double ConsumptionIncreaseByAc => 0.9;

	public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity) { }
}
