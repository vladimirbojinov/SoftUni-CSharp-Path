namespace DefiningClasses;

public class StartUp
{
	static void Main(string[] args)
	{
		int count = int.Parse(Console.ReadLine());
		Family family = new Family();

		for (int i = 0; i < count; i++)
		{
			string[] personData = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			string name = personData[0];
			int age = int.Parse(personData[1]);

			Person person = new Person(name, age);
			family.AddMember(person);
		}

		Person oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}
