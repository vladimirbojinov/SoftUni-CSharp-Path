namespace Animals;

public class Animal
{
	public Animal(string name, string favoriteFood)
	{
		this.Name = name;
		this.FavoriteFood = favoriteFood;
	}

	public string Name { get; }
	public string FavoriteFood { get; }

	public virtual string ExplainSelf()
	{
		return $"I am {this.Name} and my favorite food is {this.FavoriteFood}";
	}
}
