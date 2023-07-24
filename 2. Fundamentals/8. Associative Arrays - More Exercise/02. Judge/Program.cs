namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Students>> studentsDictionary = new Dictionary<string, List<Students>>();

            string command;
            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] arguments = command.Split("->");
                string username = arguments[0];
                string contest = arguments[1];
                int points = int.Parse(arguments[2]);

                if (!studentsDictionary.ContainsKey(contest))
                {
                    Students students = new Students(username, points);
                    studentsDictionary.Add(contest, value: new List<Students> { students });
                    students.AttendedAt(contest);
                }
                else
                {
                    bool isPointsBigger = false;
                    bool isPointsSmaller = false;
                    foreach (var kvp in studentsDictionary)
                    {
                        foreach (Students values in kvp.Value)
                        {
                            if (values.Points < points && values.Name == username && values.AttendedContests.Contains(contest))
                            {
                                isPointsBigger = true;
                                values.Update(points);
                            }
                            else if (values.Points > points && values.Name == username && values.AttendedContests.Contains(contest))
                            {
                                isPointsSmaller = true;
                            }
                        }
                    }

                    if (!isPointsBigger && !isPointsSmaller)
                    {
                        Students students = new Students(username, points);
                        studentsDictionary[contest].Add(students);
                        students.AttendedAt(contest);
                    }
                }
            }

            foreach (var kvp in studentsDictionary)
            {
                Console.WriteLine($"{kvp.Key.Trim()}: {kvp.Value.Count} participants");

                int count = 0;
                foreach (Students values in kvp.Value.OrderByDescending(x => x.Points))
                {
                    count++;
                    Console.WriteLine($"{count}. {values.Name}<::> {values.Points}");
                }
            }

            Console.WriteLine("Individual standings:");

            List<Students> sortedStudentList = new List<Students>();
            foreach (var kvp in studentsDictionary)
            {
                sortedStudentList.AddRange(kvp.Value.OrderByDescending(x => x.Points).ToList());
            }

            sortedStudentList = sortedStudentList
                .GroupBy(x => x.Name)
                .Select(x => new Students(x.Key, x.Sum(x => x.Points)))
                .ToList();
            sortedStudentList = sortedStudentList.OrderByDescending(x => x.Points).ToList();

            for (int i = 0; i < sortedStudentList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedStudentList[i]}");
            }
        }
    }
    class Students
    {
        public Students(string name, int points)
        {
            Name = name;
            Points = points;
            AttendedContests = new List<string>();
        }

        public string Name { get; set; }
        public int Points { get; set; }

        public List<string> AttendedContests { get; set; }

        public void Update(int points)
        {
            Points = points;
        }

        public void AttendedAt(string contest)
        {
            AttendedContests.Add(contest);
        }
        public override string ToString()
        {
            return $"{Name}-> {Points}";
        }
    }
}