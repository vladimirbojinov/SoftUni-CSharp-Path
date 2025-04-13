namespace _02._From_Left_to_The_Right
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int loops = int.Parse(Console.ReadLine());

			for (int i = 0; i < loops; i++)
			{
				int leftSum = 0;
				int rightSum = 0;

				long leftNum = 0;
				long rightNum = 0;

				bool isSpaceSeen = false;
				bool isMinusSeen = false;

				string input = Console.ReadLine();

				for (int j = 0; j < input.Length; j++)
				{
					char currentSymbol = input[j];

					if (currentSymbol == ' ')
					{
						isSpaceSeen = true;
						isMinusSeen = false;
						continue;
					}

					if (currentSymbol == '-')
					{
						isMinusSeen = true;
						continue;
					}

					int currentDigit = int.Parse(currentSymbol.ToString());

					if (isMinusSeen)
					{
						currentDigit *= -1;
					}

					if (isSpaceSeen)
					{
						rightSum += currentDigit;
						rightNum = (rightNum * 10) + currentDigit;
					}
					else
					{
						leftSum += currentDigit;
						leftNum = (leftNum * 10) + currentDigit;
					}
				}

				if (leftNum > rightNum)
				{
					Console.WriteLine(Math.Abs(leftSum));
				}
				else
				{
					Console.WriteLine(Math.Abs(rightSum));
				}
			}
		}
	}
}