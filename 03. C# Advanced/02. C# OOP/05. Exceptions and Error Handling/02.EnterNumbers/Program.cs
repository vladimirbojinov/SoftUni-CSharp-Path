namespace _02.EnterNumbers;

internal class Program
{
	static void Main(string[] args)
	{
		ReadNumbers(1, 100);
	}

	private static void ReadNumbers(int start, int end)
	{
		List<int> numbers = new List<int>();

		while (numbers.Count < 10)
		{
			try
			{
				int number;

				string value = Console.ReadLine();
				if (!int.TryParse(value, out number)) throw new ArgumentException("Invalid Number!");

				number = int.Parse(value);
				if (number <= start || number >= end) throw new ArgumentException($"Your number is not in range {number} - 100!");

				numbers.Add(number);

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		Console.WriteLine(string.Join(", ", numbers));
	}
}
