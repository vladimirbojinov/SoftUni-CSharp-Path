namespace _04.WildFarm.Animal.Mammal.Feline;

internal abstract class BaseFeline : BaseMammal
{
	protected BaseFeline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
	{
		Breed = breed;
	}

	public string Breed { get; }

	public override string ToString()
		=> $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
}
