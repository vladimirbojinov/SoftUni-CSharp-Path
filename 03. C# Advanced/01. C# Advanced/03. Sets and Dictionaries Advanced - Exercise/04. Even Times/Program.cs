namespace _04._Even_Times
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			Dictionary<int, int> dictionary = new Dictionary<int, int>();

			for (int i = 0; i < count; i++)
			{
				int number = int.Parse(Console.ReadLine());

				if (!dictionary.ContainsKey(number))
				{
					dictionary[number] = 0;
				}

				dictionary[number]++;
			}

			int special = dictionary.Single(x => x.Value % 2 == 0).Key;
            Console.WriteLine(special);
        }
	}
}
