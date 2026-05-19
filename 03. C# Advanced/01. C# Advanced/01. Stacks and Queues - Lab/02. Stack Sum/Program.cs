using System.ComponentModel;

namespace _02._Stack_Sum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> stack = new Stack<int>(Console.ReadLine()
				.Split()
				.Select(int.Parse));

			string command = string.Empty;
			while ((command = Console.ReadLine().ToLower()) != "end")
			{
				string[] split = command.Split();

				switch (split[0])
				{
					case "add": 
						int n1 = int.Parse(split[1]);
						int n2 = int.Parse(split[2]);
						Add(stack, n1, n2);
						break;
					case "remove": 
						int count = int.Parse(split[1]);
						Remove(stack, count);
						break;
				}
			}

			int sum = 0;
			foreach (int i in stack)
			{
				sum += i;
			}

            Console.WriteLine($"Sum: {sum}");
        }

		public static void Add(Stack<int> stack, int n1, int n2)
		{
			stack.Push(n1);
			stack.Push(n2);
		}
		public static void Remove(Stack<int> stack, int count)
		{
			if (stack.Count >= count)
			{
				for (int i = 0; i < count; i++)
				{
					stack.Pop();
				}
			}
		}
	}
}
