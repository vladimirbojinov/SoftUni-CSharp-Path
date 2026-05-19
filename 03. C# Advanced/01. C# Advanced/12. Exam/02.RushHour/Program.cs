namespace _02.RushHour;

internal class Program
{
	static void Main(string[] args)
	{
		Dictionary<string, (int, int)> directions = new()
		{
			["right"] = (0, 1),
			["left"] = (0, -1),
			["up"] = (-1, 0),
			["down"] = (1, 0)
		};

		int[] matrixSize = Console.ReadLine()
			.Split(", ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		char[,] map = new char[matrixSize[0], matrixSize[1]];
		(int row, int col) vehiclePos = FillMap(map);

		int trafficJamEncounter = 0;
		bool isDelivered = false;

		while (trafficJamEncounter < 3 && !isDelivered)
		{
			string direction = Console.ReadLine()!;

			(int row, int col) newPos = vehiclePos;
			newPos.row += directions[direction].Item1;
			newPos.col += directions[direction].Item2;

			if (IsMoveValid(newPos, map) && map[newPos.row, newPos.col] != 'X')
			{
				vehiclePos = newPos;
			}
			else if (IsMoveValid(newPos, map) && map[newPos.row, newPos.col] == 'X')
			{
				map[newPos.row, newPos.col] = '*';
				trafficJamEncounter++;
			}

			if (IsMoveValid(vehiclePos, map) && map[vehiclePos.row, vehiclePos.col] == 'D') isDelivered = true;
		}

		if (isDelivered)
		{
			Console.WriteLine("Delivery completed!");
		}
		else
		{
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					if (map[i, j] == 'D') map[i, j] = '*';
					if (map[i, j] == 'V') map[i, j] = '*';
				}
			}

			map[vehiclePos.row, vehiclePos.col] = 'V';
			Console.WriteLine("Delivery failed, too many traffic jams!");
		}

		PrintMap(map);
	}

	private static bool IsMoveValid((int row, int col) newPos, char[,] map)
		=> newPos.row >= 0 && newPos.row < map.GetLength(0)
		&& newPos.col >= 0 && newPos.col < map.GetLength(1);

	private static void PrintMap(char[,] map)
	{
		for (int i = 0; i < map.GetLength(0); i++)
		{
			for (int j = 0; j < map.GetLength(1); j++)
			{
				Console.Write(map[i, j]);
			}

			Console.WriteLine();
		}
	}

	private static (int row, int col) FillMap(char[,] map)
	{
		(int row, int col) vehiclePos = (0, 0);

		for (int i = 0; i < map.GetLength(0); i++)
		{
			char[] mapRow = Console.ReadLine().ToCharArray();
			for (int j = 0; j < map.GetLength(1); j++)
			{
				map[i, j] = mapRow[j];
				if (map[i, j] == 'V') vehiclePos = (i, j);
			}
		}

		return vehiclePos;
	}
}
