using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
			char char1 = char.Parse(Console.ReadLine());
			char char2 = char.Parse(Console.ReadLine());

			Console.WriteLine(string.Join(" ", CharRange(char1, char2)));
		}

        private static char[] CharRange(char char1, char char2)
        {
            if (char1 > char2)
            {
                char temp = char1;
                char1 = char2;
                char2 = temp;
            }

            string row = string.Empty;

            for (int i = char1 + 1; i < char2; i++)
            {
                char singleChar = (char)i;
                row += singleChar;
            }

            char[] charArray = row.ToCharArray();

            return charArray;
        }
    }
}