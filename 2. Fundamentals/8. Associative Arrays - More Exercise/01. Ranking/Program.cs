using System.Net.Http.Headers;

namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> lecturesPasswords = new Dictionary<string, string>();

            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] arguments = command.Split(":");
                string contest = arguments[0];
                string password = arguments[1];

                lecturesPasswords.Add(contest, password);
            }

            List<Students> studentsList = new List<Students>();
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] arguments = command.Split("=>");
                string contest = arguments[0];
                string password = arguments[1];
                string username = arguments[2];
                int points = int.Parse(arguments[3]);

                Students isStudentExisting = studentsList.FirstOrDefault(x => x.Name == username);

                bool isPasswordCorrect = PasswordChecker(lecturesPasswords, contest, password);

                if (isStudentExisting == null && isPasswordCorrect)
                {
                    Students students = new Students(username, contest, points);
                    studentsList.Add(students);
                }
                else if (isStudentExisting != null)
                {
                    bool isPointsLesser = false;
                    foreach (var kvp in isStudentExisting.LectureAndPoints)
                    {
                        if (contest == kvp.Key && points < kvp.Value)
                        {
                            isPointsLesser = true;
                        }
                    }

                    if (!isPointsLesser)
                    {
                        isStudentExisting.AddLecture(contest, points);
                    }
                }
            }

            Dictionary<string, int> studentsMaxPoints = new Dictionary<string, int>();
            foreach (Students students in studentsList)
            {
                int points = 0;

                foreach (var point in students.LectureAndPoints)
                {
                    points += point.Value;
                }

                studentsMaxPoints.Add(students.Name, points);
            }

            string bestStudentName = studentsMaxPoints.Max(x => x.Key);
            int bestStudentPoints = studentsMaxPoints.Max(x => x.Value);

            List<Students> sortedList = studentsList
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine($"Best candidate is {bestStudentName} with total {bestStudentPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (Students ranking in sortedList)
            {
                Console.WriteLine(ranking.Name);

                var sortedPoints = ranking.LectureAndPoints.OrderByDescending(x => x.Value).ToList();
                foreach (var kvp in sortedPoints)
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }

        private static bool PasswordChecker(Dictionary<string, string> lecturesPasswords, string contest, string password)
        {
            var isLectureExisting = lecturesPasswords.FirstOrDefault(x => x.Key == contest);
            bool isPasswordCorrect = isLectureExisting.Value == password;
            return isPasswordCorrect;
        }

        class Students
        {
            public Students(string name, string lecture, int points)
            {
                Name = name;
                Lecture = lecture;
                Points += points;
                LectureAndPoints = new Dictionary<string, int>() { { Lecture, Points } };
            }

            public string Name { get; set; }
            public string Lecture { get; set; }
            public int Points { get; set; }
            public Dictionary<string, int> LectureAndPoints { get; set; }

            public void AddLecture(string contest, int points)
            {
                LectureAndPoints[contest] = points;
            }
        }
    }
}
