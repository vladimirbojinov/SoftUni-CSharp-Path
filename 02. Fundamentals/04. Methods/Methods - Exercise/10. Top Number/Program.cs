namespace _10._Top_Number
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int loops = int.Parse(Console.ReadLine());

			for (int i = 1; i <= loops; i++)
			{
				bool isTopNum = IsTopNumber(i);

				if (isTopNum)
				{
					Console.WriteLine(i);
				}
			}
		}

		private static bool IsTopNumber(int number)
		{
			bool isDivisibleByEight = IsDivisibleByEight(number);
			bool hasOddNumber = HasOddNumber(number);

			if (isDivisibleByEight && hasOddNumber)
			{
				return true;
			}

			return false;
		}

		private static bool IsDivisibleByEight(int number)
		{
			int sum = 0;

			while (number > 0)
			{
				int digit = number % 10;
				number /= 10;
				sum += digit;
			}

			if (sum % 8 == 0)
			{
				return true;
			}

			return false;
		}

		private static bool HasOddNumber(int number)
		{
			while (number > 0)
			{
				int digit = number % 10;
				number /= 10;

				if (digit % 2 != 0)
				{
					return true;
				}
			}

			return false;
		}
	}
}