namespace _02._Sum_Matrix_Columns
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
			SumColumns(row, col, matrix);
		}
		public static int[,] FillArray(int row, int col, int[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				int[] array = Console.ReadLine()
					.Split(" ")
					.Select(int.Parse)
					.ToArray();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = array[j];
				}
			}

			return matrix;
		}
		public static void SumColumns(int row, int col, int[,] matrix)
		{
			for (int i = 0; i < col; i++)
			{
				int sum = 0;
				for (int j = 0; j < row; j++)
				{
					sum += matrix[j, i];
				}

				Console.WriteLine(sum);
			}
		}
	}
}
