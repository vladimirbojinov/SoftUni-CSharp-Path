namespace _03._Simple_Calculator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> stackNumber = new Stack<int>();
			Stack<string> stackOperators = new Stack<string>();

			StackSplit(stackNumber, stackOperators);
			StackOperations(stackNumber, stackOperators);

			int n = stackNumber.Pop();
            Console.WriteLine(n);
        }

		public static void StackSplit(Stack<int> stackNumber, Stack<string> stackOperators)
		{
			string[] array = Console.ReadLine()
				.Split()
				.ToArray();

			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (i % 2 == 0)
				{
					int n = int.Parse(array[i]);
					stackNumber.Push(n);
				}
				else
				{
					stackOperators.Push(array[i]);
				}
			}
		}

		public static void StackOperations(Stack<int> stackNumber, Stack<string> stackOperators)
		{
			for (int i = stackOperators.Count;i > 0;i--) 
			{
				string operators = stackOperators.Pop();

				switch (operators)
				{
					case "+": 
						int n1 = stackNumber.Pop();
						int n2 = stackNumber.Pop();
						int calc = n1 + n2;
						stackNumber.Push(calc);
						break;
					case "-":
						n1 = stackNumber.Pop();
						n2 = stackNumber.Pop();
						calc = n1 - n2;
						stackNumber.Push(calc);
						break;
				}
			}
		}
	}
}
