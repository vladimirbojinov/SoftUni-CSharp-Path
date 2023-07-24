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
            int totalSum = 1;

            int maxLength = Math.Max(firstText.Length, secondText.Length);

            for (int i = 0; i < maxLength; i++)
            {
                if (i < firstText.Length && i < secondText.Length)
                {
                    totalSum += firstText[i] * secondText[i];
                }
                else if (i > firstText.Length - 1)
                {
                    totalSum += secondText[i];
                }
                else if (i > secondText.Length - 1)
                {
                    totalSum += firstText[i];
                }
            }

            totalSum--;
            return totalSum;
        }
    }
}