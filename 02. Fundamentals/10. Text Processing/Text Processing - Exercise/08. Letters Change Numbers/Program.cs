namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gameNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            decimal sum = 0;

            foreach (string gameNumber in gameNumbers)
			{
				decimal number = int.Parse(gameNumber.Where(char.IsDigit).ToArray());

				number = FirstLetterCalc(gameNumber, number);
				number = LastLetterCalc(gameNumber, number);

				sum += number;
			}

			Console.WriteLine($"{sum:F2}");
		}

		private static decimal LastLetterCalc(string gameNumber, decimal number)
		{
			if (char.IsUpper(gameNumber[gameNumber.Length - 1]))
			{
				int letterPos = gameNumber[gameNumber.Length - 1] - 64;
				number -= letterPos;
			}
			else
			{
				int letterPos = gameNumber[gameNumber.Length - 1] - 96;
				number += letterPos;
			}

			return number;
		}

		private static decimal FirstLetterCalc(string gameNumber, decimal number)
		{
			if (char.IsUpper(gameNumber[0]))
			{
				int letterPos = gameNumber[0] - 64;
				number /= letterPos;
			}
			else
			{
				int letterPos = gameNumber[0] - 96;
				number *= letterPos;
			}

			return number;
		}
	}
}