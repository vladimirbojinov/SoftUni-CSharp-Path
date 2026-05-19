namespace _02._Knights_of_Honor
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			Action<string> print = x => Console.WriteLine($"Sir {x}");
			Array.ForEach(array, print);
		}
	}
}
