namespace _10._Multiply_Evens_by_Odds
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num = Math.Abs(int.Parse(Console.ReadLine()));

			Console.WriteLine(GetMultipleOfEvenAndOdds(num));
		}

		public static int GetSumOfEvenDigits(int num)
		{
			int evenSum = 0;

			while (num > 0)
			{
				int digit = num % 10;
				if (digit % 2 == 0)
				{
					evenSum += digit;
				}
				num /= 10;
			}

			return evenSum;
		}

		public static int GetSumOfOddDigits(int num)
		{
			int oddSum = 0;

			while (num > 0)
			{
				int digit = num % 10;
				if (digit % 2 != 0)
				{
					oddSum += digit;
				}
				num /= 10;
			}

			return oddSum;
		}

		public static int GetMultipleOfEvenAndOdds(int num)
		{
			int evenSum = GetSumOfEvenDigits(num);
			int oddSum = GetSumOfOddDigits(num);

			return evenSum * oddSum;
		}
	}
}