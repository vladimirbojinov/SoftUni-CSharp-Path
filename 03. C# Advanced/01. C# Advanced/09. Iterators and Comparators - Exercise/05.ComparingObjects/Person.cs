namespace _05.ComparingObjects
{
	public class Person : IComparable<Person>
	{
		public Person(string name, int age, string town)
		{
			Name = name;
			Age = age;
			Town = town;
		}

		public string Name { get; set; }
		public int Age { get; set; }
		public string Town { get; set; }

		public int CompareTo(Person? other)
		{
			if (other == null) return -1;

			int result = Comparer<string>.Default.Compare(Name, other.Name);
			if (result == 0) result = Comparer<int>.Default.Compare(Age, other.Age);
			if (result == 0) result = Comparer<string>.Default.Compare(Town, other.Town);

			return result;
		}
	}
}
