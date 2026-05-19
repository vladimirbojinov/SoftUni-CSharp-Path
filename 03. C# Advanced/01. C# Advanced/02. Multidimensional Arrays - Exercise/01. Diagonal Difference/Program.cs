


namespace _01._Diagonal_Difference
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int matrixSize = int.Parse(Console.ReadLine());
			int[,] matrix = new int[matrixSize, matrixSize];

			FillMatrix(matrixSize, matrix);
			int mainDiagonal = MainDiagonalSum(matrixSize, matrix);
			int secondaryDiagonal = SecondaryDiagonalSum(matrixSize, matrix);

			int difference = Math.Abs(mainDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }

		private static int SecondaryDiagonalSum(int matrixSize, int[,] matrix)
		{
			int sum = 0;

			for (int i = 0; i < matrixSize; i++)
			{
				sum += matrix[i, matrixSize - 1 - i];
			}

			return sum;
		}

		private static int MainDiagonalSum(int matrixSize, int[,] matrix)
		{
			int sum = 0;

			for (int i = 0; i < matrixSize; i++)
			{
				for (int j = 0; j < matrixSize; j++)
				{
					if (i == j) sum += matrix[i, j];
				}
			}

			return sum;
		}

		private static void FillMatrix(int matrixSize, int[,] matrix)
		{
			for (int i = 0; i < matrixSize; i++)
			{
				int[] array = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				for (int j = 0; j < matrixSize; j++)
				{
					matrix[i, j] = array[j];
				}
			}
		}
	}
}
