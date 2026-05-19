namespace _11._TriFunction
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int targetSum = int.Parse(Console.ReadLine());

			string[] names = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			string currentName = string.Empty;
			int currentSum = 0;

			foreach (string name in names)
			{
				if (currentSum >= targetSum) break;
				Func<char[], int> sumChars = x => x.Sum(x => x);
				char[] chars = name.ToCharArray();

				currentName = name;
				currentSum = sumChars(chars);

			}

            Console.WriteLine(currentName);
        }
	}
}
