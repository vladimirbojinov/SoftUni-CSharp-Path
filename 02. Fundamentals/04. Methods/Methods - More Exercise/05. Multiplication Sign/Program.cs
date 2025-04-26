namespace _05._Multiplication_Sign
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num1 = int.Parse(Console.ReadLine());
			int num2 = int.Parse(Console.ReadLine());
			int num3 = int.Parse(Console.ReadLine());

			int result = Multiplication(num1, num2);
			result = Multiplication(result, num3);

			NumberStatus(result);
		}

		private static int Multiplication(int num1, int num2)
		{
			int result = 0;
			bool isNegative = num2 < 0;
			num2 = Math.Abs(num2);

			for (int i = 0; i < num2; i++)
			{
				result += num1;
			}

			if (isNegative)
			{
				return result * -1;
			}

			return result;
		}

		private static void NumberStatus(int num)
		{
			if (num == 0)
			{
				Console.WriteLine("zero");
			}
			else if (num > 0)
			{
				Console.WriteLine("positive");
			}
			else
			{
				Console.WriteLine("negative");
			}
		}
	}
}
