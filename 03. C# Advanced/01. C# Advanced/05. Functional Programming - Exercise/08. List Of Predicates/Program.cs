using System.ComponentModel.Design;

namespace _08._List_Of_Predicates
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int range = int.Parse(Console.ReadLine());

			HashSet<int> set = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToHashSet();

			HashSet<int> result = new HashSet<int>();

			Predicate<int> isDivisible = (num) =>
			{
				return set.Any(item => num % item == 0);
			};

			Predicate<int> isNotDivisible = (num) =>
			{
				return set.Any(item => num % item != 0);
			};

			for (int i = 1; i <= range; i++)
			{
				if (isDivisible(i))
				{
					result.Add(i);
				}

				if (isNotDivisible(i))
				{
					result.Remove(i);
				}
			}

			Console.WriteLine(string.Join(" ", result));
		}
	}
}
