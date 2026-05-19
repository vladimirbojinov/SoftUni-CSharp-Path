namespace DefiningClasses;

internal class Pokemon
{
	private string name;
	private string element;
	private double health;

	public Pokemon(string name, string element, double health)
	{
		Name = name;
		Element = element;
		Health = health;
	}

	public string Name { get; set; }
	public string Element { get; set; }
	public double Health { get; set; }
}
