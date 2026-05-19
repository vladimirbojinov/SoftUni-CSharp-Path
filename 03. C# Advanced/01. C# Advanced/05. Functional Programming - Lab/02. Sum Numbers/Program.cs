namespace _02._Sum_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

            Console.WriteLine($"{array.Length}\n{array.Sum()}");
        }
	}
}
