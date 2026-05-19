namespace PersonsInfo;

public class StartUp
{
	static void Main(string[] args)
	{
		int lines = int.Parse(Console.ReadLine());
		List<Person> persons = new();

		for (int i = 0; i < lines; i++)
		{
			try
			{
				string[] cmdArgs = Console.ReadLine().Split();
				Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
				persons.Add(person);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		Team team = new Team("SoftUni");

		foreach (Person person in persons)
		{
			team.AddPlayer(person);
		}

		Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
		Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
	}
}
