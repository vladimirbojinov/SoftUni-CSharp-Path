namespace _07._Order_by_Age
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Person> people = new List<Person>();

			string command;
			while ((command = Console.ReadLine()) != "End")
			{
				string[] personData = command.Split();
				string name = personData[0];
				string id = personData[1];
				int age = int.Parse(personData[2]);

				Person person = people.FirstOrDefault(p => p.Id == id);
				if (person != null)
				{
					person.Name = name;
					person.Id = id;
					person.Age = age;
				}
				else
				{
					person = new Person(name, id, age);
					people.Add(person);
				}
			}

			List<Person> sortedPeopleByAge = people.OrderBy(x => x.Age).ToList();
			Console.WriteLine(string.Join("\n", sortedPeopleByAge));
		}
	}

	class Person
	{
		public Person(string name, string id, int age)
		{
			Name = name;
			Id = id;
			Age = age;
		}

		public string Name { get; set; }
		public string Id { get; set; }
		public int Age { get; set; }

		public override string ToString()
		{
			return $"{Name} with ID: {Id} is {Age} years old.";
		}
	}
}