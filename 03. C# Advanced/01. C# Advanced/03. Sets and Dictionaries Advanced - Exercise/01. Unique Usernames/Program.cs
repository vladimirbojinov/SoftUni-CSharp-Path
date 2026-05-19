namespace _01._Unique_Usernames
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			HashSet<string> set = new HashSet<string>();

			for (int i = 0; i < count; i++)
			{
				string name = Console.ReadLine();
				
				set.Add(name);
			}

            Console.WriteLine(string.Join("\n", set));
        }
	}
}
