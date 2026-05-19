using _04.WildFarm.Foods;

namespace _04.WildFarm.Animal.Mammal.Feline;

internal class Tiger : BaseFeline
{
	protected override double WeightGainPerPiece => 1.00;

	public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }

	public override bool CanEat(BaseFood food) => food is Meat;

	public override string EmitSound() => "ROAR!!!";
}
