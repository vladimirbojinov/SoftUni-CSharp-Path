namespace _02._Change_List
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
			while ((command = Console.ReadLine()) != "end")
			{
				string[] arguments = command.Split();

				switch (arguments[0])
				{
					case "Delete": numbers = DeleteCommand(numbers, int.Parse(arguments[1])); break;
					case "Insert": numbers = InsertCommand(numbers, int.Parse(arguments[1]), int.Parse(arguments[2])); break;
				}
			}

			Console.WriteLine(string.Join(" ", numbers));
		}

		static List<int> DeleteCommand(List<int> numbers, int numberToRemove)
		{
			while (numbers.Contains(numberToRemove))
			{
				numbers.Remove(numberToRemove);
			}

			return numbers;
		}

		static List<int> InsertCommand(List<int> numbers, int number, int index)
		{
			numbers.Insert(index, number);

			return numbers;
		}
	}
}