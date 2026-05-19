
namespace _05._Snake_Moves
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
			string word = Console.ReadLine();

			SnakeMoves(word, row, col, matrix);
		}

		private static void SnakeMoves(string word, int row, int col, char[,] matrix)
		{
			int pos = 0;

			for (int i = 0; i < row; i++)
			{
				if (i % 2 == 0)
				{
					for(int j = 0; j < col; j++)
					{
						matrix[i, j] = word[pos];
						pos = (pos + 1) % word.Length;
					}
				}
				else
				{
                    for (int j = col - 1; j >= 0; j--)
                    {
						matrix[i, j] = word[pos];
						pos = (pos + 1) % word.Length;
					}
                }
            }

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
		}
	}
}
