using System.Xml.Linq;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> peoplesList = new List<People>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] personInformation = command.Split();
                string name = personInformation[0];
                string Id = personInformation[1];
                int age = int.Parse(personInformation[2]);
                People isPersonExisting = peoplesList.FirstOrDefault(x => x.Id == Id);
                if (isPersonExisting != null)
                {
                    isPersonExisting.Name = name;
                    isPersonExisting.Id = Id;
                    isPersonExisting.Age = age;
                }
                else
                {
                    People people = new People(name, Id, age);
                    peoplesList.Add(people);
                }

            }

            var sortedPeopleByAge = peoplesList.OrderBy(x => x.Age);
            foreach (People peoples in sortedPeopleByAge)
            {
                Console.WriteLine($"{peoples.Name} with ID: {peoples.Id} is {peoples.Age} years old.");
            }
        }
    }

    class People
    {
        public People(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}