namespace DefiningClasses
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			List<Person> personList = new List<Person>();		
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				string[] personData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				string name = personData[0];
				int age = int.Parse(personData[1]);

				Person person = new Person(name, age);
				personList.Add(person);
			}

			Func<Person, bool> filter = p => p.Age > 30;
			personList = personList
				.Where(filter)
				.OrderBy(x => x.Name)
				.ToList();

            Console.WriteLine(string.Join("\n", personList));
        }
	}
}