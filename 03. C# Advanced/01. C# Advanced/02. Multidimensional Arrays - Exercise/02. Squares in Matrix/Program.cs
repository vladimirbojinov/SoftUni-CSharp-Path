namespace _02._Squares_in_Matrix
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

			char[,] matrix = new char[row, col];
			FillMatrix(row, col, matrix);
			EqualSquares(col, row, matrix);
		}

		private static void EqualSquares(int col, int row, char[,] matrix)
		{
			int count = 0;

			for (int i = 0; i < row - 1; i++)
			{
				for (int j = 0; j < col - 1; j++)
				{
					if (matrix[i, j] == matrix[i, j + 1] &&
						matrix[i + 1, j] == matrix[i + 1, j + 1] &&
						matrix[i, j] == matrix[i + 1, j] &&
						matrix[i, j + 1] == matrix[i + 1, j + 1])
					{
						count++;
					}
				}
			}

            Console.WriteLine(count);
        }

		private static void FillMatrix(int row, int col, char[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				char[] array = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(char.Parse)
					.ToArray();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = array[j];
				}
			}
		}
	}
}
