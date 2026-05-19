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

		decimal percentage = decimal.Parse(Console.ReadLine());
		persons.ForEach(p => p.IncreaseSalary(percentage));
		persons.ForEach(p => Console.WriteLine(p.ToString()));
	}
}
