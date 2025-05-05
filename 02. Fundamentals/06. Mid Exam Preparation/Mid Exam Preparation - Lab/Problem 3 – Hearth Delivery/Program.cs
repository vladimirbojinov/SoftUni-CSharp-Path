namespace Problem_3___Hearth_Delivery
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] neighborhood = Console.ReadLine()
				.Split('@')
				.Select(int.Parse)
				.ToArray();

			int cupidPos = 0;

			string command;
			while ((command = Console.ReadLine()) != "Love!")
			{
				string[] input = command.Split();

				cupidPos = int.Parse(input[1]) + cupidPos;
				if (cupidPos >= neighborhood.Length)
				{
					cupidPos = 0;
				}

				VisitHouse(neighborhood, cupidPos);
			}

			int count = GetSuccessfulHousesCount(neighborhood);

			Console.WriteLine($"Cupid's last position was {cupidPos}.");
			if (count == neighborhood.Length)
			{
				Console.WriteLine("Mission was successful.");
			}
			else
			{
				Console.WriteLine($"Cupid has failed {neighborhood.Length - count} places.");
			}
		}

		private static int GetSuccessfulHousesCount(int[] neighborhood)
		{
			int count = 0;

			foreach (int house in neighborhood)
			{
				if (house == 0)
				{
					count++;
				}
			}

			return count;
		}

		private static void VisitHouse(int[] neighborhood, int cupidPos)
		{
			if (neighborhood[cupidPos] == 0)
			{
				Console.WriteLine($"Place {cupidPos} already had Valentine's day.");
				return;
			}
			else
			{
				neighborhood[cupidPos] -= 2;
			}

			if (neighborhood[cupidPos] == 0)
			{
				Console.WriteLine($"Place {cupidPos} has Valentine's day.");
			}
		}
	}
}