namespace _03.Raiding.Heroes;

public class Druid : BaseHero
{
	private const int DefaultHeroPower = 80;

	public Druid(string name, int power = DefaultHeroPower) : base(name, power) { }

	public override string CastAbility() => $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
}
