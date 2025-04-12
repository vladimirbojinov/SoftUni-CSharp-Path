namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesDictionary = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split(" : ");
                string courseName = arguments[0];
                string studentName = arguments[1];

                if (!coursesDictionary.ContainsKey(courseName))
                {
                    coursesDictionary.Add(courseName, new List<string>());
                    coursesDictionary[courseName].Add(studentName);
                }
                else
                {
                    coursesDictionary[courseName].Add(studentName);
                }
            }

            foreach (var kvp in coursesDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (string values in kvp.Value)
                {
                    Console.WriteLine($"-- {values}");
                }
            }
        }
    }
}