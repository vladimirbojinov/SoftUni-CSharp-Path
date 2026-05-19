namespace Restaurant;

public class Coffee : HotBeverage
{
	private const decimal CoffeePrice = 3.50m;
	private const double CoffeeMilliliters = 50;
	private readonly double caffeine;

	public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
	{
		this.caffeine = caffeine;
	}

	public double Caffeine => this.caffeine;
}
