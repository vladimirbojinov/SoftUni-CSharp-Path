namespace _03.Raiding.Heroes;

public class Paladin : BaseHero
{
	private const int DefaultHeroPower = 100;

	public Paladin(string name, int power = DefaultHeroPower) : base(name, power) { }

	public override string CastAbility() => $"{nameof(Paladin)} - {this.Name} healed for {Power}";
}
