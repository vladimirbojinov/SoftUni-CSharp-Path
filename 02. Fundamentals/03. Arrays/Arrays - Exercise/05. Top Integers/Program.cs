namespace _05._Top_Integers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					bool isTopInteger = false;
					for (int j = i + 1; j <= array.Length - 1; j++)
					{
						if (array[i] < array[j])
						{
							isTopInteger = false;
							break;
						}

						isTopInteger = true;
					}

					if (isTopInteger)
					{
						Console.Write(array[i] + " ");
					}
				}
			}

			Console.WriteLine(array[array.Length - 1]);
		}
	}
}