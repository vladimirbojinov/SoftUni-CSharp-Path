namespace NeedForSpeed;

public class Vehicle
{
	private double fuel;
	private readonly int horsePower;
	private const double DefaultFuelConsumption = 1.25;

	public Vehicle(int horsePower, double fuel)
	{
		this.fuel = fuel;
		this.horsePower = horsePower;
	}

	public virtual double FuelConsumption { get; set; } = DefaultFuelConsumption;
	public double Fuel => this.fuel;
	public int HorsePower => this.horsePower;

	public virtual void Drive(double kilometers)
	{
		this.fuel -= this.FuelConsumption * kilometers;
	}
}