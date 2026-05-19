namespace _04._Fast_Food
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int foodCount = int.Parse(Console.ReadLine());
			Queue<int> queue = new Queue<int>(Console.ReadLine()
				.Split()
				.Select(int.Parse));

			int bigOrder = queue.Max();
            Console.WriteLine(bigOrder);

            while (foodCount > 0 && queue.Count != 0)
			{
				int currentOrder = queue.Peek();

				if (foodCount - currentOrder < 0) break;

				foodCount -= currentOrder;
				queue.Dequeue();
			}

			if (queue.Count == 0)
			{
                Console.WriteLine("Orders complete");
            }
			else
			{
                Console.Write("Orders left: " + string.Join(" ", queue));
            }
		}
	}
}
