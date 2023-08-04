using System.Collections.Generic;

namespace _03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            List<int> numbers = new List<int>();

            string starterText = Console.ReadLine();
            for (int i = 0; i < starterText.Length; i++)
            {
                int bin;
                string currentLetter = starterText[i].ToString();
                bool isNumber = int.TryParse(currentLetter, out bin);
                if (isNumber)
                {
                    numbers.Add(int.Parse(currentLetter));
                }
                else
                {
                    text.Add(currentLetter);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int j = 0; j < numbers.Count; j++)
            {
                if (j % 2 == 0)
                {
                    takeList.Add(numbers[j]);
                }
                else
                {
                    skipList.Add(numbers[j]);
                }
            }

            int currentIndex = 0;
            int takeListTurn = 0;
            int skipListTurn = 0;

            while (takeListTurn != takeList.Count)
            {

                int starterIndex = currentIndex;
                for (int i = 0; i < takeList[takeListTurn]; i++)
                {
                    Console.Write(text[starterIndex]);
                    starterIndex++;
                }

                currentIndex += takeList[takeListTurn];
                currentIndex += (skipList[skipListTurn]);

                takeListTurn++;
                skipListTurn++;
            }
        }
    }
}