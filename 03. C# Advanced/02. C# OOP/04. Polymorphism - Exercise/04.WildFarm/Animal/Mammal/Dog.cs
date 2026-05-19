using _04.WildFarm.Foods;

namespace _04.WildFarm.Animal.Mammal;

internal class Dog : BaseMammal
{
	protected override double WeightGainPerPiece => 0.40;

	public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

	public override bool CanEat(BaseFood food) => food is Meat;

	public override string EmitSound() => "Woof!";
}
