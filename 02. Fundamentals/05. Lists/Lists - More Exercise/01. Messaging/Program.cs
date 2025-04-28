namespace _01._Messaging
{
	internal class Program
    {
        static void Main(string[] args)
        {
			List<int> indexes = GetIndexes();
			string text = Console.ReadLine();
			
			for (int i = 0; i < indexes.Count; i++)
			{
				int currentIndex = indexes[i];
				if (currentIndex > text.Length)
				{
					currentIndex -= text.Length;
				}

				Console.Write(text[currentIndex]);
				text = text.Remove(currentIndex, 1);
			}
        }

		private static List<int> GetIndexes()
		{
			List<int> indexes = new List<int>();

			int[] input = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			for (int i = 0; i < input.Length; i++)
			{
				int number = input[i];
				int sum = 0;

				while (number != 0)
				{
					sum += number % 10;
					number /= 10;
				}

				indexes.Add(sum);
			}

			return indexes;
		}
	}
}