namespace _05._Fashion_Boutique
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> stack = new Stack<int>(Console.ReadLine()
				.Split()
				.Select(int.Parse));

			int rackCapacity = int.Parse(Console.ReadLine());
			int sum = 0;
			int rackCount = 1;

			while (stack.Count > 0 && stack.Count != 0)
			{
				int currentCloth = stack.Pop();

				if (sum == rackCapacity ||
					sum + currentCloth > rackCapacity)
				{
					rackCount++;
					sum = 0;
				}
				
				sum += currentCloth;
			}

            Console.WriteLine(rackCount);
        }
	}
}
