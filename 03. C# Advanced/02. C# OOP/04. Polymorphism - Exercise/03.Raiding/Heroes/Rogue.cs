namespace _03.Raiding.Heroes;

public class Rogue : BaseHero
{
	private const int DefaultHeroPower = 80;

	public Rogue(string name, int power = DefaultHeroPower) : base(name, power) { }

	public override string CastAbility() => $"{nameof(Rogue)} - {this.Name} hit for {this.Power} damage";
}
