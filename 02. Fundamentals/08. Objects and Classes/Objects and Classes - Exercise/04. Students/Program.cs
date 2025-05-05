namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int studentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentCount; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split();
                string firstName = studentData[0];
                string lastName = studentData[1];
                double grade = float.Parse(studentData[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

			List<Student> sortedStudents = students.OrderByDescending(s => s.Grade).ToList();
            Console.WriteLine(string.Join("\n", sortedStudents));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
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