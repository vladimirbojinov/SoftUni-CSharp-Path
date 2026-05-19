namespace _01._Sum_Matrix_Elements
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
			SumArray(row, col, matrix);
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
		public static void SumArray(int row, int col, int[,] matrix)
		{
			int sum = 0;
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					sum += matrix[i, j];
				}
			}

			Console.WriteLine(row);
			Console.WriteLine(col);
			Console.WriteLine(sum);
		}
	}
}
