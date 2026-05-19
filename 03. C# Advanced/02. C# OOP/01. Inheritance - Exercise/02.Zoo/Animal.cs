namespace Zoo;

internal class Animal
{
	private readonly int name;

	public Animal(int name)
	{
		this.name = name;
	}

	public int Name => this.name;
}
