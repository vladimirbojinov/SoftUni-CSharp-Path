namespace SetCover;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

class StartUp
{
	static void Main(string[] args)
	{
		int[] universe = Console.ReadLine()
			.Split(", ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		int setCount = int.Parse(Console.ReadLine());
		int[][] jaggedArray = new int[setCount][];
		for (int i = 0; i < setCount; i++)
		{
			int[] set = Console.ReadLine()
			.Split(", ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

			jaggedArray[i] = set;
		}

		List<int[]> chosenSets = ChooseSets(jaggedArray, universe);

		Console.WriteLine($"Sets to take ({chosenSets.Count}):");
		foreach (int[] currentSet in chosenSets)
		{
			Console.WriteLine($"{{ {string.Join(", ", currentSet)} }}");
		}
	}

	public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
	{
		List<int[]> jaggedArray = sets.ToList();
		List<int> universeNumbers = universe.ToList();
		List<int[]> chosenSets = new();

		while (universeNumbers.Count > 0)
		{
			int[] longestSet = jaggedArray.MaxBy(x => x.Count(y => universeNumbers.Contains(y)));

			foreach (int n in longestSet)
			{
				universeNumbers.Remove(n);
			}

			jaggedArray.Remove(longestSet);
			chosenSets.Add(longestSet);
		}

		return chosenSets;
	}
}
