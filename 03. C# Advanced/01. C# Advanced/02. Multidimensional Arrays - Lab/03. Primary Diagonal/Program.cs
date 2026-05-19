namespace _03._Primary_Diagonal
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

			int[,] matrix = new int[row, col];

			matrix = FillArray(row, col, matrix);
			SumPrimaryDiagonal(row, col, matrix);
		}
		public static int[,] FillArray(int row, int col, int[,] matrix)
		{
			for (int i = 0; i < row; i++)
			{
				int[] array = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				for (int j = 0; j < col; j++)
				{
					matrix[i, j] = array[j];
				}
			}

			return matrix;
		}
		public static void SumPrimaryDiagonal(int row, int col, int[,] matrix)
		{
			int rowOfMain = 0;
			int colOfMain = 0;

			int sumOfPrimary = 0;
			for (int i = 0; rowOfMain < row; i++)
			{
				sumOfPrimary += matrix[rowOfMain, colOfMain];
				rowOfMain++;
				colOfMain++;
			}

			Console.WriteLine(sumOfPrimary);
		}
	}
}
