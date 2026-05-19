
namespace _04._Matrix_Shuffling
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

			string[,] matrix = new string[row, col];

			FillMatrix(row, col, matrix);

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] operation = command
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				int rowIndex1 = int.Parse(operation[1]);
				int colIndex1 = int.Parse(operation[2]);
				int rowIndex2 = int.Parse(operation[3]);
				int colIndex2 = int.Parse(operation[4]);

				if (IsCoordinatesCorrect(rowIndex1, colIndex1, rowIndex2, colIndex2, row, col))
				{
					switch (operation[0])
					{
						case "swap": 
							SwapElements(rowIndex1, colIndex1, rowIndex2, colIndex2, row, col, matrix); 
						break;
						default: 
							Console.WriteLine("Invalid input!"); 
						break;
					}
				}
			}
		}

		private static bool IsCoordinatesCorrect(int rowIndex1, int colIndex1, int rowIndex2, int colIndex2, int row, int col)
		{
			if ((rowIndex1 < 0 || rowIndex1 > row) &&
				(colIndex1 < 0 || colIndex1 > col))
			{
                Console.WriteLine("Invalid input!");
                return false;
			}

			if ((rowIndex2 < 0 && rowIndex2 > row) &&
				(colIndex2 < 0 && colIndex2 > col))
			{
				Console.WriteLine("Invalid input!");
				return false;
			}

			return true;
		}

		private static void SwapElements(int rowIndex1, int colIndex1, int rowIndex2, int colIndex2, int row, int col, string[,] matrix)
		{
			string temp = matrix[rowIndex1, colIndex1];
			matrix[rowIndex1, colIndex1] = matrix[rowIndex2, colIndex2];
			matrix[rowIndex2, colIndex2] = temp;

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

		private static void FillMatrix(int row, int col, string[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				string[] array = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = array[j];
				}
			}
		}
	}
}
