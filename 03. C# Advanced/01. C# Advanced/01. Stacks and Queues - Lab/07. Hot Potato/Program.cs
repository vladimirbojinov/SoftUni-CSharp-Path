namespace _07._Hot_Potato
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<string> queue = new Queue<string>(Console.ReadLine()
				.Split());
			int passes = int.Parse(Console.ReadLine());

			while (queue.Count != 1) 
			{
				for (int i = 0; i < passes; i++)
				{
					string name = queue.Dequeue();
					if (i == passes - 1)
					{
                        Console.WriteLine($"Removed {name}");
                    }
					else
					{
						queue.Enqueue(name);
					}

				}
			}

			string winner = queue.Dequeue();
            Console.WriteLine($"Last is {winner}");
        }
	}
}
