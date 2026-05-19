namespace _01._Basic_Stack_Operations
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

			Stack<int> stack = new Stack<int>();

			ElementsToPush(commandsArray[0], numbersArray, stack);
			ElementsToPop(commandsArray[1], numbersArray, stack);
			ElementToFind(commandsArray[2], stack);
		}

		public static void ElementsToPush(int countToPush, int[] numbers, Stack<int> stack)
		{
			for (int i = 0; i < countToPush; i++)
			{
				stack.Push(numbers[i]);
			}
		}
		public static void ElementsToPop(int countToPop, int[] numbers, Stack<int> stack)
		{
			if (stack.Count > 0)
			{
				for (int i = 0; i < countToPop; i++)
				{
					stack.Pop();
				}
			}
		}
		public static void ElementToFind(int numberToFind, Stack<int> stack)
		{
			if (stack.Count <= 0)
			{
				Console.WriteLine(0);
				return;
			}

			bool found = stack.Any(x => x == numberToFind);
			int min = stack.Min();

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
