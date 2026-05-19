
using System.ComponentModel;

namespace _06._Jagged_Array_Manipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int arrayRows = int.Parse(Console.ReadLine());
			int[][] jaggedArray = new int[arrayRows][];

			FillJaggedArray(jaggedArray);
			EqualOrNotLength(jaggedArray);

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "End")
			{
				string[] operations = command
					.Split()
					.ToArray();

				int rowIndex = int.Parse(operations[1]);
				int colIndex = int.Parse(operations[2]);
				int value = int.Parse(operations[3]);

				switch (operations[0])
				{
					case "Add": Add(rowIndex, colIndex, value, jaggedArray); break;
					case "Subtract": Subtract(rowIndex, colIndex, value, jaggedArray); break;
				}
			}

			foreach (int[] array in jaggedArray)
			{
                Console.WriteLine(string.Join(" ", array));
            }
		}

		private static bool IsCoordinatesCorrect(int rowIndex, int colIndex, int[][] jaggedArray)
		{
			if (rowIndex < 0 || rowIndex >= jaggedArray.Length)
			{
				return false;
			}

			int rowLength = jaggedArray[rowIndex].Length;

			if (colIndex < 0 || colIndex >= rowLength)
			{
				return false;
			}

			return true;
		}

		private static void Subtract(int rowIndex, int colIndex, int value, int[][] jaggedArray)
		{
			if (IsCoordinatesCorrect(rowIndex ,colIndex, jaggedArray))
			{
				jaggedArray[rowIndex][colIndex] -= value;
			}
		}

		private static void Add(int rowIndex, int colIndex, int value, int[][] jaggedArray)
		{
			if (IsCoordinatesCorrect(rowIndex, colIndex, jaggedArray))
			{
				jaggedArray[rowIndex][colIndex] += value;
			}
		}

		private static void EqualOrNotLength(int[][] jaggedArray)
		{
			for (int i = 0; i < jaggedArray.Length - 1; i++)
			{
				if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
				{
					for (int j = 0; j < jaggedArray[i].Length; j++)
					{
						jaggedArray[i][j] *= 2;
						jaggedArray[i + 1][j] *= 2;
					}
                }
				else
				{
					for (int j = 0; j < jaggedArray[i].Length; j++)
					{
						jaggedArray[i][j] /= 2;
					}

					for (int k = 0; k < jaggedArray[i + 1].Length; k++)
					{
						jaggedArray[i + 1][k] /= 2;
					}
				}
			}
		}

		private static void FillJaggedArray(int[][] jaggedArray)
		{
			for (int i = 0; i < jaggedArray.Length; i++)
			{
				int[] data = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				jaggedArray[i] = data;
			}
		}
	}
}
