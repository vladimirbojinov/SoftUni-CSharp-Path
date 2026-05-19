using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Vehicle;

public class Car : BaseVehicle, IRefuel
{
	private const double ConsumptionIncreaseByAc = 0.9;
	public Car(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm) { }

	public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + ConsumptionIncreaseByAc;
}
