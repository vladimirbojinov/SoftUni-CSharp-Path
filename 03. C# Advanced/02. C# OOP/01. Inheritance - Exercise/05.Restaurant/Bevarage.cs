namespace Restaurant;

public class Beverage : Product
{
	private readonly double milliliters;

	public Beverage(string name, decimal price, double milliliters) : base(name, price)
	{
		this.milliliters = milliliters;
	}

	public double Milliliters => this.milliliters;
}
