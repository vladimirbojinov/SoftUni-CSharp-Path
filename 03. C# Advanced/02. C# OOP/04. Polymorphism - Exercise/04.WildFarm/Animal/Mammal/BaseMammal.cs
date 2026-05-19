namespace _04.WildFarm.Animal.Mammal;

internal abstract class BaseMammal : BaseAnimal
{
	public BaseMammal(string name, double weight, string livingRegion) : base(name, weight)
	{
		LivingRegion = livingRegion;
	}

	public string LivingRegion { get; }

	public override string ToString()
		=> $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
}
