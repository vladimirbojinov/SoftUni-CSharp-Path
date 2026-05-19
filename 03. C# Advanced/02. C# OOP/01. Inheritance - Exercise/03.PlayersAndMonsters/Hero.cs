namespace PlayersAndMonsters;

internal class Hero
{
	private readonly string username;
	private readonly int level;

	public Hero(string username, int level)
	{
		this.username = username;
		this.level = level;
	}

	public string Username => this.username;
	public int Level => this.level;

	public override string ToString()
	{
		return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
	}
}
