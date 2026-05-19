namespace _03.Raiding.Heroes;

public class Warrior : BaseHero
{
	private const int DefaultHeroPower = 100;

	public Warrior(string name, int power = DefaultHeroPower) : base(name, power) { }

	public override string CastAbility() => $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
}
