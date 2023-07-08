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
                string[] arguments = command.Split(" -> ");
                string company = arguments[0];
                string empleeID = arguments[1];

                if (!companyDictionary.ContainsKey(company))
                {
                    companyDictionary.Add(company, new List<string>());
                    companyDictionary[company].Add(empleeID);
                }
                else
                {
                    List<string> isEmployeeExisting = companyDictionary.Values.FirstOrDefault(x => x.ToString() == empleeID);
                    if (isEmployeeExisting == null)
                    {
                        companyDictionary[company].Add(empleeID);
                    }
                }
            }

            foreach (var kvp in companyDictionary)
            {
                Console.WriteLine(kvp.Key);
                foreach (var value in kvp.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}