namespace _02._Vowels_Count
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int vowelCount = VowelFinder();
			Console.WriteLine(vowelCount);
		}

		private static int VowelFinder()
		{
			int count = 0;
			string word = Console.ReadLine().ToLower();

			for (int i = 0; i < word.Length; i++)
			{
				char singleLetter = word[i];

				switch (singleLetter)
				{
					case 'a':
					case 'e':
					case 'i':
					case 'o':
					case 'u': 
						count++; break;
				}
			}

			return count;
		}
	}
}