namespace _11._Array_Manipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			string command;
			while ((command = Console.ReadLine()) != "end")
			{
				string[] input = command.Split();
				string commandType = input[0];

				if (commandType == "exchange")
				{
					int index = int.Parse(input[1]);
					array = Exchange(array, index);
				}
				else if (commandType == "max")
				{
					string searchType = input[1];
					int index = MaxEvenOrOdd(array, searchType);

					if (index == -1)
					{
						Console.WriteLine("No matches");
						continue;
					}

					Console.WriteLine(index);
				}
				else if (commandType == "min")
				{
					string searchType = input[1];
					int index = MinEvenOrOdd(array, searchType);

					if (index == -1)
					{
						Console.WriteLine("No matches");
						continue;
					}

					Console.WriteLine(index);
				}
				else if (commandType == "first")
				{
					int count = int.Parse(input[1]);
					string searchType = input[2];

					Console.WriteLine(FirstEvenOrOdd(array, count, searchType)); 
				}
				else if (commandType == "last")
				{
					int count = int.Parse(input[1]);
					string searchType = input[2];

					Console.WriteLine(LastEvenOrOdd(array, count, searchType));
				}
			}

			Console.WriteLine($"[{string.Join(", ", array)}]");
		}

		private static int[] Exchange(int[] array, int index)
		{
			if (IsIndexValid(array, index) == false)
			{
				Console.WriteLine("Invalid index");
				return array;
			}

			int[] leftHalf = new int[index + 1];
			int[] rightHalf = new int[(array.Length - index) - 1];

			int innerIndex = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (i <= index)
				{
					leftHalf[i] = array[i];
				}
				else
				{
					rightHalf[innerIndex] = array[i];
					innerIndex++;
				}
			}

			return rightHalf.Concat(leftHalf).ToArray();
		}

		private static int MaxEvenOrOdd(int[] array, string type)
		{
			int maxNum = int.MinValue;
			int index = 0;

			for (int i = 0; i < array.Length; i++)
			{
				if (type == "even")
				{
					if (array[i] % 2 == 0 &&
						array[i] >= maxNum)
					{
						maxNum = array[i];
						index = i;
					}
				}
				else if (type == "odd")
				{
					if (array[i] % 2 != 0 &&
						array[i] >= maxNum)
					{
						maxNum = array[i];
						index = i;
					}
				}
			}

			if (maxNum == int.MinValue)
			{
				return -1;
			}

			return index;
		}

		private static int MinEvenOrOdd(int[] array, string type)
		{
			int minNum = int.MaxValue;
			int index = 0;

			for (int i = 0; i < array.Length; i++)
			{
				if (type == "even")
				{
					if (array[i] % 2 == 0 &&
						array[i] <= minNum)
					{
						minNum = array[i];
						index = i;
					}
				}
				else if (type == "odd")
				{
					if (array[i] % 2 != 0 &&
						array[i] <= minNum)
					{
						minNum = array[i];
						index = i;
					}
				}
			}

			if (minNum == int.MaxValue)
			{
				return -1;
			}

			return index;
		}

		private static string FirstEvenOrOdd(int[] array, int count, string type)
		{
			if (count > array.Length)
			{
				return "Invalid count";
			}

			string row = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				if (type == "even")
				{
					if (array[i] % 2 == 0)
					{
						row += $"{array[i]} ";
						count--;
					}
				}
				else if (type == "odd")
				{
					if (array[i] % 2 != 0)
					{
						row += $"{array[i]} ";
						count--;
					}
				}

				if (count == 0)
				{
					break;
				}

			}

			int[] result = row
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			if (result.Length == 0)
			{
				return "[]";
			}

			return $"[{string.Join(", ", result)}]";
		}

		private static string LastEvenOrOdd(int[] array, int count, string type)
		{
			if (count > array.Length)
			{
				return "Invalid count";
			}

			string row = string.Empty;
			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (type == "even")
				{
					if (array[i] % 2 == 0)
					{
						row += $"{array[i]} ";
						count--;
					}
				}
				else if (type == "odd")
				{
					if (array[i] % 2 != 0)
					{
						row += $"{array[i]} ";
						count--;
					}
				}

				if (count == 0)
				{
					break;
				}

			}

			int[] result = row
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			if (result.Length == 0)
			{
				return "[]";
			}

			return $"[{string.Join(", ", result)}]";
		}

		private static bool IsIndexValid(int[] array, int index)
		{
			return index >= 0 && index < array.Length;
		}
	}
}
