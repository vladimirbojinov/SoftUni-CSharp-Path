namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string homeTown = input[3];

                Student student = studentsList
                    .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                if (student == null)
                {
                    studentsList.Add(new Student(firstName, lastName, age, homeTown));
                }
                else
                {
                    student.HomeTown = homeTown;
                    student.Age = age;
                }
            }

            string homeTownFilter = Console.ReadLine();
            foreach (Student student in studentsList)
            {
                if (student.HomeTown == homeTownFilter)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}