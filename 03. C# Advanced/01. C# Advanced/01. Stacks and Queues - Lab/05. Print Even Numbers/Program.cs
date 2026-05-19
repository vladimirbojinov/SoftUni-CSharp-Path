namespace _05._Print_Even_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<int> queue = new Queue<int>(Console.ReadLine()
				.Split()
				.Select(int.Parse));

			int originalCount = queue.Count; 

			for (int i = 0; i < originalCount; i++)
			{
				int n = queue.Dequeue();
				if (n % 2 == 0)
				{
					queue.Enqueue(n);
				}
			}

            Console.WriteLine(string.Join(", ", queue));
        }
	}
}
