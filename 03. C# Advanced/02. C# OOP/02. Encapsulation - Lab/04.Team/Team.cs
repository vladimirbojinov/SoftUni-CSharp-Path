using System.Collections.ObjectModel;
namespace PersonsInfo;

public class Team
{
	private string name;
	private List<Person> firstTeam;
	private List<Person> reserveTeam;

	public Team(string name)
	{
		this.firstTeam = new List<Person>();
		this.FirstTeam = this.firstTeam.AsReadOnly();

		this.reserveTeam = new List<Person>();
		this.ReserveTeam = this.reserveTeam.AsReadOnly();

		this.name = name;
	}

	public ReadOnlyCollection<Person> FirstTeam { get; }
	public ReadOnlyCollection<Person> ReserveTeam { get; }

	public void AddPlayer(Person person)
	{
		if (person.Age < 40) firstTeam.Add(person);
		else reserveTeam.Add(person);
	}
}
