namespace _05._Square_With_Maximum_Sum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] data = Console.ReadLine()
				.Split(", ")
				.Select(int.Parse)
				.ToArray();
			int row = data[0];
			int col = data[1];

			int[,] matrix = new int[row, col];

			matrix = FillArray(row, col, matrix);
			BiggestSquare(row, col, matrix);
		}
		public static int[,] FillArray(int row, int col, int[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				int[] array = Console.ReadLine()
					.Split(", ")
					.Select(int.Parse)
					.ToArray();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = array[j];
				}
			}

			return matrix;
		}
		public static void BiggestSquare(int row, int col, int[,] matrix)
		{
			int bestFirstPart = 0;
			int bestSecondPart = 0;
			int bestThirdPart = 0;
			int bestFourthPart = 0;

			int max = int.MinValue;

			for (int i = 0; i < row - 1; i++)
			{
				for (int j = 0; j < col - 1; j++)
				{
					int sum = matrix[i, j] +
						matrix[i, j + 1] +
						matrix[i + 1, j] +
						matrix[i + 1, j + 1];

					if (sum > max)
					{
						max = sum;

						bestFirstPart = matrix[i, j];
						bestSecondPart = matrix[i, j + 1];
						bestThirdPart = matrix[i + 1, j];
						bestFourthPart = matrix[i + 1, j + 1];
					}
                }
			}

            Console.WriteLine($"{bestFirstPart} {bestSecondPart}");
            Console.WriteLine($"{bestThirdPart} {bestFourthPart}");
            Console.WriteLine(max);
        }
	}
}
