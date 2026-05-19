namespace _03._Count_Uppercase_Words
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Func<string, bool> func = x => char.IsUpper(x[0]);

			string[] uppercaseLetters = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Where(func)
				.ToArray();

            Console.WriteLine(string.Join("\n", uppercaseLetters));
        }
	}
}
