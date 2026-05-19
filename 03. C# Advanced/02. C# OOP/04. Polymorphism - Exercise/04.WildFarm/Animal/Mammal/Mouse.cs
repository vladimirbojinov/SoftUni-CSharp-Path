using _04.WildFarm.Foods;

namespace _04.WildFarm.Animal.Mammal;

internal class Mouse : BaseMammal
{
	protected override double WeightGainPerPiece => 0.10;

	public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

	public override bool CanEat(BaseFood food) => food is Vegetable or Fruit;

	public override string EmitSound() => "Squeak";
}
