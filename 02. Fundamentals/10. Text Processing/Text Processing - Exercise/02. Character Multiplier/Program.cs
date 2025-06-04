namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();

            Console.WriteLine(SumOfTexts(text[0], text[1]));
        }

        private static int SumOfTexts(string firstText, string secondText)
        {
            int sum = 0;

            if (firstText.Length > secondText.Length)
            {
                sum = GetSum(firstText, secondText);
            }
			else
			{
				sum = GetSum(secondText, firstText);
			}

            return sum;
		}

		private static int GetSum(string firstText, string secondText)
		{
            int sum = 0;
            for (int i = 0; i < firstText.Length; i++)
            {
                if (secondText.Length > i)
                {
                    sum += firstText[i] * secondText[i];
                }
                else
                {
                    sum += firstText[i];
                }
            }

            return sum;
		}
	}
}