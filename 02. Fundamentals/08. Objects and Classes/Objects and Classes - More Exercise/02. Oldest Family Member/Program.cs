namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember);
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

		public override string ToString()
		{
			return $"{Name} {Age}";
		}
	}

    class Family
    {
        public Family()
        {
            FamilyList = new List<Person>();
        }

        public List<Person> FamilyList { get; set; }

        public void AddMember(Person familyMember)
        {
            FamilyList.Add(familyMember);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = null;
            int oldestAge = 0;

            foreach (Person person in FamilyList)
            {
                if (person.Age > oldestAge)
                {
                    oldestMember = person;
                    oldestAge = person.Age;
                }
            }

            return oldestMember;
        }
    }
}