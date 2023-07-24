namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family familyMember = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] memberData = Console.ReadLine().Split();
                string name = memberData[0];
                int age = int.Parse(memberData[1]);

                Person member = new Person(name, age);
                familyMember.AddFamily(member);
            }

            string oldestAge = familyMember.OldestAge();
            Console.WriteLine(oldestAge);
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
    }

    class Family
    {
        public Family()
        {
            FamilyList = new List<Person>();
        }

        public List<Person> FamilyList { get; set; }

        public void AddFamily(Person familyMember)
        {
            FamilyList.Add(familyMember);
        }

        public string OldestAge()
        {
            int maxAge = int.MinValue;
            string oldestMember = string.Empty;

            List<Person> list = FamilyList;
            foreach (Person person in list)
            {
                if (person.Age > maxAge)
                {
                    oldestMember = person.Name;
                    maxAge = person.Age;
                }
            }

            return $"{oldestMember} {maxAge}";
        }
    }
}