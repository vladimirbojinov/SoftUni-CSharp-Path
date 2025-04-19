namespace _10._LadyBugs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int fieldSize = int.Parse(Console.ReadLine());
			int[] ladybugPositions = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] field = new int[fieldSize];
			foreach (int position in ladybugPositions)
			{
				if (position < 0 || position > field.Length - 1)
				{
					continue;
				}

				field[position] = 1;
			}

			string command;
			while ((command = Console.ReadLine()) != "end")
			{
				string[] input = command.Split();

				int position = int.Parse(input[0]);
				string direction = input[1];
				int flyLength = int.Parse(input[2]);

				if ((position < 0 || position > field.Length - 1) ||
					(field[position] == 0))
				{
					continue;
				}

				int move = 0;
				if (direction == "right")
				{
					move = 1;
				}
				else if (direction == "left")
				{
					move = -1;
				}

				if (flyLength < 0)
				{
					move *= -1;
					flyLength = Math.Abs(flyLength);
				}

				field[position] = 0;
				while (flyLength != 0)
				{
					position += move;

					if (position < 0 || position > field.Length - 1)
					{
						break;
					}

					while (field[position] == 1)
					{
						position += move;

						if (position < 0 || position > field.Length - 1)
						{
							break;
						}
					}

					flyLength--;
				}

				if (position < 0 || position > field.Length - 1)
				{
					continue;
				}

				field[position] = 1;
			}

			Console.WriteLine(string.Join(' ', field));
		}
	}
}
