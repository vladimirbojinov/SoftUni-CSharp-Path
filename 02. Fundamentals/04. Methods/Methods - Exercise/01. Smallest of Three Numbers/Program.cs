namespace _01._Smallest_of_Three_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num1 = int.Parse(Console.ReadLine());
			int num2 = int.Parse(Console.ReadLine());
			int num3 = int.Parse(Console.ReadLine());

			Console.WriteLine(SmallestNumber(num1, num2, num3));
		}

		private static int SmallestNumber(int num1, int num2, int num3)
		{
			int min;
			if (num1 < num2)
			{
				min = num1;
			}
			else
			{
				min = num2;
			}

			if (num3 < min)
			{
				min = num3;
			}

			return min;
		}
	}
}