namespace _05.PlayCatch;

internal class Program
{
	static void Main(string[] args)
	{
		int[] numbers = Console.ReadLine()
			.Split(" ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		ProcessNumbers(numbers);

		Console.WriteLine(string.Join(", ", numbers));
	}

	private static void ProcessNumbers(int[] numbers)
	{
		int exceptionCount = 0;

		while (exceptionCount != 3)
		{
			string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

			try
			{
				switch (command[0])
				{
					case "Replace": Replace(numbers, int.Parse(command[1]), command[2]); break;
					case "Print": Print(numbers, int.Parse(command[1]), int.Parse(command[2])); break;
					case "Show": Show(numbers, int.Parse(command[1])); break;
				}
			}
			catch (FormatException)
			{
				Console.WriteLine("The variable is not in the correct format!");
				exceptionCount++;
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("The index does not exist!");
				exceptionCount++;
			}
		}
	}

	private static void Show(int[] numbers, int index) => Console.WriteLine(numbers[index]);

	private static void Print(int[] numbers, int startIndex, int endIndex)
	{
		int[] array = new int[(endIndex - startIndex) + 1];
		int counter = 0;

		for (int i = startIndex; i <= endIndex; i++)
		{
			array[counter] = numbers[i];
			counter++;
		}

		Console.WriteLine(string.Join(", ", array));
	}

	private static void Replace(int[] numbers, int index, string element)
	{
		int number = 0;
		if (!int.TryParse(element, out number)) throw new FormatException();

		numbers[index] = number;
	}
}
