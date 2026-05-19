namespace _02.BombHasBeenPlanted;

internal class Program
{
	static void Main(string[] args)
	{
		int[] matrixSize = Console.ReadLine()
			.Split(", ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		int row = matrixSize[0];
		int col = matrixSize[1];
		(int row, int col) ctPos = (0, 0);
		int timer = 16;
		bool attemptedDefuse = false;

		char[,] map = new char[row, col];

		ctPos = FillMap(ctPos, map);


		while (timer >= 0)
		{
			string command = Console.ReadLine();

			switch (command)
			{
				case "left":
				case "right":
				case "up":
				case "down": ctPos = Move(map, ctPos, command); break;
				case "defuse":
					if (map[ctPos.row, ctPos.col] == 'B')
					{
						if (timer - 4 >= 0) map[ctPos.row, ctPos.col] = 'D';
						else map[ctPos.row, ctPos.col] = 'X';

						attemptedDefuse = true;
					}
					else timer--;
					break;
			}

			if (attemptedDefuse)
			{
				if (timer - 4 >= 0)
				{
					timer -= 4;
					Console.WriteLine("Counter-terrorist wins!");
					Console.WriteLine($"Bomb has been defused: {timer} second/s remaining.");
				}
				else
				{
					Console.WriteLine("Terrorists win!");
					Console.WriteLine("Bomb was not defused successfully!");
					Console.WriteLine($"Time needed: {4 - timer} second/s.");
				}

				PrintMap(map);
				return;
			}

			if (map[ctPos.row, ctPos.col] == 'T')
			{
				map[ctPos.row, ctPos.col] = '*';
				Console.WriteLine("Terrorists win!");
				PrintMap(map);
				return;
			}

			timer--;
		}

		if (!attemptedDefuse)
		{
			Console.WriteLine("Terrorists win!");
			Console.WriteLine("Bomb was not defused successfully!");
			Console.WriteLine("Time needed: 0 second/s.");
		}
		PrintMap(map);
	}

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

	private static (int, int) Move(char[,] map, (int row, int col) oldPos, string direction)
	{
		Dictionary<string, (int, int)> directions = new()
		{
			["right"] = (0, 1),
			["left"] = (0, -1),
			["up"] = (-1, 0),
			["down"] = (1, 0)
		};

		(int row, int col) newPos = oldPos;
		newPos.row += directions[direction].Item1;
		newPos.col += directions[direction].Item2;

		if (isMoveValid(newPos, map)) return newPos;
		else return oldPos;
	}

	private static bool isMoveValid((int row, int col) newPos, char[,] map)
		=> newPos.row >= 0 && newPos.row < map.GetLength(0) &&
				newPos.col >= 0 && newPos.col < map.GetLength(1);

	private static (int row, int col) FillMap((int row, int col) counterTerroristPos, char[,] map)
	{
		for (int i = 0; i < map.GetLength(0); i++)
		{
			char[] mapRow = Console.ReadLine().ToCharArray();
			for (int j = 0; j < map.GetLength(1); j++)
			{
				map[i, j] = mapRow[j];
				if (map[i, j] == 'C') counterTerroristPos = (i, j);
			}
		}

		return counterTerroristPos;
	}
}
