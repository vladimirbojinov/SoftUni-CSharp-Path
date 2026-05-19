using System.Linq;

namespace _05._Filter_By_Age
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			List<People> peopleList = new List<People>();
			FillClass(count, peopleList);

			Func<People, bool> filter (string condition, int age)
			{
				switch (condition)
				{
					case "younger": return x => x.Age < age;
					case "older": return x => x.Age >= age;
					default: return null;
				}
			}
			Action<People> printOptions (string condition)
			{
				switch (condition)
				{
					case "name": return x => Console.WriteLine(x.Name);
					case "age": return x => Console.WriteLine(x.Age);
					case "name age": return x => Console.WriteLine($"{x.Name} - {x.Age}");
					default: return null;
				}
			}

			string condition = Console.ReadLine();
			int ageThreshold = int.Parse(Console.ReadLine());
			string printCondition = Console.ReadLine();

			peopleList = peopleList
				.Where(filter(condition, ageThreshold))
				.ToList();

			peopleList.ForEach(printOptions(printCondition));
		}

		private static void FillClass(int count, List<People> people)
		{
			for (int i = 0; i < count; i++)
			{
				string[] data = Console.ReadLine()
					.Split(", ", StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				string name = data[0];
				int age = int.Parse(data[1]);

				People person = new People(name, age);
				people.Add(person);
			}
		}
	}

	public class People
	{
		public People(string name, int age)
		{
			Name = name;
			Age = age;
		}

        public string Name { get; set; }
		public int Age { get; set; }
	}
}
