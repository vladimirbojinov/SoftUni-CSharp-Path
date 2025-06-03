namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyDictionary = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" -> ");
                string companyName = input[0];
                string employeeId = input[1];

                if (!companyDictionary.ContainsKey(companyName))
                {
                    companyDictionary[companyName] = new List<string>();
                }

                if (!companyDictionary[companyName].Contains(employeeId))
                {
					companyDictionary[companyName].Add(employeeId);
				}
            }

            foreach (var company in companyDictionary)
            {
				Console.WriteLine(company.Key);
                foreach (string employees in company.Value)
                {
					Console.WriteLine($"-- {employees}");
                }
            }
        }
    }
}