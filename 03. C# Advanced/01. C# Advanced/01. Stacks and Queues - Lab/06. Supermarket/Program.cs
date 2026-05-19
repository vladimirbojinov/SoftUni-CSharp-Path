namespace _06._Supermarket
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<string> queue = new Queue<string>();

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "End")
			{
				if (command == "Paid")
				{
					int originalCount = queue.Count;
					for (int i = 0; i < originalCount; i++)
					{
						string name = queue.Dequeue();
                        Console.WriteLine(name);
                    }
                }
				else
				{
					queue.Enqueue(command);
				}
			}

			Console.WriteLine($"{queue.Count} people remaining.");
        }
	}
}
