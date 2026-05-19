namespace _07._Predicate_For_Names
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int maxLength = int.Parse(Console.ReadLine());

			string[] names = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			Predicate<int> isAllowedLength = x => maxLength >= x;

			foreach (string name in names)
			{
				if (isAllowedLength(name.Length))
				{
                    Console.WriteLine(name);
                }
			}
		}
	}
}
