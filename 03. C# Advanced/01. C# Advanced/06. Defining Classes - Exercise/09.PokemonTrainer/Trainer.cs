namespace DefiningClasses;

internal class Trainer
{
	private string name;
	private int badgeCount;
	private List<Pokemon> pokemons;

	public Trainer(string name)
	{
		Name = name;
		Pokemons = new List<Pokemon>();
	}

	public string Name { get; set; }
	public int BadgeCount { get; set; }
	public List<Pokemon> Pokemons { get; set; }

	public override string ToString()
	{
		return $"{Name} {BadgeCount} {Pokemons.Count}";
	}
}
