using _04.WildFarm.Foods;

namespace _04.WildFarm.Animal.Mammal.Feline;

internal class Cat : BaseFeline
{
	protected override double WeightGainPerPiece => 0.30;

	public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }
	
	public override bool CanEat(BaseFood food) => food is Vegetable or Meat;

	public override string EmitSound() => "Meow";
}
