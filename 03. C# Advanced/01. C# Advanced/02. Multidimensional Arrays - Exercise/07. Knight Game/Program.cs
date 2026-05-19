


namespace _07._Knight_Game
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int matrixSize = int.Parse(Console.ReadLine());

			char[,] matrix = new char[matrixSize, matrixSize];

			FillMatrix(matrix);

			int knightsRemoved = 0;
			(int, int) maxKnightIndex = (-1, -1);
			while (true)
			{
				int maxConflicts = 0;
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					for (int j = 0; j < matrix.GetLength(1); j++)
					{
						if (matrix[i, j] == 'K')
						{
							int currentConflicts = ConflictsCount(i, j, matrix);

							if (maxConflicts < currentConflicts)
							{
								maxConflicts = currentConflicts;
								maxKnightIndex = (i, j);
							}
						}
					}
				}

				if (maxConflicts == 0) break;

				matrix[maxKnightIndex.Item1, maxKnightIndex.Item2] = '0';
				knightsRemoved++;
			}

			Console.WriteLine(knightsRemoved);
        }

		private static int ConflictsCount(int row, int col, char[,] matrix)
		{
			int conflictCount = 0;

			if (isCoordinatesValid(row - 2, col + 1, matrix)) conflictCount++;
			if (isCoordinatesValid(row - 1, col + 2, matrix)) conflictCount++;
			if (isCoordinatesValid(row + 1, col + 2, matrix)) conflictCount++;
			if (isCoordinatesValid(row + 2, col + 1, matrix)) conflictCount++;
			if (isCoordinatesValid(row + 2, col - 1, matrix)) conflictCount++;
			if (isCoordinatesValid(row + 1, col - 2, matrix)) conflictCount++;
			if (isCoordinatesValid(row - 1, col - 2, matrix)) conflictCount++;
			if (isCoordinatesValid(row - 2, col - 1, matrix)) conflictCount++;

			return conflictCount;
		}

		private static bool isCoordinatesValid(int row, int col, char[,] matrix)
		{
			int maxRow = matrix.GetLength(0);
			int maxCol = matrix.GetLength(1);

			if (row < 0 || row >= maxRow ||
				col < 0 || col >= maxCol)
			{
				return false;
			}

			if (matrix[row, col] == 'K')
			{
				return true;
			}

			return false;
		}

		private static void FillMatrix(char[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				string row = Console.ReadLine();

				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = row[j];
				}
			}
		}
	}
}
