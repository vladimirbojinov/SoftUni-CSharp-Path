namespace SumOfCoins;

using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
	public static void Main(string[] args)
	{
		List<int> coins = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
		int targetSum = int.Parse(Console.ReadLine());

		Dictionary<int, int> usedCoins = ChooseCoins(coins, targetSum);

		Console.WriteLine($"Number of coins to take: {usedCoins.Sum(x => x.Value)}");
		foreach ((int coin, int count) in usedCoins)
		{
			Console.WriteLine($"{count} coin(s) with value {coin}");
		}
	}

	public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
	{
		int currentSum = 0;
		Dictionary<int, int> usedCoins = new();
		int coinIndex = coins.Count - 1;

		while (currentSum < targetSum && coinIndex >= 0)
		{
			int coinValue = coins[coinIndex];

			if (currentSum + coinValue <= targetSum)
			{
				int count = (targetSum - currentSum) / coinValue;
				usedCoins[coinValue] = count;

				currentSum += coinValue * count;
			}
			else coinIndex--;
		}

		if (currentSum != targetSum) throw new InvalidOperationException("Error");
		return usedCoins;
	}
}