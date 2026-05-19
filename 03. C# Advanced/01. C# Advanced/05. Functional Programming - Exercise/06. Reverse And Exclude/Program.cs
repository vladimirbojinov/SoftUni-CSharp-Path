namespace _06._Reverse_And_Exclude
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int numberToDivide = int.Parse(Console.ReadLine());

			Predicate<int> notDivisible = x => x % numberToDivide != 0;
			List<int> listNonDivisible = new List<int>();

			foreach (int number in array)
			{
				if (notDivisible(number))
				{
					listNonDivisible.Add(number);
				}
			}

			listNonDivisible.Reverse();
			Console.WriteLine(string.Join(" ", listNonDivisible));
        }
	}
}
