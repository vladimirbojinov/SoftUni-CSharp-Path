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
                string resources = command;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourcesDictionary.ContainsKey(resources))
                {
                    resourcesDictionary.Add(resources, quantity);
                }
                else
                {
                    resourcesDictionary[resources] += quantity;
                }
            }

            foreach (var kvp in resourcesDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}