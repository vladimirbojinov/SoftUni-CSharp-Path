using System;

namespace _01.RecursiveArraySum;

internal class Program
{
	static void Main(string[] args)
	{
		int[] numbers = Console.ReadLine()
			.Split(" ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		Console.WriteLine(RecursiveSum(numbers));
	}

	private static int RecursiveSum(int[] array, int n = 0)
	{
		if (n == array.Length - 1) return array[n];

		return array[n] + RecursiveSum(array, n + 1);
	}
}
