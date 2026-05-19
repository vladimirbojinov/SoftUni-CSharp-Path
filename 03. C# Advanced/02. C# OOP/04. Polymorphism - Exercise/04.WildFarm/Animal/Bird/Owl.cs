using _04.WildFarm.Foods;

namespace _04.WildFarm.Animal.Bird;

internal class Owl : BaseBird
{
	protected override double WeightGainPerPiece => 0.25;

	public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

	public override bool CanEat(BaseFood food) => food is Meat;

	public override string EmitSound() => "Hoot Hoot";
}
