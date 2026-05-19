namespace _05.ComparingObjects
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Person> peopleList = new List<Person>();

			string command;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] personData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

				string name = personData[0];
				int age = int.Parse(personData[1]);
				string town = personData[2];

				Person person = new Person(name, age, town);
				peopleList.Add(person);
			}

			int indexToCompare = int.Parse(Console.ReadLine());
			Person personToCompare = peopleList[indexToCompare - 1];

			int totalMatches = 0;
			int totalUnequalPeople = 0;

			for (int i = 0; i < peopleList.Count; i++)
			{
				if (peopleList[i].CompareTo(personToCompare) == 0) totalMatches++;
				else totalUnequalPeople++;
			}

			if (totalMatches == 1) Console.WriteLine($"No matches");
			else Console.WriteLine($"{totalMatches} {totalUnequalPeople} {peopleList.Count}");
		}
	}
}
