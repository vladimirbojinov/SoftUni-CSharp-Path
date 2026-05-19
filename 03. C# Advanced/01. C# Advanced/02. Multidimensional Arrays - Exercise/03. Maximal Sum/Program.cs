


namespace _03._Maximal_Sum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] matrixSize = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int row = matrixSize[0];
			int col = matrixSize[1];

			int[,] matrix = new int[row, col];
			FillMatrix(row, col, matrix);
			FindMaxSum(row, col, matrix);
		}

		private static int[,] MaxMatrix(int[,] matrix, int row, int col)
		{
			int[,] maxMatrix = new int[3, 3];

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					maxMatrix[i, j] = matrix[i + row, j + col];
				}
			}

			return maxMatrix;
		}

		private static int SumMatrix(int[,] matrix, int row, int col)
		{
			int sum = 0;

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					sum += matrix[i + row, j + col];
				}
			}

			return sum;
		}

		private static void FindMaxSum(int row, int col, int[,] matrix)
		{
			int max = int.MinValue;
			int[,] maxMatrix = new int[3, 3];

			for (int i = 0; i < row - 2; i++)
			{
				for (int j = 0; j < col - 2; j++)
				{
					int currentSum = SumMatrix(matrix, i, j);

					if (currentSum > max)
					{
						max = currentSum;
						maxMatrix = MaxMatrix(matrix, i, j);
					}
				}
			}

            Console.WriteLine($"Sum = {max}");
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write($"{maxMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

		private static void FillMatrix(int row, int col, int[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				int[] array = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = array[j];
				}
			}
		}
	}
}
