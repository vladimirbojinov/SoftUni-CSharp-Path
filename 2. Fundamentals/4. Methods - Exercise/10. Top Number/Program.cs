namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= loops; i++)
            {
                bool isTopNum = isTopNumber(i);

                if (isTopNum)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool isTopNumber(int number)
        {
            bool isDivisibleBy8 = isDevisibleBy8Num(number);
            bool hasOddValue = HasOddValueNum(number);

            if (isDivisibleBy8 && hasOddValue)
            {
                return true;
            }

            return false;
        }

        static bool isDevisibleBy8Num(int number)
        {
            string numberToString = number.ToString();
            int total = 0;

            for (int i = 0; i < numberToString.Length; i++)
            {
                total += int.Parse(numberToString[i].ToString());
            }

            if (total % 8 == 0)
            {
                return true;
            }

            return false;
        }
        private static bool HasOddValueNum(int number)
        {
            string numberToString = number.ToString();
            int singleDigit = 0;

            for (int i = 0; i < numberToString.Length; i++)
            {
                singleDigit += int.Parse(numberToString[i].ToString());
                if (singleDigit % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}