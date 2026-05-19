namespace _02._Basic_Queue_Operations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] commandsArray = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] numbersArray = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			Queue<int> queue = new Queue<int>();

			ElementsToEnqueue(commandsArray[0], numbersArray, queue);
			ElementsToDequeue(commandsArray[1], numbersArray, queue);
			ElementToFind(commandsArray[2], queue);
		}

		public static void ElementsToEnqueue(int countToPush, int[] numbers, Queue<int> queue)
		{
			for (int i = 0; i < countToPush; i++)
			{
				queue.Enqueue(numbers[i]);
			}
		}
		public static void ElementsToDequeue(int countToPop, int[] numbers, Queue<int> queue)
		{
			if (queue.Count > 0)
			{
				for (int i = 0; i < countToPop; i++)
				{
					queue.Dequeue();
				}
			}
		}
		public static void ElementToFind(int numberToFind, Queue<int> queue)
		{
			if (queue.Count <= 0)
			{
				Console.WriteLine(0);
				return;
			}

			bool found = queue.Any(x => x == numberToFind);
			int min = queue.Min();

			if (found)
			{
				Console.WriteLine(found.ToString().ToLower());
			}
			else
			{
				Console.WriteLine(min);
			}
		}
	}
}
