namespace _03.Raiding.Heroes;

public abstract class BaseHero
{
	protected BaseHero(string name, int power)
	{
		Name = name;
		Power = power;
	}

	public string Name { get; }
	public int Power { get; }

	public abstract string CastAbility();
}
