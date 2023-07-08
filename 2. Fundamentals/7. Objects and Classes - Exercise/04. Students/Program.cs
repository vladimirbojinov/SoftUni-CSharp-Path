namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> studentsList = new List<Students>();

            int studentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentCount; i++)
            {
                string[] studentId = Console.ReadLine()
                    .Split();
                string firstName = studentId[0];
                string lastName = studentId[1];
                double grade = float.Parse(studentId[2]);

                Students student = new Students(firstName, lastName, grade);
                studentsList.Add(student);
            }

            var sortedList = studentsList.OrderByDescending(x => x.Grade);
            Console.WriteLine(string.Join("\n", sortedList));
        }
    }

    class Students
    {
        public Students(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}