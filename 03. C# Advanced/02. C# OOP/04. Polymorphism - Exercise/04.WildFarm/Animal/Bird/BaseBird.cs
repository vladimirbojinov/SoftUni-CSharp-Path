namespace _04.WildFarm.Animal.Bird;

internal abstract class BaseBird : BaseAnimal
{
	protected BaseBird(string name, double weight, double wingSize) : base(name, weight)
	{
		this.WingSize = wingSize;
	}

	public double WingSize { get; }

	public override string ToString()
		=> $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
}
