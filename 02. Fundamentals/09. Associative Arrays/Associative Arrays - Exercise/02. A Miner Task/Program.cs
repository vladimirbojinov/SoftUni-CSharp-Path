namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourcesDictionary = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                string resource = command;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourcesDictionary.ContainsKey(resource))
                {
                    resourcesDictionary.Add(resource, 0);
                }

                resourcesDictionary[resource] += quantity;
            }

            foreach (var recourse in resourcesDictionary)
            {
                Console.WriteLine($"{recourse.Key} -> {recourse.Value}");
            }
        }
    }
}