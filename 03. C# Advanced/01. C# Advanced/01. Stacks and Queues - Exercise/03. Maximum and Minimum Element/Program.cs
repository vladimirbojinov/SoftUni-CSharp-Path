namespace _03._Maximum_and_Minimum_Element
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int commandCount = int.Parse(Console.ReadLine());

			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < commandCount; i++)
			{
				int[] command = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				switch (command[0]) 
				{
					case 1: ElementToPush(command[1], stack); break;
					case 2: ElementToDelete(stack); break;
					case 3: MaxInStack(stack); break;
					case 4: MinInStack(stack); break;
				}
			}

            Console.WriteLine(string.Join(", ", stack));
        }

		public static void ElementToPush(int n, Stack<int> stack)
		{ 
			stack.Push(n);
		}
		public static void ElementToDelete(Stack<int> stack)
		{
			if (stack.Count == 0) return;

			stack.Pop();
		}
		public static void MaxInStack(Stack<int> stack)
		{ 
			if (stack.Count == 0) return;

			int max = stack.Max();
            Console.WriteLine(max);
        }
		public static void MinInStack(Stack<int> stack)
		{
			if (stack.Count == 0) return;

			int min = stack.Min();
			Console.WriteLine(min);
		}
	}
}
