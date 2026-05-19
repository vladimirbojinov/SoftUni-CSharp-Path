namespace _04._Symbol_in_Matrix
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
			int col = data[0];

			char[,] matrix = new char[row, col];
			matrix = FillArray(row, col, matrix);
			SearchChar(row, col, matrix);
		}
		public static char[,] FillArray(int row, int col, char[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				string text = Console.ReadLine();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = text[j];
				}
			}

			return matrix;
		}
		public static void SearchChar(int row, int col, char[,] matrix)
		{
			char charToFind = char.Parse(Console.ReadLine());

			bool isCharExisting = false;
			int rowOfFound = 0;
			int colOfFound = 0;

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					if (charToFind == matrix[i, j])
					{
						isCharExisting = true;
						rowOfFound = i;
						colOfFound = j;
					}
				}

				if (isCharExisting)
				{
					break;
				}
			}

			if (isCharExisting)
			{
				Console.WriteLine($"({rowOfFound}, {colOfFound})");
			}
			else
			{
				Console.WriteLine($"{charToFind} does not occur in the matrix");
			}
		}
	}
}
