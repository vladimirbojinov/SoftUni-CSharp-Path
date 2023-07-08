namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> studentsList = new List<Students>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] studentId = command.Split();
                string name = studentId[0];
                string lastName = studentId[1];
                int age = int.Parse(studentId[2]);
                string homeTown = studentId[3];

                Students student = new Students(name, lastName, age, homeTown);
                studentsList.Add(student);
            }

            string searchedHomeTown = Console.ReadLine();
            foreach (Students student in studentsList)
            {
                if (student.HomeTown == searchedHomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Students
    {
        public Students(string firstName, string lastName, int age, string homeTown)
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