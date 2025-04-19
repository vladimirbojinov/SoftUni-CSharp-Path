namespace _06._Strong_number
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string numberAsString = Console.ReadLine();

			int digitFactSum = 0;
			for (int i = 0; i < numberAsString.Length; i++)
			{
				int factorial = 1;
				char currentChar = numberAsString[i];
				int currentNum = int.Parse(currentChar.ToString());

				for (int j = 1; j <= currentNum; j++)
				{
					factorial *= j;
				}

				digitFactSum += factorial;
			}

			int convertedNumber = int.Parse(numberAsString);
			if (digitFactSum == convertedNumber)
			{
				Console.WriteLine("yes");
			}
			else
			{
				Console.WriteLine("no");
			}
		}
	}
}