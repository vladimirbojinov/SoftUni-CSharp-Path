using _04.WildFarm.Foods;

namespace _04.WildFarm.Animal.Bird;

internal class Hen : BaseBird
{
	protected override double WeightGainPerPiece => 0.35;

	public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

	public override bool CanEat(BaseFood food) => food is Vegetable or Fruit or Meat or Seeds;  

	public override string EmitSound() => "Cluck";
}
