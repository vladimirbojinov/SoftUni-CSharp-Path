namespace _01._Train
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int wagons = int.Parse(Console.ReadLine());
			int[] train = new int[wagons];

			for (int i = 0; i < train.Length; i++)
			{
				int peopleCount = int.Parse(Console.ReadLine());
				train[i] = peopleCount;
			}

			Console.WriteLine(string.Join(" ", train));
			Console.WriteLine(train.Sum());
		}
	}
}