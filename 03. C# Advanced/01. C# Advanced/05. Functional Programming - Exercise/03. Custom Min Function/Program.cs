using System;

namespace _03._Custom_Min_Function
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			Func<int[], int> min = x => x.Min();
            Console.WriteLine(min(array));
        }
	}
}
