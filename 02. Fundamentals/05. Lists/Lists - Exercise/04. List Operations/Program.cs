namespace _04._List_Operations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			string command;
			while ((command = Console.ReadLine()) != "End")
			{
				string[] arguments = command.Split();

				switch (arguments[0])
				{
					case "Add": numbers = AddCommand(numbers, int.Parse(arguments[1])); break;
					case "Insert": numbers = InsertCommand(numbers, int.Parse(arguments[1]), int.Parse(arguments[2])); break;
					case "Remove": numbers = RemoveCommand(numbers, int.Parse(arguments[1])); break;
					case "Shift": numbers = ShiftCommand(numbers, arguments); break;
				}
			}

			Console.WriteLine(string.Join(" ", numbers));
		}

		private static List<int> ShiftCommand(List<int> numbers, string[] arguments)
		{
			switch (arguments[1])
			{
				case "left": numbers = ShiftLeftCommand(numbers, int.Parse(arguments[2])); break;
				case "right": numbers = ShiftRightCommand(numbers, int.Parse(arguments[2])); break;
			}

			return numbers;
		}

		static List<int> AddCommand(List<int> numbers, int number)
		{
			numbers.Add(number);

			return numbers;
		}
		static List<int> InsertCommand(List<int> numbers, int number, int index)
		{
			if (IsIndexCorrect(numbers, index))
			{
				numbers.Insert(index, number);
			}

			return numbers;
		}
		static List<int> RemoveCommand(List<int> numbers, int index)
		{
			if (IsIndexCorrect(numbers, index))
			{
				numbers.RemoveAt(index);
			}

			return numbers;
		}
		static List<int> ShiftLeftCommand(List<int> numbers, int count)
		{
			for (int i = 0; i < count; i++)
			{
				int first = numbers[0];
				numbers.Add(first);
				numbers.RemoveAt(0);
			}

			return numbers;
		}
		static List<int> ShiftRightCommand(List<int> numbers, int count)
		{
			for (int i = 0; i < count; i++)
			{
				int last = numbers[numbers.Count - 1];
				numbers.Insert(0, last);
				numbers.RemoveAt(numbers.Count - 1);
			}

			return numbers;
		}
		static bool IsIndexCorrect(List<int> numbers, int index)
		{
			if (index >= 0 && index < numbers.Count)
			{
				return true;
			}

			Console.WriteLine("Invalid index");
			return false;
		}
	}
}