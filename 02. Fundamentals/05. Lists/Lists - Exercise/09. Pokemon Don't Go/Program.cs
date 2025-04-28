namespace _09._Pokemon_Don_t_Go
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			int sum = 0;
			while (numbers.Count > 0)
			{
				int index = int.Parse(Console.ReadLine());
				sum += GetRemovedNumber(numbers, index);
			}

			Console.WriteLine(sum);
		}

		private static int GetRemovedNumber(List<int> numbers, int index)
		{
			int number;
			if (index < 0)
			{
				number = numbers[0];
				numbers[0] = numbers[numbers.Count - 1];

				ShiftValues(numbers, index, number);

				return number;
			}

			if (index >= numbers.Count)
			{
				number = numbers[numbers.Count - 1];
				numbers[numbers.Count - 1] = numbers[0];

				ShiftValues(numbers, index, number);

				return number;
			}

			index = Math.Max(0, Math.Min(numbers.Count - 1, index));
			number = numbers[index];
			numbers.RemoveAt(index);

			ShiftValues(numbers, index, number);

			return number;
		}

		private static void ShiftValues(List<int> numbers, int index, int number)
		{
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] <= number)
				{
					numbers[i] += number;
				}
				else
				{
					numbers[i] -= number;
				}
			}
		}
	}
}
