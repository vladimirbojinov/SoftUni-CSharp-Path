namespace _03._Take_Skip_Rope
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = new List<int>();
			List<char> letters = new List<char>();

			string text = Console.ReadLine();
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsDigit(text[i]))
				{
					int number = int.Parse(text[i].ToString());
					numbers.Add(number);
				}
				else
				{
					letters.Add(text[i]);
				}
			}

			List<int> take = new List<int>();
			List<int> skip = new List<int>();

			for (int i = 0; i < numbers.Count; i++)
			{
				if (i % 2 == 0)
				{
					take.Add(numbers[i]);
				}
				else
				{
					skip.Add(numbers[i]);
				}
			}

			Decipher(letters, take, skip);
		}

		private static void Decipher(List<char> letters, List<int> take, List<int> skip)
		{
			int indexPos = 0;
			for (int i = 0; i < take.Count; i++)
			{
				int counter = 0;
				for (int j = indexPos; j < letters.Count; j++)
				{
					if (counter == take[i])
					{
						break;
					}

					Console.Write(letters[j]);
					counter++;
				}

				indexPos += skip[i] + counter;
			}
		}
	}
}