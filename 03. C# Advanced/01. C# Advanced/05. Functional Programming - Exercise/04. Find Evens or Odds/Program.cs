namespace _04._Find_Evens_or_Odds
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
			string operation = Console.ReadLine();

			int startIndex = array[0];
			int endIndex = array[1];

			Predicate<int> isEven = x => x % 2 == 0;

			for (int i = startIndex; i <= endIndex; i++)
			{
				switch (operation)
				{
					case "even":
						if (isEven(i)) Console.Write($"{i} ");
                    break;
					case "odd":
						if (!isEven(i)) Console.Write($"{i} ");
					break;
				}
			}
		}
	}
}
