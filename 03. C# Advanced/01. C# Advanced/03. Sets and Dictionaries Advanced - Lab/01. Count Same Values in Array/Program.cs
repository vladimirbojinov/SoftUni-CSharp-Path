namespace _01._Count_Same_Values_in_Array
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<double, int> dictionary = new Dictionary<double, int>();
			double[] array = Console.ReadLine()
				.Split()
				.Select(double.Parse)
				.ToArray();

			for (int i = 0; i < array.Length; i++)
			{
				if (!dictionary.ContainsKey(array[i]))
				{
					dictionary[array[i]] = 0;
				}

				dictionary[array[i]]++;
			}

			foreach ((double number, int count) in dictionary)
			{
                Console.WriteLine($"{number} - {count} times");
            }
        }
	}
}
